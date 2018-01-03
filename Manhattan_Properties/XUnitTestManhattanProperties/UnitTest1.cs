using System;
using System.IO;
using Manhattan_Properties.Classes;
using Newtonsoft.Json;
using Xunit;

namespace XUnitTestManhattanProperties
{
    public class UnitTest1
    {
        [Fact]
        public void Return_All_Neighborhoods_Not_Empty()
        {
            // Arrange
            StreamReader sr = new StreamReader("data.json");
            string json = sr.ReadToEnd();
            RootObject featuresCollection = JsonConvert.DeserializeObject<RootObject>(json);
            JsonDeserializer jd = new JsonDeserializer();

            // Act
            var result = jd.GetAllNeighborhoods(featuresCollection);

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
