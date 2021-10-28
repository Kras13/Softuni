using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public int Capacity { get; }

        public int Count => students.Count;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity /*&& !students.Any(st => st.FirstName == student.FirstName && st.LastName == student.LastName)*/
                )
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return $"No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (!students.Any(st => st.FirstName == firstName && st.LastName == lastName))
            {
                return "Student not found";
            }

            Student selectedStudent = students.First(st => st.FirstName == firstName && st.LastName == lastName);
            students.Remove(selectedStudent);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.Any(st => st.Subject == subject))
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine($"Subject: {subject}");
                str.AppendLine("Students:");

                foreach (Student student in students.Where(st => st.Subject == subject))
                {
                    str.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return str.ToString().Trim();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students
                .FirstOrDefault(st => st.FirstName == firstName && st.LastName == lastName);
        }
    }
}
