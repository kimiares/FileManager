using FileManager.Drawing;
using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commander
{
    /// <summary>
    /// настройки для запуска
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// PanelHeight
        /// </summary>
        public int PanelHeight { get; } = Console.WindowHeight;
        /// <summary>
        /// PanelWidth
        /// </summary>
        public int PanelWidth { get; } = Console.WindowWidth;
        /// <summary>
        /// Default TextColor
        /// </summary>
        public ConsoleColor TextColor { get; set; } = ConsoleColor.White;
        /// <summary>
        /// Default BackColor
        /// </summary>
        public ConsoleColor BackColor { get; set; } = ConsoleColor.Blue;
        /// <summary>
        /// Default path of right panel
        /// </summary>
        public string PathRight { get; set; } = DriveInfo.GetDrives()[0]?.Name;
        /// <summary>
        /// Default path of left panel
        /// </summary>
        public string PathLeft { get; set; } = DriveInfo.GetDrives()[0]?.Name;
        /// <summary>
        /// Left Upper coordinate X for left panel
        /// </summary>
        public int ALX { get; } = 0;
        /// <summary>
        /// Left Upper coordinate Y for left panel
        /// </summary>
        public int ALY { get; } = 0;
        /// <summary>
        /// Right Bottom coordinate X for left panel
        /// </summary>
        public int BLX { get; } = Console.WindowWidth / 2 - 1;
        /// <summary>
        /// Right Bottom coordinate Y for left panel
        /// </summary>
        public int BLY { get; } = Console.WindowHeight - 4;
        /// <summary>
        /// Left Upper coordinate X for right panel
        /// </summary>
        public int ARX { get; } = Console.WindowWidth / 2 + 1;
        /// <summary>
        /// Left Upper coordinate Y for right panel
        /// </summary>
        public int ARY { get; } = 0;
        /// <summary>
        /// Right Bottom coordinate X for right panel
        /// </summary>
        public int BRX { get; } = Console.WindowWidth - 1;
        /// <summary>
        /// Right Bottom coordinate Y for right panel
        /// </summary>
        public int BRY { get; } = Console.WindowHeight - 4;
        /// <summary>
        /// Active Panel
        /// </summary>
        public bool ActivePanel { get; set; } = false;
        /// <summary>
        /// ViewMode Left Panel
        /// 1 - one column
        /// 2 - three columns
        /// 3 - three columns as one
        /// </summary>
        public int ViewModeLeftPanel { get; set; } = 3;
        /// <summary>
        /// ViewMode Right Panel
        /// 1 - one column
        /// 2 - three columns
        /// 3 - three columns as one
        /// </summary>
        public int ViewModeRightPanel { get; set; } = 3;


    }
}