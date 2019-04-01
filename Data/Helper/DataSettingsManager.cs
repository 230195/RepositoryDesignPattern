using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace Data.Helper
{
    public class DataSettings
    {
        public string DataConnectionString { get; set; }
    }
    class DataSettingsManager
    {
        private const string _dataSettingsFilePath = "App_Data/DataSettings.json";
        public virtual DataSettings LoadSettings()
        {
            try
            {
                var text = File.ReadAllText(_dataSettingsFilePath);
                if (string.IsNullOrEmpty(text))
                    return new DataSettings();

                //get data settings from the JSON file  
                DataSettings settings = JsonConvert.DeserializeObject<DataSettings>(text);
                return settings;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
