// Copyright (c) 2018 UpsettingBoy (Jerónimo Sánchez)
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace AutoCopy.Utils
{
    class CopyLog
    {
        Timer t;
        int i = 1;
        FolderObject obj;
        public CopyLog(FolderObject obj)
        {
            this.obj = obj;
            Console.WriteLine ("Copy thread initilalized!");
            CopyThread();
        }
        private void CopyThread()
        {
            t = new Timer(obj.CopyInterval * 1000);
            t.AutoReset = true;
            Copy(new DirectoryInfo(obj.Folder2Copy), new DirectoryInfo(obj.CopyLocation));;
            t.Elapsed += (sender, e) => 
            {
                Copy(new DirectoryInfo(obj.Folder2Copy), new DirectoryInfo(obj.CopyLocation));
            };
            t.Start();
        }
        private void Copy(DirectoryInfo a, DirectoryInfo b) 
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            DeepCopy(a, b);
            s.Stop();
            Console.WriteLine($"Copy {i++} completed in {(float)s.ElapsedMilliseconds / 1000}s!");
        }
        public static void DeepCopy (DirectoryInfo source, DirectoryInfo target) 
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                DeepCopy(dir, target.CreateSubdirectory (dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine (target.FullName, file.Name), true);
        }
    }
}