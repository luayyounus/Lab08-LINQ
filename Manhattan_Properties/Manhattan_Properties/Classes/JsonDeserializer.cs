﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Manhattan_Properties.Classes
{
    internal class JsonDeserializer
    {
        private RootObject ReadJson()
        {
            string path = "data.json";
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

        public IEnumerable<Feature> GetAllNeighborhoods()
        {
            RootObject rootObject = ReadJson();
            IEnumerable<Feature> allNeighborhoods =
                from obj in rootObject.Features where obj.Properties.Neighborhood != null select obj;
            return allNeighborhoods;
        }
    }
}
