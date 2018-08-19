using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
   public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
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
    }
}
