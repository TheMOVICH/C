using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests
{
    [TestClass()]
    public class StudentTests
    {
        [TestMethod]
        public void StudentTest()
        {
            Student student = new Student();
        }

        [TestMethod]
        public void StudentTest1()
        {
            string first_name = "Ivan";
            string last_name = "Ivanov";
            string student_ID = "AA123456";
            Student student = new Student(first_name, last_name, student_ID);
        }

        [TestMethod]
        public void StudentTest2()
        {
            string first_name = "Ivan";
            string last_name = "Ivanov";
            string student_ID = "AA123456";
            Discipline discipline = new Discipline("Math");
            List<Discipline> list = new List<Discipline>() { discipline }; 
            Student student = new Student(first_name, last_name, student_ID, list);
        }

        [TestMethod]
        public void GetAvarageGradesTest()
        {
            string first_name = "Ivan";
            string last_name = "Ivanov";
            string student_ID = "AA123456";
            List<int> grades1 = new List<int>() { 89, 1 }; 
            List<int> grades2= new List<int>() { 90, 2 }; 
            Discipline discipline1 = new Discipline("Math");
            discipline1.GradesList = grades1;
            Discipline discipline2 = new Discipline("History");
            discipline2.GradesList = grades2;
            List<Discipline> list = new List<Discipline>() { discipline1, discipline2 };
            Student student = new Student(first_name, last_name, student_ID, list);
            int expected = 91;
            int actual = student.GetAvarageGrades();
            Assert.AreEqual(expected, actual);
        }
      
        [TestMethod]
        public void IsMatchByNameTest()
        {
            string first_name = "Ivan";
            string last_name = "Ivanov";
            string student_ID = "AA123456";
            Student student = new Student(first_name, last_name, student_ID);
            string str = "an";
            bool actual = student.IsMatchByName(str);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckNameTest()
        {
            string first_name = "Ivan";
            string last_name = "Ivanov";
            string student_ID = "AA123456";
            Student student = new Student(first_name, last_name, student_ID);

            string failure_name = "mAriA";
            bool expected = false;
            bool actual = student.CheckName(failure_name);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStudentIdTest()
        {
            string first_name = "Ivan";
            string last_name = "Ivanov";
            string student_ID = "AA123456";
            Student student = new Student(first_name, last_name, student_ID);

            string failure_student_id = "AAA1234567";
            bool expected = false;
            bool actual = student.CheckStudentId(failure_student_id);

            Assert.AreEqual(expected, actual);
        }
    }
}