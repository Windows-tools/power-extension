using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string localRepoFolder = @"C:\Users\Rajesh\Desktop\git_sample";
            string dest_path = @"C:\Users\Rajesh\Desktop\rep";


            var c = PowerCore.Library.Git.git_diff_Status_files_copy(localRepoFolder );



          //  Console.ReadKey();

        }
    }
}
