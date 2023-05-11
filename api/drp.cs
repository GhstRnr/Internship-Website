using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace api
{

    public class SearchResult
    {
        public String? Title { get; set; }

        public String? Price { get; set; }

        public String? Description { get; set; }

        public String? Thumbnail { get; set; }

        public String? terms { get; set; }
    }

    public static class drp
    {
        [FunctionName("drp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "drp/{term}")] HttpRequest req,
            [CosmosDB(
                    databaseName: "autumn",
                    containerName: "cluster",
                    SqlQuery = "SELECT * FROM c",
                    Connection= "DBConnection")] IEnumerable<SearchResult> terms,
                    string term,
            ILogger log)
        { 
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new JsonResult(terms.Where(result => result.terms?.Contains(term) == true));
        }
    }
}
