using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace FileManager.Commander
{
    class Settings
    {
        public static Settings Instance()
        {
            if (_instance == null)
            {
                _instance = new Settings();
                return _instance;
            }
            else
            {
                return null;
            }
        }
        public Configuration Sets;

        protected Settings()
        {
            Sets = File.Exists("settings.xml") ? LoadSettings() : new Configuration();
            SaveSettings();
            InizialiseParams();
        }


        private int maxelementscolumn;
        /// <summary>
        /// Maximum count of elements in column
        /// </summary>
        public int MaxElementsColumn
        {
            get { return maxelementscolumn; }
            set { maxelementscolumn = value; }
        }
        /// <summary>
        /// Additional program settings, calculated on base main settings.  
        /// </summary>
        private void InizialiseParams()
        {
            MaxElementsColumn = Sets.PanelHeight - 2;
        }


        private static Settings _instance = null;

        /// <summary>
        /// Save settings to xml file 
        /// </summary>
        public void SaveSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Configuration));
            using (FileStream fs = new FileStream("settings.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Sets);
            }
        }
        /// <summary>
        /// Load settings from xml file
        /// </summary>
        /// <returns></returns>
        public Configuration LoadSettings()
        {
            Configuration NewConfigSettings = new Configuration();
            XmlSerializer formatter = new XmlSerializer(typeof(Configuration));


            using (FileStream fs = new FileStream("settings.xml", FileMode.OpenOrCreate))
            {
                NewConfigSettings = (Configuration)formatter.Deserialize(fs);
            }
            return NewConfigSettings;
        }
    }
}