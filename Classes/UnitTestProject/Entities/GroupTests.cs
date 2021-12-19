using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests
{
    [TestClass()]
    public class GroupTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GroupTest()
        {
            Group group = new Group("se-1234");
        }

        [TestMethod()]
        public void GroupTest1()
        {
            Group group = new Group("SE-227");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string group_name = "SE-129";
            Group group = new Group(group_name);
            string expected = group_name;
            string actual = group.ToString();
            StringAssert.Equals(expected, actual);
        }

        [TestMethod()]
        public void CheckGroupNameTest()
        {
            Group group = new Group();
            string failure_str = "SE:123";
            bool expected = false;
            bool actual = group.CheckGroupName(failure_str);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void GetStudentsAvarageGradesTest()
        {
            Group group = new Group();
            string first_name = "Ivan";
            string last_name = "Ivanov";
            string student_ID = "AA123456";
           
            Discipline discipline = new Discipline();
            List<int> grades1 = new List<int>() { 89, 1 };
            discipline.GradesList = grades1;
            List<Discipline> disciplines = new List<Discipline>() { discipline };
            Student student = new Student(first_name, last_name, student_ID, disciplines);
            int name_length = 20;
            int student_Id_length = 10;
            string firstname = first_name + (new String(' ', name_length - first_name.ToString().Length));
            string lastname = last_name + (new String(' ', name_length - last_name.ToString().Length));
            string studentId = student_ID + (new String(' ', student_Id_length - student_ID.ToString().Length));
            string expected= String.Format("|{0,2}|{1,2}|{2,2}|", firstname, lastname, studentId);
            expected += " " + 90 + "\n";
            string actual = group.GetStudentsAvarageGrades();
            StringAssert.Equals(expected, actual);

        }

    }
}