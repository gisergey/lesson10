using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson10
{
    class Student
    {
        public Student(string name,string group)
        {
            this.name = name;
            this.group = group;
        }
        private string name;
        private string group;
        private int lucky=3;

        public int Lucky
        {
            get { return lucky; }
            set { lucky = value; }
        }

        public string Name { get { return name; } }
        public string Group { get { return group; } }
        public void Information()
        {
            Console.WriteLine(name + "  " + group);
        }
        public string Info()
        {
            return name + " ; " + group;
        }
    }
}
