using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests
{
    [TestClass()]
    public class DisciplineTests
    {
        [TestMethod()]
        public void DisciplineTest()
        {
            Discipline discipline = new Discipline("Math");
        }

        [TestMethod()]
        public void DisciplineTest1()
        {
            Discipline discipline = new Discipline();
        }

        [TestMethod()]
        public void ToStringWithGradesTest()
        {
            Discipline discipline = new Discipline();
            List<int> grades1 = new List<int>() { 89, 1 };
            discipline.GradesList = grades1;
            string expected = "89 1 ";
            string actual =discipline.ToStringWithGrades();
            StringAssert.Equals(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string title = "Physics";
            Discipline discipline = new Discipline(title);
            string expected = title;
            string actual = discipline.ToString();
            StringAssert.Equals(expected, actual);
        }     
    }
}