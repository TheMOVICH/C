using System;
using BusinessLayer;
using System.Collections.Generic;

namespace PresentationLayer
{
    public class Menu
    {
        public static void PrintAll<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                if (typeof(T).Name == "Test")
                {
                    Console.WriteLine("Test list is empty");
                }
                if (typeof(T).Name == "Question")
                {
                    Console.WriteLine("Question list is empty");
                }
                if (typeof(T).Name == "Answer")
                {
                    Console.WriteLine("Answer list is empty");
                }

            }
            else
            {
                int i = 1;
                Console.WriteLine("-----------------------------------------------");
                foreach (var item in list)
                {
                        Console.WriteLine(i++ + ". " + item);
                    Console.WriteLine("-----------------------------------------------");
                    
                }
            }
            Console.ReadLine();
        }
        public static int GetId<T>()
        {
            Console.WriteLine("Enter id of " + typeof(T).Name + " you want to choose.");
            int id = Int32.Parse(Console.ReadLine());
            Console.Clear();
            return id-1;
        }       
        public static int CRUDMenu<T>()
        {
            string replace = typeof(T).Name.ToLower();
            while (true)
            {
                
                Console.WriteLine("Select what you want to do");
                Console.WriteLine("1 - Create new " + replace);
                Console.WriteLine("2 - Change existing " + replace);
                Console.WriteLine("3 - View " + replace+"s");
                Console.WriteLine("4 - Delete "+replace);
                Console.WriteLine("5 - Go to the main menu");
                int crud_choice = 0;
                try
                {
                    crud_choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter valid data.");
                    Console.ReadLine();
                    continue;
                }
                return crud_choice;
            }
           
            
        }
        public static int AttibutesChooseToChange<T>()
        {
            string replace = typeof(T).Name;
            while (true)
            {
                Console.WriteLine("Select what you want to do");
                if (replace == "Group")
                {
                    Console.WriteLine("1 - Change group name");
                    Console.WriteLine("2 - Work with students");
                    Console.WriteLine("3 - Add discipline");
                    Console.WriteLine("4 - View list of all students");
                    Console.WriteLine("5 - View students` academic performance");
                    Console.WriteLine("6 - Go to the main menu");
                }
                if (replace == "Student")
                {
                    Console.WriteLine("1 - Change first name ");
                    Console.WriteLine("2 - Change last name");
                    Console.WriteLine("3 - Change student ID");
                    Console.WriteLine("4 - Change perfomance");
                    Console.WriteLine("5 - Go to the main menu");
                }
                if (replace == "Discipline")
                {
                    Console.WriteLine("1 - Add points to student");
                    Console.WriteLine("2 - View student grades ");
                    Console.WriteLine("2 - Go to the main menu");
                }
                int attribut_choice = 0;
                try
                {
                    attribut_choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter valid data.");
                    Console.ReadLine();
                    continue;
                }
                return attribut_choice;
            }


        }
        public static void Run() 
        {
            EntityService entityService = new EntityService();

            bool flag = true;
            while (flag)
            {
                try
                {

                    while (flag)
                    {
                        entityService.SaveInFile();
                        Console.Clear();
                        Console.WriteLine("Select what you want to do");
                        Console.WriteLine("1 - Work with groups");
                        Console.WriteLine("2 - Search");
                        Console.WriteLine("3 - Stop program");                       
                        int menu_choice = 0;
                        try
                        {
                            menu_choice = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Please enter valid data. Press any button to contienue");
                            Console.ReadLine();
                            continue;
                        }
                        switch (menu_choice)
                        {
                            case 1:
                                {
                                    int work_with_groups_choice = CRUDMenu<Group>();
                                    switch (work_with_groups_choice)
                                    {
                                        case 1:
                                            {
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter group name. As in the example (SE-127)");
                                                    string group_name = Console.ReadLine();                                                    
                                                    try
                                                    {
                                                        Group group = new Group(group_name);
                                                        entityService.AddGroup(group);
                                                        break;
                                                    }
                                                    catch (ArgumentException e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                        Console.ReadLine();
                                                        continue;
                                                    }
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                PrintAll<Group>(entityService.GroupList);
                                                int group_menu_choive = AttibutesChooseToChange<Group>();
                                                int group_index = GetId<Group>();
                                                switch (group_menu_choive)
                                                {
                                                    case 1:
                                                        {
                                                            Group group = entityService.GetGroupByIndex(group_index);
                                                            Console.WriteLine("Enter new name for a group");
                                                            string new_group_name = Console.ReadLine();
                                                            group.Name = new_group_name;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            int student_crud_choice = CRUDMenu<Student>();
                                                            switch (student_crud_choice)
                                                            {
                                                                case 1:
                                                                    {
                                                                        Console.WriteLine("Enter student first name");
                                                                        string student_firstname = Console.ReadLine();
                                                                        Console.WriteLine("Enter student last name");
                                                                        string student_lastname = Console.ReadLine();
                                                                        Console.WriteLine("Enter student ID");
                                                                        string student_ID = Console.ReadLine();
                                                                        Student student = new Student(student_firstname,student_lastname,student_ID);
                                                                        entityService.AddStudent(group_index, student);
                                                                        break;
                                                                    }
                                                                case 2:
                                                                    {
                                                                        Group group = entityService.GetGroupByIndex(group_index);
                                                                        PrintAll<Student>(group.StudentsList);
                                                                        int student_index = GetId<Student>();
                                                                        int attribute_student_choice = AttibutesChooseToChange<Student>();
                                                                        Student student = entityService.GetStudentByIndex(group_index, student_index);
                                                                        switch (attribute_student_choice)
                                                                        {
                                                                            case 1:
                                                                                {
                                                                                    Console.WriteLine("Please enter new student first name");
                                                                                    string first_name = Console.ReadLine();
                                                                                    student.FirstName = first_name;
                                                                                    break;
                                                                                }
                                                                            case 2:
                                                                                {
                                                                                    Console.WriteLine("Please enter new student last name");
                                                                                    string last_name = Console.ReadLine();
                                                                                    student.LastName = last_name;
                                                                                    break;
                                                                                }
                                                                            case 3:
                                                                                {
                                                                                    Console.WriteLine("Please enter new student ID");
                                                                                    string student_ID = Console.ReadLine();
                                                                                    student.StudentID = student_ID;
                                                                                    break;
                                                                                }
                                                                            case 4:
                                                                                {                                                                                    
                                                                                    int discipline_crud = CRUDMenu<Discipline>();
                                                                                    switch (discipline_crud)
                                                                                    {
                                                                                        case 1:
                                                                                            {
                                                                                                Console.WriteLine("Type title of the discipline");
                                                                                                string title = Console.ReadLine();
                                                                                                Discipline discipline = new Discipline(title);
                                                                                                student.DisciplinesList.Add(discipline);
                                                                                                break;
                                                                                            }
                                                                                        case 2:
                                                                                            {
                                                                                                PrintAll<Discipline>(student.DisciplinesList);
                                                                                                int discipline_index = GetId<Discipline>();
                                                                                                Discipline discipline = student.DisciplinesList[discipline_index];
                                                                                                int attribute_discipline = AttibutesChooseToChange<Discipline>();
                                                                                                if (attribute_discipline==1)
                                                                                                {
                                                                                                    Console.WriteLine("Here is student point on this discipline");
                                                                                                    Console.WriteLine(discipline);
                                                                                                    Console.WriteLine("Type new point to add to student's points");
                                                                                                    int point = Int32.Parse(Console.ReadLine());
                                                                                                    discipline.GradesList.Add(point);
                                                                                                }
                                                                                                if (attribute_discipline == 2)
                                                                                                {
                                                                                                    Console.WriteLine("Student grades for discipline");
                                                                                                    Console.WriteLine(discipline + discipline.ToStringWithGrades());
                                                                                                    Console.ReadLine();
                                                                                                }
                                                                                                break;
                                                                                            }
                                                                                        case 3:
                                                                                            {
                                                                                                Console.WriteLine("Student grades for all disciplines");
                                                                                                foreach (Discipline discipline in student.DisciplinesList)
                                                                                                {
                                                                                                    Console.WriteLine(discipline + discipline.ToStringWithGrades());
                                                                                                }
                                                                                                Console.ReadLine();
                                                                                                break;
                                                                                            }
                                                                                        case 4:
                                                                                            {
                                                                                                PrintAll<Discipline>(student.DisciplinesList);
                                                                                                int discipline_index = GetId<Discipline>();
                                                                                                student.DisciplinesList.RemoveAt(discipline_index);
                                                                                                break;
                                                                                            }
                                                                                    }
                                                                                    break;
                                                                                }
                                                                        }
                                                                        break;
                                                                    }
                                                                case 3:
                                                                    {   int student_index = GetId<Student>();
                                                                        PrintAll<Student>(entityService.GroupList[group_index].StudentsList);
                                                                        break;
                                                                    }
                                                                case 4:
                                                                    {
                                                                        int student_index = GetId<Student>();
                                                                        entityService.RemoveStudent(group_index, student_index);
                                                                        break;
                                                                    }
                                                                case 5:
                                                                    {
                                                                        break;
                                                                    }
                                                            }
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.WriteLine("Type title of the discipline");
                                                            string title = Console.ReadLine();
                                                            Discipline discipline = new Discipline(title);
                                                            entityService.AddDiscipline(group_index,discipline);
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            PrintAll<Group>(entityService.GroupList);
                                                            break;
                                                        }
                                                    case 5:
                                                        {
                                                            Group group = entityService.GetGroupByIndex(group_index);
                                                            Console.WriteLine("Students' avarage grades");
                                                            Console.WriteLine(group.GetStudentsAvarageGrades());
                                                            Console.ReadLine();
                                                            break;
                                                        }
                                                }
                                                break;

                                            }
                                        case 3:
                                            {
                                                PrintAll<Group>(entityService.GroupList);
                                                break;
                                            }
                                        case 4:
                                            {
                                                int group_index = GetId<Group>();
                                                entityService.RemoveGroup(group_index);
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Select how you want to seach");
                                    Console.WriteLine("1 - Search for student by name");
                                    Console.WriteLine("2 - Search for student in some group");
                                    Console.WriteLine("3 - Search by avarage grade");
                                    Console.WriteLine("4 - Go to the menu");
                                    int search_choice = Int32.Parse(Console.ReadLine());
                                    if (search_choice == 1)
                                    {
                                        Console.WriteLine("Please type name or part of name");
                                        string search_str = Console.ReadLine();
                                        List<Student> search_result = entityService.StudentSearchByName(search_str);
                                        if (search_result.Count == 0)
                                        {
                                            Console.WriteLine("The was no students found");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            PrintAll<Student>(search_result);
                                        }
                                    }
                                    if (search_choice == 2)
                                    {
                                        PrintAll<Group>(entityService.GroupList);
                                        int group_index = GetId<Group>();
                                        Group group = entityService.GetGroupByIndex(group_index);
                                        Console.WriteLine("Please type name or part of name");
                                        string search_str = Console.ReadLine();
                                        List<Student> search_result = entityService.StudentSearchInGroupByName(group_index, search_str);
                                        if (search_result.Count == 0)
                                        {
                                            Console.WriteLine("The was no students found");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            PrintAll<Student>(search_result);
                                        }
                                        
                                    }
                                    if (search_choice == 3)
                                    {
                                        Console.WriteLine("Please type avarage grade");
                                        int avarage_grade = Int32.Parse(Console.ReadLine());
                                        List<Student> search_result = entityService.StudentSearchByAvarageGrade(avarage_grade);
                                        if (search_result.Count == 0)
                                        {
                                            Console.WriteLine("The was no students found");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            PrintAll<Student>(search_result);
                                        }
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    flag = false;
                                    break;
                                }                                
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Pleae enter valid data");
                    Console.ReadLine();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Please choose from given example");
                    Console.ReadLine();
                }
                catch (MemberAccessException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
          
        }
    }
}
