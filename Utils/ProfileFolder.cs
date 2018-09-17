// Copyright (c) 2018 UpsettingBoy (Jerónimo Sánchez)
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoCopy.Utils
{
    class ProfileFolder
    {
        static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AutoCopy\";
        static string Profiles = AppData + @"profiles\";
        public ProfileFolder()
        {
            CheckFolder();
            if(GetProfiles().Count < 1)
            {
                Console.WriteLine("There are no profiles, creating first...");
                CreateProfile();
            }
        }
        private void CheckFolder()
        {
            if(!Directory.Exists(AppData))
                Directory.CreateDirectory(AppData);
            if(!Directory.Exists(Profiles))
                Directory.CreateDirectory(Profiles);
        }
        private static List<string> GetProfiles()
        {
            List<string> profiles = new List<string>();
            foreach(var file in Directory.GetFiles(Profiles))
                if(file.Contains(".json"))
                    profiles.Add(file);
            
            return profiles;
        }
        public static FolderObject SelectProfile()
        {
            int i = 1;
            List<string> prof = GetProfiles();
            prof.ForEach(p => Console.WriteLine($"{i++} -> {Path.GetFileNameWithoutExtension(p)}"));
            Console.WriteLine("Select profile(by num)...");
            return FolderObject.Deserialize(prof.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1));
        }
        public static void CreateProfile()
        {
            Console.WriteLine("Introduce profile name...");
            string profile = Profiles + Console.ReadLine() + ".json";
            Console.WriteLine("Introduce folder(path) to copy...");
            string f2copy = Console.ReadLine();
            Console.WriteLine("Introduce copy destination(will be copied inside of this path)...");
            string location = Console.ReadLine();
            Console.WriteLine("Copy interval(in seconds)...");
            int interval = Convert.ToInt32(Console.ReadLine());

            new FolderObject()
            {
                Folder2Copy = f2copy,
                CopyLocation = location,
                CopyInterval = interval
            }.Serialize(profile);

            Console.WriteLine("Profile created successfully");
        }
    }
}