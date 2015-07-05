using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.AssociativeArray;

namespace DataStructures.HashTable
{
    internal interface IHashTable<TKey, TValue> : IAssociativeArray<TKey, TValue>
    {
    }

    // Handles collisions by separate chaining. Each array element is another structure that holds the values.
    public class HashTableLinkedList<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private const int TABLE_SIZE = 137;
        private LinkedList<TValue>[] table = new LinkedList<TValue>[TABLE_SIZE];

        public HashTableLinkedList()
        {
            for(int i = 0; i < table.Length; i++)
            {
                table[i] = new LinkedList<TValue>();
            }
        }

        public void Add(TKey key, TValue value)
        {
            table[HashKey(key)].AddLast(value);
        }

        private int HashKey(TKey key)
        {
            var _key = key as string;
            if (_key != null)
                return HashStringKey(_key);

            try
            {
                int intKey = (int)(object)key;
                return HashIntKey(intKey);
            }
            catch
            {
                throw new NotImplementedException("Only keys of type string or int work!");
            }

        }

        private int HashIntKey(int intKey)
        {
            throw new NotImplementedException();
        }

        private int HashStringKey(string key)
        {
            int H = 37, total = 0;
            foreach (char c in key)
            {
                total += H * total + c;
            }
            total %= TABLE_SIZE;
            if (total < 0)
            {
                total += TABLE_SIZE - 1;
            }
            return total;
        }

        public void Reassign(TKey key, TValue value)
        {
            int hashKey = HashKey(key);
            switch (table[hashKey].Count) {
                case 0:
                    // value wasn't there, storing for first time.
                    // Equivalent to Add.
                    table[hashKey].AddLast(value);
                    break;
                case 1:
                    // previous value was here, replacing with new.
                    table[hashKey].RemoveLast();
                    table[hashKey].AddLast(value);
                    break;
                default:
                    throw new NotImplementedException("Reassignment in a bucket that handles collision not implemented");
            }
        }

        public void Remove(TKey key)
        {
            int hashKey = HashKey(key);
            switch (table[hashKey].Count)
            {
                case 0:
                    // no value with this key, nothing happens.
                    break;
                case 1:
                    // value found, removing it.
                    table[hashKey].RemoveLast();
                    break;
                default:
                    throw new NotImplementedException("Removing with collision not implemented");
            }
        }

        public TValue Lookup(TKey key)
        {
            int hashKey = HashKey(key);
            switch (table[hashKey].Count)
            {
                case 0:
                    throw new KeyNotFoundException("No value with key: " + key.ToString());
                case 1:
                    return table[hashKey].Last.Value;
                default:
                    throw new NotImplementedException("Removing with collision not implemented");
            }
        }

        // Indexing.
        public TValue this[TKey key]
        {
            get
            {
                return Lookup(key);
            }
            set
            {
                Reassign(key, value);
            }
        }
    }

    public static class Program
    {
        const string SEP = "\n=================== ";

        static internal void Main(string data_fp)
        {
            //UsingCLRDataStructure(data_fp);
            UsingCustomDataStructure(data_fp);
        }

        static private void UsingCLRDataStructure(string data_fp)
        {
            Hashtable map = new Hashtable();
            try
            {
                using (StreamReader sr = new StreamReader(data_fp))
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
                using (StreamReader sr = new StreamReader(data_fp))
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
                        catch(Exception e)
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
