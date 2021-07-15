using System;
using System.Collections.Generic;
namespace task_4
{
   public class StudentWithAdvisor { 
        public static Dictionary<string, Teacher> teachers;
        public static Dictionary<string, Student> students;
        public static Dictionary<Student, Teacher> StudentWithTeacherData;
        public static Dictionary<Teacher, List<Student>> TeacherWithStudentData;
        public StudentWithAdvisor()
        {
            StudentWithTeacherData=new Dictionary<Student, Teacher>();
            TeacherWithStudentData = new Dictionary<Teacher, List<Student>>();
            teachers = new Dictionary<string, Teacher>();
            students = new Dictionary<string, Student>();

        }
    public static void Add(Student st,Teacher teacher)
        {
            teachers[teacher.Name] = teacher;
            students[st.Name] = st;
            List<Student> temp;
            TeacherWithStudentData.TryGetValue(teacher, out temp);
            if (temp==null )
            {
                TeacherWithStudentData[teacher] = new List<Student>();
                TeacherWithStudentData[teacher].Add(st);
            }
            else
                TeacherWithStudentData[teacher].Add(st);

            StudentWithTeacherData[st] = teacher;
           
               
        }
        public static Teacher Get(Student st)
        {
            return StudentWithTeacherData[st];
        }
       
        

    }
}
