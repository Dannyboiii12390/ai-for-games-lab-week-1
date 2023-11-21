using MonoGameLib.Utilities.File_Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoGameLib.FileHandlers
{
    public class JSONFileHandler<T> : FileHandler<T>
    {
        public JSONFileHandler(string pPath) : base(pPath)
        {

        }

        public override List<T> Read()
        {
            List<T> values = new List<T>();
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                values = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return values;

        }
        public override void Write(List<T> values) 
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
