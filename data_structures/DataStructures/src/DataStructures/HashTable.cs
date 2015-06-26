using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public static class Program
    {

        static internal void Main(string data_fp)
        {
            Console.WriteLine(data_fp);
            try
            {
                using (StreamReader sr = new StreamReader(data_fp))
                {
                    string line, studentId, studentName;
                    while ((line = sr.ReadLine()) != null)
                    {
                        studentId = line.Split(',')[0];
                        studentName = line.Split(',')[1];
                        Console.WriteLine("StudentId: {0}, StudentName: {1}", studentId, studentName);
                    }
                }
            }
            catch
            {
                Console.WriteLine("The file {0} could not be read", data_fp);
            }
            Console.ReadLine();
        }
    }
}
