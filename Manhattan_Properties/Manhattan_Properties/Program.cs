using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Manhattan_Properties.Classes;

namespace Manhattan_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t Welcome to Manhattan Properties");
            bool showOptions = true;
            while (showOptions)
            {
                showOptions = ShowOptions();
            }
        }

        // Show options for user to pick what to do with the properties
        public static bool ShowOptions()
        {
            Console.WriteLine("\n What do you like to do with our properties?" +
                              "\n 1) Output all of the neighborhoods in this data list" +
                              "\n 2) Filter out all the neighborhoods that do not have any names" +
                              "\n 3) Remove the Duplicates" +
                              "\n 4) Trying all of the above at once!" +
                              "\n 5) Exit");

            string userInput = Console.ReadLine();

            // Creating an instance of the Json Serializer Class
            JsonDeserializer js = new JsonDeserializer();
            RootObject rootObject = js.ReadJson();

            switch (char.Parse(userInput))
            {
                case '1':
                    var result = js.GetAllNeighborhoods(rootObject);
                    PrintProperties(result);
                    return true;
                case '2':
                    var result2 = js.GetFilteredNeighborhoods(js.GetAllNeighborhoods(rootObject));
                    PrintProperties(result2);
                    return true;
                case '3':
                    var result3 = js.GetUniqueNeighborhoods(js.GetFilteredNeighborhoods(js.GetAllNeighborhoods(rootObject)));
                    PrintProperties(result3);
                    return true;
                case '4':
                    var result4 = js.AllInOneSingleQuery();
                    PrintProperties(result4);
                    return true;
                case '5':
                    return false;
            }
            return false;
        }

        // Output the propeties bases on the user choice and the collection of properties passed in
        public static void PrintProperties(IEnumerable<Feature> features)
        {
            foreach (Feature f in features)
            {
                Console.WriteLine(f.Properties.Neighborhood);
            }
            Console.WriteLine(" -- Number of Neighborhoods: {0} --", features.Count());
        }
    }
}
