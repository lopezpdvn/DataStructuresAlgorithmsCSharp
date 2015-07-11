using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class Cfg
    {
        public const string SEP = "\n=================== ";
    }

    public class Program
    {
        public void Main(string[] args)
        {
            string datafile_path = args[0];
            Tree.Program.TestHeight();
            Console.Read();
        }
    }
}