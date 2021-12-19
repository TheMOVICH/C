using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;

namespace BusinessLayer
{
    public class Discipline
    {
        public string Title { get; set; }
        public List<int> GradesList { get; set; }
        public int FinalGrade { get; set; }
        public Discipline(string text)
        {
            this.Title = text;
            this.GradesList = new List<int>();
            this.FinalGrade = -1;
        }
        public Discipline() 
        {
            this.GradesList = new List<int>();
            this.FinalGrade = -1;
        }
        public string ToStringWithGrades()
        {
            string return_str = " ";
            foreach(int grade in GradesList)
            {
                return_str += grade.ToString() + " ";
            }
            return return_str;
        }
        public override string ToString()
        {
            return Title;
        }
    }

        
}

