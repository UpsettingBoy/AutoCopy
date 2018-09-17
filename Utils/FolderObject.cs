// Copyright (c) 2018 UpsettingBoy (Jerónimo Sánchez)
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.IO;
using Newtonsoft.Json;

namespace AutoCopy.Utils
{
    class FolderObject
    {
        public string Folder2Copy {get; set;}
        public string CopyLocation {get; set;}
        public int CopyInterval {get; set;}
        public void Serialize(string location)
        {
            File.WriteAllText(location, JsonConvert.SerializeObject(this));
        }
        public static FolderObject Deserialize(string file)
        {
            return JsonConvert.DeserializeObject<FolderObject>(File.ReadAllText(file));
        }
    }
}