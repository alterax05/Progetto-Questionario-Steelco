using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace test_api
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestEnviroment()
        {
            string password = Environment.GetEnvironmentVariable("PASSWORD_DB")!;
            string user = Environment.GetEnvironmentVariable("USER_DB")!;
            Assert.That(string.IsNullOrEmpty(password) && string.IsNullOrEmpty(user), Is.False, "Password or user is null or empty");
        }
        [Test]
        public void TestConnection()
        {
            string password = Environment.GetEnvironmentVariable("PASSWORD_DB") ?? "JWlcOMT72bLSrGkA";
            string user = Environment.GetEnvironmentVariable("USER_DB") ?? "micheleporcellato";

            const string connectionUri = $"mongodb+srv://micheleporcellato:JWlcOMT72bLSrGkA@steelcodb.pn8pfrs.mongodb.net/?retryWrites=true&w=majority";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Set the ServerApi field of the settings object to Stable API version 1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
            var client = new MongoClient(settings);

            // Send a ping to confirm a successful connection
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Assert.Pass("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}