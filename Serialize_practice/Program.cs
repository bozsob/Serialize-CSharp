using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        static void Main(string[] args)
        {
            /*
            string data = "This must be stored in a file...";
            FileStream fs = new FileStream("SerializedString.txt", FileMode.Create);

            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fs, data);

            fs.Close();
            */

            Person person = new Person("Tony", new DateTime(1923, 4, 22));
            Serialize(person);
            Console.WriteLine("File created.");
            Console.ReadKey();
        }
    }
}
