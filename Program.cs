// Copyright (c) 2018 UpsettingBoy (Jerónimo Sánchez)
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using AutoCopy.Utils;

namespace AutoCopy
{
    class Program
    {
        static void Main(string[] args)
        {
           ProgramFlow();
        }

        static void ProgramFlow()
        {
            Console.WriteLine("Welcome to AutoCopy :) !");
            new ProfileFolder();
            Console.WriteLine("Create new profile(y/n)");
            string ans = Console.ReadLine();
            if(ans == "y" || ans == "Y")
                ProfileFolder.CreateProfile();                
            FolderObject obj = ProfileFolder.SelectProfile();
            Console.WriteLine("Pulse intro to close");
            new CopyLog(obj);
            Console.ReadLine();
        }
    }
}
