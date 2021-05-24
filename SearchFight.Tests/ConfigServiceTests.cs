using FluentAssertions;
using NUnit.Framework;

namespace SearchFight.Tests
{
    public class ConfigServiceTests
    {
        [Test]
        public void ConfigService_IsNotNull_Ok()
        {
            ConfigService.Config.Should().NotBeNull();
            ConfigService.GetConfiguration().Should().NotBeNull();
        }
    }
}
