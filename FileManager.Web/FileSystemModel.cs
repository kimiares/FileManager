using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web
{
    [JsonObject(MemberSerialization.OptOut)]
    public class FileSystemModel
    {
        //[JsonProperty("fullName")]
        public string FullName { get; set; }
        //[JsonProperty("name")]
        public string Name { get; set; }
        //[JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }
        
    }
}
