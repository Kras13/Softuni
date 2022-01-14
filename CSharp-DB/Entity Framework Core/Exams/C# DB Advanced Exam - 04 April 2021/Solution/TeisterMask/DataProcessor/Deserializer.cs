namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            ImportProjectDto[] projectDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                projectDtos = (ImportProjectDto[])(xmlSerializer.Deserialize(sr));
            }

            List<Project> projects = new List<Project>();
            var sb = new StringBuilder();

            foreach (ImportProjectDto projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                bool isOpenDateValid = DateTime.TryParseExact(
                    projectDto.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!string.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    DateTime dueDateDt;
                    bool isDueDateValid = DateTime.TryParseExact(
                    projectDto.DueDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dueDateDt);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateDt;
                }

                Project project = new Project()
                {
                    DueDate = dueDate,
                    Name = projectDto.Name,
                    OpenDate = openDate
                };

                foreach (var projectTaskDto in projectDto.Tasks)
                {
                    if (!IsValid(projectTaskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(
                    projectTaskDto.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskDueDateValid = DateTime.TryParseExact(
                    projectTaskDto.DueDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue && taskDueDate > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        DueDate = taskDueDate,
                        OpenDate = taskOpenDate,
                        ExecutionType = (ExecutionType)projectTaskDto.ExecutionType,
                        LabelType = (LabelType)projectTaskDto.LabelType,
                        Name = projectTaskDto.Name
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportEmployeeDto[] employeesDtos =
                JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> validEmployees = new List<Employee>();
            foreach (ImportEmployeeDto employeeDto in employeesDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                List<EmployeeTask> employeeTasks = new List<EmployeeTask>();
                foreach (int taskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context
                        .Tasks
                        .Find(taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task
                    };
                    employeeTasks.Add(employeeTask);
                }

                employee.EmployeesTasks = employeeTasks;

                validEmployees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employeeTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}