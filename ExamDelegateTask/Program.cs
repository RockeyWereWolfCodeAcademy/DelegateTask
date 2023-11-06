using Core.Models;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ExamDelegateTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Exam> exams = new List<Exam>();
            Console.WriteLine("How many exams you want to add?");
            int examCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < examCount; i++)
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();
                Console.Write("Enter subject of the exam: ");
                string subject = Console.ReadLine();
                Console.Write("Enter grade of student(0-100): ");
                byte grade = Convert.ToByte(Console.ReadLine());
                Console.Write("When exam started?(day/mounth/year hour:minutes): ");
                DateTime dateStart = DateTime.Parse(Console.ReadLine());
                Console.Write("How long exam was?(hour, minutes): ");
                string[] durationParts = Console.ReadLine().Split(',');
                int hours = int.Parse(durationParts[0]);
                int minutes = int.Parse(durationParts[1]);
                DateTime dateEnd = dateStart.AddHours(hours).AddMinutes(minutes);
                exams.Add(new Exam
                {
                    Student = new Student { Name = name },
                    Subject = subject,
                    Point = grade,
                    StartDate = dateStart,
                    EndDate = dateEnd
                });
            }
            Console.WriteLine("Exam records with 50+ points: ");
            exams.FindAll(exam => exam.Point >= 50).ForEach(exam => Console.WriteLine("Name: " +exam.Student.Name + " Subject: " + exam.Subject + " Score: " + exam.Point + " Duration: " + (exam.EndDate - exam.StartDate)));
            Console.WriteLine("Exams in the past week: ");
            var calendar = DateTimeFormatInfo.CurrentInfo.Calendar;
            exams.FindAll(exam =>
            {
                int currentWeek = calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                int examWeek = calendar.GetWeekOfYear(exam.StartDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                return examWeek == currentWeek;
            }).ForEach(exam => Console.WriteLine("Name: " + exam.Student.Name + " Subject: " + exam.Subject + " Score: " + exam.Point + " Duration: " + (exam.EndDate - exam.StartDate)));
            Console.WriteLine("Exams lasted more than 1 hour: ");
            exams.FindAll(exam => (exam.EndDate - exam.StartDate).TotalHours > 1).ForEach(exam => Console.WriteLine("Name: " + exam.Student.Name + " Subject: " + exam.Subject + " Score: " + exam.Point + " Duration: " + (exam.EndDate - exam.StartDate)));
        }
    }
}