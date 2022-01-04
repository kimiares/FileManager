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
    class Configuration
    {
        /// <summary>
        /// Left Upper start point (X,Y)
        /// </summary>
        public Point Start { get; set; }
        /// <summary>
        /// Screen width
        /// </summary>
        public int Width { get; set; }
        public int Heigth { get; set; }
        /// <summary>
        /// Panels textcolor 
        /// </summary>
        public ConsoleColor FontColor { get; set; }
        /// <summary>
        /// Panels backcolor 
        /// </summary>
        public ConsoleColor BackColor { get; set; }
        /// <summary>
        /// Panels count 
        /// </summary>
        public int ColumnCount { get; set; }

        /// <summary>
        /// Save settings to xml file 
        /// </summary>
        public void SaveSettings(Configuration settings)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Configuration));
            using (FileStream fs = new FileStream("settings.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, settings);
            }
        }
        /// <summary>
        /// Load settings from xml file 
        /// </summary>
        public void LoadSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Configuration));
            using (FileStream fs = new FileStream("settings.xml", FileMode.OpenOrCreate))
            {
                Configuration newPerson = (Configuration)formatter.Deserialize(fs);
            }
        }
    }
}
