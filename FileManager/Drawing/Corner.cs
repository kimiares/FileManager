using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Drawing
{
    class Corner : IDrawing
    {
        /// <summary>
        /// all chars are getting from "╚╝╗╔╦╩"
        /// </summary>
       // public string Corners { get; set; }
        public static string Corners = "╔╗╝╚";

        public static string TCorners = "╦╩";
        public Corner()
        {

        }
        public void Draw()
        {
            throw new NotImplementedException();
        }
        public void CalculateCorners()
        {
            throw new NotImplementedException();
        }
    }
}
