using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Serialize_practice
{
    [Serializable]
    public class Person : ISerializable, IDeserializationCallback
    {
        private string name;
        private DateTime birthDate;
        [NonSerialized] public int age;
        public enum Genders { Male, Female };

        public Person() { }

        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        // serialization constructor
        public Person(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info missing");
            }

            name =  info.GetString("Name");
            birthDate = info.GetDateTime("BirthDate");
            CalculateAge(this);
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
            return String.Format("Name: {0}, Birth date: {1}, Age: {2}", 
                this.name, this.birthDate, CalculateAge(this));
        }

        static int CalculateAge(Person p)
        {
            int age = DateTime.Now.Year - p.birthDate.Year;

            if (DateTime.Now.Month < p.birthDate.Month || 
                (DateTime.Now.Month == p.birthDate.Month && DateTime.Now.Day < p.birthDate.Day))
                age = age -1;

            return age;
        }

        void IDeserializationCallback.OnDeserialization(Object sender)
        {
            // after deserialization calculate age by the actual date
            CalculateAge(this);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info");
            }
            info.AddValue("Name", name);
            info.AddValue("BirthDate", birthDate);
        }
    }
}
