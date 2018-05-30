using GradeBook.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isweighted) : base(name, isweighted)
        {

            base.Type = GradeBookType.Ranked;

        }

        private class Distribution
        {

            public char LetterGrade { get; set; }

            public int NumberInGrade { get; set; }


            public int Rank { get; set; }


            public double AverageGrade { get; set; }
        }



        public override void CalculateStatistics()
        {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
                


            base.CalculateStatistics();
        }


        public override void CalculateStudentStatistics(string name)
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }




            base.CalculateStudentStatistics(name);  
        }


        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new System.InvalidOperationException("Ranked grading required 5 or more students.");
            }

            // top 20% for class return 'A'

            // 20% to 40% return 'B'

            // 40% to 60% return 'C'

            // 60% to 80% return 'D'

            // bottom 20% for class return 'F'

            //int _numberOfStudentsInGrade = (int)(Students.Count * .2);
            //int _fractionPart = Students.Count - (5 * _numberOfStudentsInGrade);

            //List<Distribution> _listOfGradeDistribution = new List<Distribution>();
            //_listOfGradeDistribution.Add(new Distribution { LetterGrade = 'A', NumberInGrade = _numberOfStudentsInGrade });
            //_listOfGradeDistribution.Add(new Distribution { LetterGrade = 'B', NumberInGrade = _numberOfStudentsInGrade });
            //_listOfGradeDistribution.Add(new Distribution { LetterGrade = 'C', NumberInGrade = _numberOfStudentsInGrade });
            //_listOfGradeDistribution.Add(new Distribution { LetterGrade = 'D', NumberInGrade = _numberOfStudentsInGrade });
            //_listOfGradeDistribution.Add(new Distribution { LetterGrade = 'F', NumberInGrade = _numberOfStudentsInGrade });

            //foreach (var grade in _listOfGradeDistribution)
            //{

            //    grade.NumberInGrade = grade.NumberInGrade + 1;
            //    _fractionPart--;

            //    if (_fractionPart == 0)
            //        break;

            //}


            //List<Distribution> _listOfRank = new List<Distribution>();

            //int _rankcounter = 1;
            //foreach (var item in _listOfGradeDistribution)
            //{

            //    for (int i = 0; i < item.NumberInGrade; i++)
            //    {
            //        _listOfRank.Add(new Distribution { Rank = _rankcounter, LetterGrade = item.LetterGrade });
            //        _rankcounter++;
            //    }

            //}


            //SortedList<double, Student> _sortedList = new SortedList<double, Student>();

            //foreach (var item in Students)
            //{
            //    _sortedList.Add(item.AverageGrade, item);
            //}

            //var _sortedListReversed = _sortedList.Reverse().ToList();

            //int _rank = 0;

            //foreach (var item in _sortedListReversed)
            //{

            //    if (item.Value.AverageGrade == averageGrade)
            //        break;


            //    _rank++;
            //}


            //var _someChar = _listOfRank[_rank].LetterGrade;



            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            Char answer = 'F';


            if (grades[threshold - 1] <= averageGrade)
                answer = 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                answer = 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                answer = 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                answer = 'D';
            else answer = 'F';



            return answer;
        }



    }
}
