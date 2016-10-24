using System.IO;
using Xunit;

namespace Stugo.Logging.Test
{
    public class LoggerTest
    {
        [Fact]
        public void It_creates_a_logging_config_file_if_it_doesnt_exist()
        {
            var inspector = new AssemblyDetailsInspector(typeof(LoggerTest).Assembly);
            var file = Path.Combine(inspector.ProgramDataDirectory, "logging.config");

            if (File.Exists(file))
                File.Delete(file);

            Assert.False(File.Exists(file));

            var logger = Logger.GetLogger(typeof(LoggerTest));

            Assert.NotNull(logger);
            Assert.True(File.Exists(file));

            var outputContents = File.ReadAllText(file);
            string expectedContents;

            using (var resourceStream = typeof(Logger).Assembly.GetManifestResourceStream("Stugo.Logging.logging.config"))
            {
                Assert.NotNull(resourceStream);

                using (var reader = new StreamReader(resourceStream))
                {
                    expectedContents = reader.ReadToEnd();
                }
            }

            Assert.False(string.IsNullOrEmpty(expectedContents));
            Assert.Equal(expectedContents, outputContents);
        }
    }
}
