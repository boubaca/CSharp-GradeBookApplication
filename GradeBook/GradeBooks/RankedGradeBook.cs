using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
   public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool isweighted) : base(name,isweighted)
        {
            Type = Enums.GradeBookType.Ranked;
            IsWeighted = isweighted;
        }

        
        public override char GetLetterGrade(double averageGrade)
        {   
            if(Students.Count < 5)
              throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            var parcentage = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(n => n.AverageGrade).Select(n =>n.AverageGrade).ToList();

            if (grades[parcentage - 1] <= averageGrade) return 'A';
            else if (grades[parcentage * 2 - 1] <= averageGrade) return 'B';
            else if (grades[parcentage * 3 - 1] <= averageGrade) return 'C';
            else if (grades[parcentage * 4 - 1] <= averageGrade) return 'D';
            else return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

            }
            else base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

            }
            else base.CalculateStudentStatistics(name);
        }
    }
}
