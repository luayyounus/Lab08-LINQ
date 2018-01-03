using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Manhattan_Properties.Classes
{
    internal class JsonDeserializer
    {
        /// <summary>
        /// This is a private method that reads the JSON file making an instance of the Root Object Class.
        /// </summary>
        /// <returns>Returning an instance of Root object with a list of Features</returns>
        private RootObject ReadJson()
        {
            string path = "data.json";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();

                    // Deserializing the json file using NewtonSoft Json tools
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

        /// <summary>
        /// This method reads the json file and apply a LINQ query to retrieve all neighborhoods
        /// </summary>
        /// <returns>Returns all neighborhoods in an IEnumerable generic Collection</returns>
        public IEnumerable<Feature> GetAllNeighborhoods()
        {
            RootObject rootObject = ReadJson();

            IEnumerable<Feature> allNeighborhoods = from obj in rootObject.Features
                                                    where obj.Properties.Neighborhood != null
                                                    select obj;
            return allNeighborhoods;
        }

        /// <summary>
        /// This methods receives a collection of all Neighborhoods and filter them off empty string
        /// </summary>
        /// <param name="allNeighborhoods">A generic collection of all Neighborhoods</param>
        /// <returns>Filtered Neighborhoods without empty strings</returns>
        public IEnumerable<Feature> GetFilteredNeighborhoods(IEnumerable<Feature> allNeighborhoods)
        {
            var filteredNeighborhoods = allNeighborhoods.Where(n => n.Properties.Neighborhood != "");

            return filteredNeighborhoods;
        }

        /// <summary>
        /// This methods uses a query to find the first apperance of every neighborhood and group them into a collection
        /// </summary>
        /// <param name="filteredNeighborhoods">A collection that holds filtered neighborhoods with no empty strings</param>
        /// <returns>Returns a unique apperanaces of every neighborhood</returns>
        public IEnumerable<Feature> GetUniqueNeighborhoods(IEnumerable<Feature> filteredNeighborhoods)
        {
            var uniqueNeighborhoods = filteredNeighborhoods.GroupBy(p => p.Properties.Neighborhood).Select(m => m.First());

            return uniqueNeighborhoods;
        }

        /// <summary>
        /// This method sums up all of the previous LINQ queries into on single quiery to show the power of LINQ
        /// </summary>
        /// <returns>Returns Neighborhoods with no empty strings and no duplicates.</returns>
        public IEnumerable<Feature> AllInOneSingleQuery()
        {
            RootObject rootObject = ReadJson();

            var allInOne = rootObject.Features.Where(j => j.Properties.Neighborhood != "").GroupBy(p => p.Properties.Neighborhood).Select(m => m.First());

            return allInOne;
        }
    }
}
