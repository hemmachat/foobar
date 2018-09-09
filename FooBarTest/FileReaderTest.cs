using FooBarConsole;
using FooBarConsole.Interfaces;
using Moq;
using Xunit;

namespace FooBarTest
{
    public class FileReaderTest
    {
        private readonly Mock<IConfigurationReader> _config;
        private readonly IFileReader _reader;

        public FileReaderTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _config = factory.Create<IConfigurationReader>();
            _reader = new FileReader(_config.Object);
        }        

        [Fact]
        public void Config_Valid()
        {
            _config.Setup(_ => _.GetInternalFile()).Returns("InternalFooBar.json");
            
            var content = _reader.ReadFile();

            Assert.NotEmpty(content);
        }
    }
}