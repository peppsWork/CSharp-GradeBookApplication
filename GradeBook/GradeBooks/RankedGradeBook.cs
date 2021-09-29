using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();
            int spg = Students.Count / 5;
            int i = 0;
            char grade = 'A';
            foreach (Student s in Students.OrderByDescending(s => s.AverageGrade))
            {
                if (s.AverageGrade == averageGrade) return grade;
                i++;
                if (i % spg == 0) grade = dropGrade(grade);
            }

            return 'F';
        }

        private char dropGrade(char grade)
        {
            if (grade == 'A') return 'B';
            if (grade == 'B') return 'C';
            if (grade == 'C') return 'D';
            if (grade == 'D') return 'E';
            return 'F';
        }
    }
}
