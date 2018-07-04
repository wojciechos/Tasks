using BookshelfApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;


namespace BookShelfApiTests
{
    [TestFixture]
    public class BookShelfApiTests
    {
        protected TestServer Server;

        [SetUp]
        public void SetUp()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
        }

        [Test]
        public void GetAllBooks()
        {
            //using (var client = Server.CreateClient())
            //{
            //    var response = client.GetAsync("/");

            //}
        }
    }
}
