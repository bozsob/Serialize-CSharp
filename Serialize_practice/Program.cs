using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace Serialize_practice
{
    class Program
    {
        private static void Serialize(Person sp)
        {
            FileStream fs = new FileStream("Person.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(fs, sp);

            fs.Close();
        }

        private static Person Deserialize()
        {
            Person personDeserialized = new Person();

            // Open file to read the data from
            FileStream fs = new FileStream("Person.dat", FileMode.Open);

            // Create a BinaryFormatter object to perform the deserialization 
            BinaryFormatter bFormatter = new BinaryFormatter();

            // Use the BinaryFormatter object to deserialize the data from the file 
            personDeserialized = (Person) bFormatter.Deserialize(fs);

            // Close the file 
            fs.Close();

            return personDeserialized;
        }

        static void Main(string[] args)
        {
            /*
            string data = "This must be stored in a file...";
            FileStream fs = new FileStream("SerializedString.txt", FileMode.Create);

            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fs, data);

            fs.Close();
            */

            // serialize a Person object
            Person person = new Person("Tony", new DateTime(1923, 4, 22));
            Serialize(person);
            Debug.WriteLine("File created.");

            // deserialize a Person object
            Debug.WriteLine(Deserialize());            
        }
    }
}
