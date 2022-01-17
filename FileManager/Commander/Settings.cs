using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace FileManager.Commander
{
    public class Settings
    {
        public static Settings Instance()
        {
            _instance = _instance ?? new Settings();

                return _instance;

        }
        public Configuration Sets;

        protected Settings()
        {
            Sets = new Configuration();
                if (File.Exists("settings.xml"))
                    Sets = LoadSettings();
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

        public int ColumnCountLeft { get; set; } = 3;
        public int ColumnCountRight { get; set; } = 3;
        public int ColumnWidthLeft { get; set; }
        public int ColumnWidthRight { get; set; }

        private void InizialiseParams()
        {
            MaxElementsColumn = Sets.PanelHeight - 3;
            if (Sets.ViewModeLeftPanel == 1) ColumnCountLeft = 1;
            if (Sets.ViewModeRightPanel == 1) ColumnCountRight = 1;
            ColumnWidthLeft = Sets.PanelWidth / ColumnCountLeft;
            ColumnWidthRight = Sets.PanelWidth / ColumnCountRight;
        }


        private static Settings _instance = null;

        /// <summary>
        /// Save settings to xml file 
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Configuration));
                using (FileStream fs = new FileStream("settings.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Sets);
                }
            }
            catch
            { 
            
            }
        }
        /// <summary>
        /// Load settings from xml file
        /// </summary>
        /// <returns></returns>
        public Configuration LoadSettings()
        {
            try
            {
                Configuration NewConfigSettings = new Configuration();
                XmlSerializer formatter = new XmlSerializer(typeof(Configuration));
                using (FileStream fs = new FileStream("settings.xml", FileMode.Open))
                {
                    NewConfigSettings = (Configuration)formatter.Deserialize(fs);
                }
                return NewConfigSettings;
            }
            catch
            {
                throw new FileLoadException();
            }
        }
    }
}