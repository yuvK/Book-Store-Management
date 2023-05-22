using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;

namespace StoreManager
{
    public class SaveLoadLogic<T>
    {
        private StorageFolder _folder;
        private string _path;
        public SaveLoadLogic(string DataName)
        {
            _folder = ApplicationData.Current.LocalFolder;
            _path = Path.Combine(_folder.Path, DataName);

            if (!File.Exists(_path))
            {
                using (FileStream file = new FileStream(_path, FileMode.Create))
                {
                    
                }
            }
        }
        public void SaveData(object data)
        {
            string UpdatedList = ObjectToJson(data);
            WriteFile(UpdatedList);
        }

        private void WriteFile(string data)
        {
            using(StreamWriter sw = new StreamWriter(_path))
            {
                sw.Write(data);
            }
        }

        private string ObjectToJson(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
        public List<T> LoadData()
        {
            try
            {
                string strConvert = File.ReadAllText(_path);
                List<T> data = JsonConvert.DeserializeObject<List<T>>(strConvert, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                });
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
