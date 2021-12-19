using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using System.Text.RegularExpressions;
namespace BusinessLayer
{
    [Serializable]
    public class Group
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (this.CheckGroupName(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Please enter valid group name");
                }
            }
        }
        public List<Student> StudentsList { get; set; }
        public Group(string name,  List<Student> studentlist = null)
        {
            this.Name = name;
            if (studentlist == null)
            {
                this.StudentsList = new List<Student>();
            }
            else
            {
                this.StudentsList = studentlist;
            }
        }
        public Group() 
        {            
                this.StudentsList = new List<Student>();            
        }
        public string GetStudentsAvarageGrades()
        {
            
            string return_str = "";
            if (StudentsList.Count==0)
            {
                return_str = "There is no students in this group";
                return return_str;
            }
           
            foreach(Student student in StudentsList)
            {
               return_str+= student.ToString() + student.GetAvarageGrades().ToString() + "\n";
            }
            return return_str;
        }
        public override string ToString()
        {
            return this.Name;

        }
        public bool CheckGroupName(string name)
        {
            string regex_str = @"(^\b[A-Z]{2}-[0-9]{3}\b$)";
            Regex regex = new Regex(regex_str);
            return regex.IsMatch(name);
        }

    }
}
