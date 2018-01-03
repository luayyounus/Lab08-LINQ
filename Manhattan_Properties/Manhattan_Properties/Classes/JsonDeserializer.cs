using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Manhattan_Properties.Classes
{
    internal class JsonDeserializer
    {
        public RootObject ReadJson(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    RootObject featuresCollection = JsonConvert.DeserializeObject<RootObject>(json);

                    return featuresCollection;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
