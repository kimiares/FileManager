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
        
        public string FullName { get; set; }
        
        public string Name { get; set; }
                
        public DateTime CreationTime { get; set; }
        
    }
}
