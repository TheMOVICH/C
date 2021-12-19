using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DataLayer;

namespace BusinessLayer
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentID { get; set; }
        public List<Discipline> DisciplinesList { get; set; }
      
        public Student() { }
        public Student(Student student) 
        {
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.StudentID = student.StudentID;
            this.DisciplinesList = student.DisciplinesList;
        }
        public Student(string firstName, string lastName, string studentID, List<Discipline> disciplinesList = null )
        {
            if (this.CheckName(firstName))
            {
                this.FirstName = firstName;
            }
            else
            {
                throw new ArgumentException("Please enter valid first name");
            }
            if (this.CheckName(lastName))
            {
                this.LastName = lastName;
            }
            else
            {
                throw new ArgumentException("Please enter valid last name");
            }
            if (this.CheckStudentId(studentID))
            {
                this.StudentID = studentID;
            }
            else
            {
                throw new ArgumentException("Please enter valid student ID");
            }       
            if (disciplinesList != null)
            {
                this.DisciplinesList = disciplinesList;
            }
            else
            {
                this.DisciplinesList = new List<Discipline>();
            }
        }
        public int GetAvarageGrades()
        {
            if (DisciplinesList.Count == 0)
            {
                return 0;
            }
            int sum = 0;
            foreach(Discipline discipline in DisciplinesList)
            {                
                    discipline.FinalGrade = 0;
                   foreach (int grade in discipline.GradesList)
                    {
                        discipline.FinalGrade += grade;
                    }
                    sum += discipline.FinalGrade;
                
            }
            return sum / DisciplinesList.Count;
        }
        public override string ToString()
        {
            int name_length = 20;
            int student_Id_length = 10;
            string firstname = this.FirstName + (new String(' ', name_length - this.FirstName.ToString().Length));
            string lastname = this.LastName + (new String(' ', name_length - this.LastName.ToString().Length));
            string studentId = this.StudentID + (new String(' ', student_Id_length - this.StudentID.ToString().Length));
            return String.Format("|{0,2}|{1,2}|{2,2}|", firstname, lastname, studentId);
        }
        public bool IsMatchByName(string str)
        {
            str = str.ToLower();
            string reg_str = @"^(.*" + str + ".*)$";
            Regex regex = new Regex(reg_str);
            return regex.IsMatch(this.FirstName +" " + this.LastName );
        }  
         public bool CheckName(string name)
        {
            string regex_str = @"(^\b[A-Z][a-z]+[^0-9]\b$)";
            Regex regex = new Regex(regex_str);
            return regex.IsMatch(name);
        }
        public bool CheckStudentId(string studentID)
        {
            string regex_str = @"(^\b[A-Z]{2}[\d]{6}\b$)";
            Regex regex = new Regex(regex_str);
            return regex.IsMatch(studentID);
        }

    }
}
