using System;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Deserializers;
using Newtonsoft.Json.Linq;

namespace RestSharp_API_Testing_Tutorial
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            //Establishes our client and allows it to connect to the URL
            var client = new RestClient("http://localhost:3000/");

            //In Postman we can use the GET to specfify specfific data
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            //Executes the request
            var response = client.Execute(request);

            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["author"];

            JObject obs = JObject.Parse(response.Content);

            Assert.That(obs["author"].ToString(), Is.EqualTo("Karthik KK"), "Author is not correct");
        }
    }
}

