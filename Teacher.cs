using System;
using System.Reflection;
using System.Collections.Generic;
namespace task_4
{
    public class Teacher : Person,IPrintable
    {
        public string College { get; set; }


        public Teacher()
        {
        }
        public Teacher(string college, int id, string name, string bd, string address) : base(id, name, bd, address)
        {
            College = college;
        }
        public void PrintKeys()
        {
            List<string> keys = new List<string>();
            foreach (PropertyInfo pinfo in this.GetType().GetProperties())
            {
                keys.Add(pinfo.Name);
            }
            Table.PrintLine();
            Table.PrintRow(keys.ToArray());


        }
        public void Print()
        {
            List<string> values = new List<string>();
            foreach (PropertyInfo pinfo in this.GetType().GetProperties())
            {
                values.Add(pinfo.GetValue(this).ToString());
            }
            Table.PrintLine();
            Table.PrintRow(values.ToArray());

        }

    }
}
