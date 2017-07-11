using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialize_practice
{
    [Serializable]
    public class Person
    {
        private string name;
        private DateTime birthDate;
        public enum Genders { Male, Female };

        public Person() { }

        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Birth date: {1}", this.name, this.birthDate);
        }
    }
}
