using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = RemoveTown(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                });

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(emp => new
                {
                    FirstName = emp.FirstName,
                    Salary = emp.Salary
                })
                .OrderBy(e => e.FirstName);

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(emp => new
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    DepartmentName = emp.Department.Name,
                    Salary = emp.Salary
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var selectedEmployee = context.Employees
                .FirstOrDefault(emp => emp.LastName == "Nakov");

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(address);

            selectedEmployee.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    AddressText = e.Address.AddressText,
                    AddressId = e.AddressId
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10);

            var sb = new StringBuilder();

            foreach (var em in employees)
            {
                sb.AppendLine($"{em.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    EmployeeProjects = e.EmployeesProjects
                        .Where(emp => emp.Project.StartDate.Year >= 2001 && emp.Project.StartDate.Year <= 2003)
                })
                .ToArray();

            var sb = new StringBuilder();

            int counter = 0;

            foreach (var emp in employees)
            {
                if (emp.EmployeeProjects.Any())
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName}" +
                        $" - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                    foreach (var p in emp.EmployeeProjects)
                    {
                        string endDate = "";

                        if (p.Project.EndDate == null)
                        {
                            endDate = "not finished";
                        }
                        else
                        {
                            endDate = p.Project.EndDate?.ToString("M/d/yyyy h:mm:ss tt");
                        }

                        sb.AppendLine($"--{p.Project.Name} - {p.Project.StartDate} -" +
                            $" {endDate}");
                    }

                    counter++;
                }

                if (counter == 10)
                {
                    break;
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    EmployeesCount = a.Employees.Count(),
                    AddressText = a.AddressText,
                    TownName = a.Town.Name
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10);

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(emp => emp.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var p in employee.EmployeesProjects.OrderBy(p => p.Project.Name))
            {
                sb.AppendLine($"{p.Project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                        .Select(emp => new
                        {
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Jobtitle = emp.JobTitle
                        })
                });

            var sb = new StringBuilder();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerFirstName} {dep.ManagerLastName}");

                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.Jobtitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                });

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            //Engineering, Tool Design, Marketing, or Information Services department by 12%. 

            var employees = context.Employees
                .Where(
                e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                emp.Salary += (emp.Salary * 0.12m);
            }

            context.SaveChanges();

            foreach (var emp in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var selectedProject = context.Projects
                .FirstOrDefault(p => p.ProjectId == 2);
            var employeeProjectsToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToArray();

            context.EmployeesProjects.RemoveRange(employeeProjectsToDelete);

            context.SaveChanges();

            if (selectedProject != null)
            {
                context.Projects
                    .Remove(selectedProject);
            }

            context.SaveChanges();

            var projects = context.Projects
                .Take(10);

            var sb = new StringBuilder();

            foreach (var pr in projects)
            {
                sb.AppendLine($"{pr.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townsToDelete = context.Towns
                .Where(t => t.Name == "Seattle")
                .ToArray();

            int townId = townsToDelete.FirstOrDefault().TownId;

            var employees = context.Employees
                .Include(e => e.Address)
                .Where(e => e.Address.TownId == townId);

            foreach (var em in employees)
            {
                em.AddressId = null;
                em.Address = null;
            }
            context.SaveChanges();

            var addressesToDelete = context.Addresses
                .Where(a => a.TownId == townId)
                .ToArray();
            int deletedAdresses = addressesToDelete.Count();

            context.Addresses.RemoveRange(addressesToDelete);
            context.SaveChanges();

            context.Towns.RemoveRange(townsToDelete);
            context.SaveChanges();

            return $"{deletedAdresses} addresses in Seattle were deleted";
        }
    }
}
