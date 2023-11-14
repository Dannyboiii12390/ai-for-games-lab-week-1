using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public class JSONFileHandler<T>
    {
        string path;

        public JSONFileHandler(string pPath)
        {
            path = pPath;


        }
        public List<T> Read()
        {
            List<T> values = new List<T>();
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                values = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return values;

        }
        public void Write(List<T> values) 
        { 
            using(StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, values);
            }
        
        }


    }
}
