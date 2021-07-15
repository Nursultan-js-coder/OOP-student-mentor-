using System;
using System.Reflection;
using System.Collections.Generic;
namespace task_4
{
    // 4.3
    public class CompareByName : IComparer<Student>
    {
        public int Compare(Student st1,Student st2)
        {
            return st1.Name.CompareTo(st2.Name);
        }

    }
    public class CompareByGrade : IComparer<Student>
    {
        public int Compare(Student st1,Student st2)
        {
            return st1.Grade.CompareTo(st2.Grade);
        }

    }
    public class CompareByCollege : IComparer<Student>
    {
        public int Compare(Student st1,Student st2)
        {
            return st1.College.CompareTo(st2.College);
        }

    }
    public class CompareByAddress : IComparer<Student>
    {
        public int Compare(Student st1,Student st2)
        {
            return st1.Address.CompareTo(st2.Address);
        }

    }
    public class CompareById : IComparer<Student>
    {
        public int Compare(Student st1,Student st2)
        {
            return st1.Id.CompareTo(st2.Id);
        }

    }
    public class Student:Person,IPrintable
    {

        public string College { get; set; }
        public int Grade { set; get; }
        
        public Student()
        {
        }
        public Student(string college,int grade, int id, string name, string bd, string address):base( id,  name,  bd,  address)
        {
            College = college;
            Grade = grade;
        }

        public void PrintKeys()
        {
            List<string> keys = new List<string>();
            foreach (PropertyInfo pinfo in this.GetType().GetProperties())
            {
                keys.Add(pinfo.Name);
            }
            keys.Add("Advisor");
            Table.PrintLine();
            Table.PrintRow(keys.ToArray());
            

        }
        public void Print(Teacher teacher)
        {
            List<string> values = new List<string>();
            foreach (PropertyInfo pinfo in this.GetType().GetProperties())
            {
                values.Add(pinfo.GetValue(this).ToString());
            }
            values.Add(teacher.Name);
            Table.PrintLine();
            Table.PrintRow(values.ToArray());

        }
        //public int CompareTo(Student other)
        //{
        //    return this.Name.CompareTo(other.Name);
        //}
        


    }
}
