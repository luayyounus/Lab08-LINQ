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
        public void Test1()
        {
            // Arrange
            StreamReader sr = new StreamReader("data.json");
            string json = sr.ReadToEnd();
            RootObject featuresCollection = JsonConvert.DeserializeObject<RootObject>(json);

            JsonDeserializer jd = new JsonDeserializer();

            // Act
            var result = jd.GetFilteredNeighborhoods(featuresCollection);

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
