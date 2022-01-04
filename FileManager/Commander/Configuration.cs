using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commander
{
    /// <summary>
    /// настройки для запуска
    /// </summary>
    class Configuration
    {
        public Point Start { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public ConsoleColor FontColor { get; set; }
        public ConsoleColor BackColor { get; set; }
        public int ColumnCount { get; set; }


    }
}
