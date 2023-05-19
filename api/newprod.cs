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
    public static class newprod
    {
        [FunctionName("newprod")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req,
            [CosmosDB(
                    databaseName: "autumn",
                    containerName: "cluster",
                    SqlQuery = "SELECT * FROM c ",
                    Connection= "DBConnection")] IEnumerable<SearchResult> terms,
            ILogger log)
        { 
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new JsonResult(terms.Where(result => result.categories?.Contains("New") == true));
        }
    }
}
