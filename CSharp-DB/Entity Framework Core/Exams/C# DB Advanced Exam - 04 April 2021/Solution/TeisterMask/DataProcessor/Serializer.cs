namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            List<ExportProjectDto> exportProjectDtos = new List<ExportProjectDto>();

            var projects = context.Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
                .Select(p => new
                {
                    Name = p.Name,
                    TasksCount = p.Tasks.Count(),
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                        .OrderBy(t => t.Name)
                        .Select(t => new
                        {
                            TaskName = t.Name,
                            TaskLabelType = t.LabelType.ToString()
                        }).ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.Name)
                .ToArray();

            foreach (var project in projects)
            {
                List<ExportProjectTaskDto> projectTasks = new List<ExportProjectTaskDto>();

                foreach (var projectTask in project.Tasks)
                {
                    projectTasks.Add(new ExportProjectTaskDto()
                    {
                        Name = projectTask.TaskName,
                        Label = projectTask.TaskLabelType
                    });
                }

                ExportProjectDto exportProject = new ExportProjectDto()
                {
                    Name = project.Name,
                    HasEndDate = project.HasEndDate,
                    TasksCount = project.TasksCount,
                    Tasks = projectTasks.ToArray()
                };

                exportProjectDtos.Add(exportProject);
            }

            xmlSerializer.Serialize(sw, exportProjectDtos.ToArray(), namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employeesWithTasks = context.Employees.
                Include(e => e.EmployeesTasks)
                .ThenInclude(ep => ep.Task)
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(t => t.Task.OpenDate >= date)
                        .ToArray()
                        .OrderByDescending(t => t.Task.DueDate)
                        .ThenBy(t => t.Task.Name)
                        .Select(t => new
                        {
                            TaskName = t.Task.Name,
                            OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString()
                        }).ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employeesWithTasks, Formatting.Indented);
        }
    }
}