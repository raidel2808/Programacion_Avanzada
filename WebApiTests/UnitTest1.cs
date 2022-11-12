using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_1;
using System.IO;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace WebApiTests
   
{
    [TestClass]
    public class StorehouseServiceTests
    {
        [TestMethod]
        public async Task Can_GetPImported_Test()
        {
            // arrange
            HttpClient client = new HttpClient();
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7224/");
            // Sets the Accept header to "application/json".Setting this header tells the server to send data in JSON format.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // act
            IEnumerable<ProductImported> pimported = null;
            HttpResponseMessage response = await client.GetAsync(@"Storehouse/GetPImported");
            if (response.IsSuccessStatusCode)
            {
                pimported = await response.Content.ReadAsAsync<IEnumerable<ProductImported>>();
            }

            // assert
            Assert.IsNotNull(pimported);
        }
    }
}