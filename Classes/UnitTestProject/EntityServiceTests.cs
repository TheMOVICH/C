using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests
{
    [TestClass()]
    public class EntityServiceTests
    {        

        [TestMethod()]
        public void EntityServiceTest()
        {
            EntityService entity = new EntityService();
        }

        [TestMethod()]
        public void AddGroupTest()
        {
            Group group = new Group("SE-437");
            EntityService entity = new EntityService();
            int expected = entity.GroupList.Count + 1;
            entity.AddGroup(group);
            int actual = entity.GroupList.Count;
            entity.RemoveGroup(actual-1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddStudentTest()
        {         
            EntityService entity = new EntityService();
            int expected = entity.GroupList[0].StudentsList.Count + 1;
            Student student = new Student();
            entity.AddStudent(0,student);
            int actual = entity.GroupList[0].StudentsList.Count;
            entity.RemoveStudent(0,actual - 1);
            Assert.AreEqual(expected, actual);
        }        

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetGroupByIndexTest()
        {
            EntityService entity = new EntityService();
            entity.GetGroupByIndex(1000);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetStudentByIndexTest()
        {
            EntityService entity = new EntityService();
            entity.GetStudentByIndex(0,1000);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetDisciplineByIndexTest()
        {
            EntityService entity = new EntityService();
            entity.GetDisciplineByIndex(0,0, 1000);
        }

        [TestMethod()]
        public void StudentSearchByNameTest()
        {
            EntityService entity = new EntityService();
            List<Student> expected = new List<Student>();
            List<Student> actual = entity.StudentSearchByName("19203120");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StudentSearchInGroupByNameTest()
        {
            EntityService entity = new EntityService();
            List<Student> expected = new List<Student>();
            List<Student> actual = entity.StudentSearchInGroupByName(0,"aaaaaaaaa");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StudentSearchByAvarageGradeTest()
        {
            EntityService entity = new EntityService();
            List<Student> expected = new List<Student>();
            List<Student> actual = entity.StudentSearchByAvarageGrade(100);
            CollectionAssert.AreEqual(expected, actual);
        }
       
    }
}