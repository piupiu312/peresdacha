using System;
using System.Collections.Generic;
using System.Text;

namespace n6
{
    public class Model
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public Model()
        {

        }
        public Model(string name, int age, string description)
        {
            Name = name;
            Age = age;
            Description = description;
        }
    }
}
