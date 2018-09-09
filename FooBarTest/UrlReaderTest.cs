using FooBarConsole;
using FooBarConsole.Interfaces;
using Moq;
using Xunit;

namespace FooBarTest
{
    public class UrlReaderTest
    {
        private readonly Mock<IConfigurationReader> _config;
        private readonly IFileReader _reader;

        public UrlReaderTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _config = factory.Create<IConfigurationReader>();
            _reader = new UrlReader(_config.Object);
        }        

        [Fact]
        public void Config_Valid()
        {
            _config.Setup(_ => _.GetExternalUrl()).Returns("https://raw.githubusercontent.com/hemmachat/foobar/master/FooBarConsole/TestFooBar/ExternalFooBar.json");
            
            var content = _reader.ReadFile();

            Assert.NotEmpty(content);
        }
    }
}