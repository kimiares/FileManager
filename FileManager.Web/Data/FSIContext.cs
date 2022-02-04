using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Web.Data
{
    public class FSIContext:DbContext
    {
        public DbSet<FileSystemModel> Files { get; set; }
        public FSIContext(DbContextOptions<FSIContext> options) : base(options)
        {
            
        }
    }
}
