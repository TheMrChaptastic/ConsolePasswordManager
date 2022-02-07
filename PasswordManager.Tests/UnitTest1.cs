using System;
using Xunit;

namespace PasswordManager.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetSomething()
        {
            var parser = new Parser();
            //Act
            var actual = parser.Parse("fake company,chappy@themrchaptastic.com,wowieskldfjd,false,false,12");
            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("fake company,chappy@themrchaptastic.com,wowieskldfjd,false,false,12", "fake company")]
        [InlineData("fake company 2, chappy@themrchaptastic.com, wowieskdfjdk, false, false, 12", "fake company 2")]
        public void ShouldParseService(string line, string expected)
        {
            var parser = new Parser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Service);
        }

        [Theory]
        [InlineData("fake company,chappy@themrchaptastic.com,wowieskldfjd,false,false,12", "chappy@themrchaptastic.com")]
        [InlineData("fake company 2,chappy@themrchaptastic.com,wowieskdfjdk,false,false,12", "chappy@themrchaptastic.com")]
        public void ShouldParseEmail(string line, string expected)
        {
            var parser = new Parser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Email);
        }

        [Theory]
        [InlineData("fake company,chappy@themrchaptastic.com,wowieskldfjd,false,false,12", "wowieskldfjd")]
        [InlineData("fake company 2,chappy@themrchaptastic.com,wowieskdfjdk,false,false,12", "wowieskdfjdk")]
        public void ShouldParsePassword(string line, string expected)
        {
            var parser = new Parser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Password);
        }

        [Theory]
        [InlineData("fake company,chappy@themrchaptastic.com,wowieskldfjd,false,false,12", false)]
        [InlineData("fake company 2, chappy@themrchaptastic.com, wowieskdfjdk, false, false, 12", false)]
        public void ShouldParseSChar(string line, bool expected)
        {
            var parser = new Parser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.SChar);
        }

        [Theory]
        [InlineData("fake company,chappy@themrchaptastic.com,wowieskldfjd,false,false,12", false)]
        [InlineData("fake company 2, chappy@themrchaptastic.com, wowieskdfjdk, false, false, 12", false)]
        public void ShouldParseUCase(string line, bool expected)
        {
            var parser = new Parser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.UCase);
        }

        [Theory]
        [InlineData("fake company,chappy@themrchaptastic.com,wowieskldfjd,false,false,12", 12)]
        [InlineData("fake company 2, chappy@themrchaptastic.com, wowieskdfjdk, false, false, 12", 12)]
        public void ShouldParseLength(string line, int expected)
        {
            var parser = new Parser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.PassLength);
        }
    }
}
