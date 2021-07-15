


using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;


namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            FileHandling<Student> studentFileHandling = new FileHandling<Student>("students.json");
            FileHandling<Teacher> teacherFileHandling = new FileHandling<Teacher>("teachers.json");
            students = studentFileHandling.GetData();
            teachers = teacherFileHandling.GetData();
            StudentWithAdvisor studentWithAdvisor = new StudentWithAdvisor();
            List<int> slot = new List<int>(students.Count);
            Random rnd = new Random();
            //studentWithAdvisor;
            Table table = new Table();
            int position = 0;

            //Dictionary<Teacher, string> t_list = new Dictionary<Teacher, string>();
            List<Teacher> t_list = new List<Teacher>();
            List<Student> s_list = new List<Student>();
            foreach (Teacher teacher in teachers)
            {

                for (int i = position, count = 0; count < 20 && i < students.Count; i++, count++)
                {
                    StudentWithAdvisor.Add(students[i], teacher);
                    t_list.Add(teacher);
                    s_list.Add(students[i]);
                    position++;
                }
                position += 20;
            }
            Student[] s_list_array = s_list.ToArray();
            People<Student> people = new People<Student>(s_list_array);
            WriteLine("Persons in Class People:");
            bool flag = false;
            Array.Sort(s_list_array, new CompareByName());
             //4.2 ICompareable 
             //4.6 INumerable
             //
            People<Student> numerable = new People<Student>(s_list_array);
            WriteLine("List of students sorted by Name: ");
            foreach (Student person in numerable)
            {
                if (!flag)
                {
                    person.PrintKeys();
                    flag = !flag;
                }
               // 4.1 IPrintable
                person.Print(StudentWithAdvisor.Get(person));
            }


            Read();





            Table.PrintLine();
            while (true)
            {
                Clear();
                ForegroundColor = ConsoleColor.Yellow;
                Table.PrintLine();
                Table.PrintRow("Data Base Administration Center");
                Table.PrintLine();
                Table.PrintRow("enter data:", "            ");
                Table.PrintLine();
                SetCursorPosition(105, 3);

                string input = ReadLine();

switch (input.Split("|")[1])
                {
                    case "teacher":
                        Teacher teacher = StudentWithAdvisor.teachers[input.Split("|")[0]];

                        SetCursorPosition(0, 4);
                        ForegroundColor = ConsoleColor.White;
                        Table.PrintLine();
                        Table.PrintRow("students of teacher :", $"{teacher.Name}");
                        Table.PrintLine();

                        if (StudentWithAdvisor.TeacherWithStudentData[teacher].Count > 0)
                        {
                            StudentWithAdvisor.TeacherWithStudentData[teacher].First().PrintKeys();

                            foreach (Student st in StudentWithAdvisor.TeacherWithStudentData[teacher])
                            {

                                st.Print(teacher);

                            }
                        }

                        break;
                    case "student":



                        Student student = StudentWithAdvisor.students[input.Split("|")[0]];

                        Teacher advisor = StudentWithAdvisor.StudentWithTeacherData[student];
                        SetCursorPosition(0, 4);
                        ForegroundColor = ConsoleColor.White;
                        Table.PrintLine();
                        Table.PrintRow($"Advisor of student : {student.Name}");
                        Table.PrintLine();
                        advisor.PrintKeys();
                        Table.PrintLine();
                        advisor.Print();





                        break;
                }
                // 4.5 IDisposable 
                //using (Student st=new Student("asfasf", 1, 2, "sdfs", "sdfs", "sds"))
                //{
                //    WriteLine(st.Name);
                //}
                //IEnumerable<int> nums = from item in Enumerable.Range(70, 100) select item;
                //var arr = nums.ToArray();
                //(int, int) minItem = MinIndex<int>(arr);
                //Console.WriteLine($"index: {minItem.Item1},minItem:{minItem.Item2}");
                ReadKey();

            }

        }
        /// 4.7. 
        static (int,K) MinIndex<K>(K[] arr) where K :   IComparable<K>, new()
        {
            (int, K) minItem;
            minItem.Item1 = 0;
            minItem.Item2 = arr[0];
            for(var i = 0; i < arr.Length; i++)
            {
               
                    if(minItem.Item2.CompareTo(arr[i])==1)
                    {
                        minItem.Item1 = i;
                        minItem.Item2 = arr[i];
                    }
                
            }
            return minItem;
            
        }
       
    }
}
