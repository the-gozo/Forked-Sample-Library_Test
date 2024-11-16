using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MyAppTests
{
    public class FailedTest
    {
        [Fact]
        public void Fails_With_Duplicate_Event_Key()
        {
            var testClient = new WebApplicationFactory<Program>().CreateClient();
        }
    }
}