using DataStructures.HashTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructuresAlgorithms.Tests
{
    public static class Cfg
    {
        public const string SEP = "\n=================== ";
    }

    public class Program
    {
        public const string SEP = "\n=================== ";

        public void Main(string[] args)
        {
        }

        static private void UsingCLRDataStructure(string data_fp)
        {
            

        System.Collections.Hashtable map = new System.Collections.Hashtable();
            try
            {
                using (StreamReader sr = new StreamReader(
                    new FileStream(data_fp, FileMode.Open)))
                {
                    string line, studentId, studentName;

                    Console.WriteLine("{0}Filling data structure", SEP);
                    while ((line = sr.ReadLine()) != null)
                    {
                        studentId = line.Split(',')[0];
                        studentName = line.Split(',')[1];
                        try
                        {
                            map.Add(studentId, studentName);
                        }
                        catch
                        {
                            Console.WriteLine("An element with key {0} already exists", studentId);
                        }
                        Console.WriteLine("StudentId: {0}, StudentName: {1}", studentId, studentName);
                    }
                }
            }
            catch
            {
                Console.WriteLine("The file {0} could not be read", data_fp);
                return;
            }

            Console.WriteLine("{0}Retrieving some key/values", SEP);
            string[] someKeys = { "jb8uhd", "93fb456" };
            foreach (string someKey in someKeys)
            {
                Console.WriteLine("StudentId: {0}, StudentName: {1}", someKey, map[someKey]);
            }

            Console.WriteLine("{0}Iterating", SEP);
            foreach (DictionaryEntry de in map)
            {
                Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
            }
            Console.ReadLine();
        }

        static private void UsingCustomDataStructure(string data_fp)
        {
            HashTableLinkedList<string, string> map = new HashTableLinkedList<string, string>();
            try
            {
                using (StreamReader sr = new StreamReader(
                    new FileStream(data_fp, FileMode.Open)))
                {
                    string line, studentId, studentName;

                    Console.WriteLine("{0}Filling data structure", SEP);
                    while ((line = sr.ReadLine()) != null)
                    {
                        studentId = line.Split(',')[0];
                        studentName = line.Split(',')[1];
                        try
                        {
                            map[studentId] = studentName;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("An element with key {0} already exists", studentId);
                        }
                        Console.WriteLine("StudentId: {0}, StudentName: {1}", studentId, studentName);
                    }
                }
            }
            catch
            {
                Console.WriteLine("The file {0} could not be read", data_fp);
                return;
            }

            Console.WriteLine("{0}Retrieving some key/values", SEP);
            string[] someKeys = { "jb8uhd", "93fb456" };
            foreach (string someKey in someKeys)
            {
                Console.WriteLine("StudentId: {0}, StudentName: {1}", someKey, map[someKey]);
            }

            Console.WriteLine("{0}Retrieving after reassignment and removal", SEP);
            map.Reassign(someKeys[0], "new reassigned value not originally in data file");
            map.Remove(someKeys[1]);
            foreach (string someKey in someKeys)
            {
                try
                {
                    Console.WriteLine("StudentId: {0}, StudentName: {1}", someKey, map[someKey]);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("There is no key: {0}", someKey);
                }
            }

            //Console.WriteLine("{0}Iterating", SEP);
            //foreach (DictionaryEntry de in map)
            //{
            //    Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
            //}
            Console.ReadLine();
        }

    }


}
