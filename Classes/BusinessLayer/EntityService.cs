using System.Text;
using DataLayer;
using System.Collections.Generic;
using System;

namespace BusinessLayer
{
    public class EntityService
    {
        public List<Group> GroupList { get; private set; }
        private EntityContext<Group> Group_entity;
        public void SaveInFile()
        {
            Group_entity.WriteToFile(GroupList);
        }
        public EntityService() 
        {
            Group_entity = new EntityContext<Group>();
            Group_entity.CreateFile();
            GroupList = Group_entity.ReadFromFile();
        }
            
        public void AddGroup(Group group)
        {
            GroupList.Add(group);
            this.SaveInFile();
        }
        public void AddStudent(int group_index,Student student)
        {
            GroupList[group_index].StudentsList.Add(student);
            this.SaveInFile();
        }
        public void AddDiscipline(int group_index, Discipline discipline)
        {
            Group group = GroupList[group_index];
            if (group.StudentsList.Count != 0)
            {
                group.StudentsList.ForEach((x) => x.DisciplinesList.Add(discipline));
            }
            else
            {
                throw new ArgumentException("You can't add discipline to empty group");
            }
            this.SaveInFile();
        }
        public Group GetGroupByIndex(int index)
        {
            return this.GroupList[index];
        }
        public Student GetStudentByIndex(int group_index, int student_index)
        {
            return GroupList[group_index].StudentsList[student_index];
        }
        public Discipline GetDisciplineByIndex(int group_index, int student_index, int discipline_index)
        {
            return GroupList[group_index].StudentsList[student_index].DisciplinesList[discipline_index];
        }
        public List<Student> StudentSearchByName(string str)
        {
            List<Student> found_students = new List<Student>();
            foreach (Group group in GroupList)
            {
                foreach(Student student in group.StudentsList)
                {
                    if (student.IsMatchByName(str))
                    {
                        found_students.Add(student);
                    }
                }
            }
            return found_students;
        }
        public List<Student> StudentSearchInGroupByName(int group_index,string str)
        {
            List<Student> found_students = new List<Student>();
            Group group = this.GetGroupByIndex(group_index);
                foreach (Student student in group.StudentsList)
                {
                    if (student.IsMatchByName(str))
                    {
                        found_students.Add(student);
                    }
                }
            
            return found_students;
        }
        public List<Student> StudentSearchByAvarageGrade(int grade)
        {
            List<Student> found_students = new List<Student>();
            foreach (Group group in GroupList)
            {
                foreach (Student student in group.StudentsList)
                {
                    if (student.GetAvarageGrades()>=grade)
                    {
                        found_students.Add(student);
                    }
                }
            }
            return found_students;
        }
        public void RemoveGroup(int index)
        {
            this.GroupList.RemoveAt(index);
        }
        public void RemoveStudent(int group_index, int student_index)
        {
            this.GroupList[group_index].StudentsList.RemoveAt(student_index);
        }
        public void RemoveDiscipline(int group_index, int student_index, int discipline_index)
        {
            Group group = GroupList[group_index];
            group.StudentsList.ForEach((x) => x.DisciplinesList.RemoveAt(discipline_index));
        }
        
    }
}
