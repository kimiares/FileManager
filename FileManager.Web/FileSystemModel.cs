using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace FileManager.Web
{
    [JsonObject(MemberSerialization.OptOut)]
    public class FileSystemModel
    {
        [Key]
        public int Id { get; set; }
        //[JsonProperty("fullName")]
        public string FullName { get; set; }
        //[JsonProperty("name")]
        public string Name { get; set; }
        //[JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }
        
    }
}
