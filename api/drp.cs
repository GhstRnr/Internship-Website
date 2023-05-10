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

namespace api
{

    public class SearchResult
    {
        public String? Title { get; set; }

        public String? Price { get; set; }

        public String? Description { get; set; }

        public String? Thumbnail { get; set; }
    }

    public static class drp
    {
        [FunctionName("drp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var searchResults = new List<SearchResult>()
            {
                new() {Title="iPod 64GB", Price="$249.99", Description="The iPod is a pocket-sized portable music-playing device produced by Apple and sold across the world. It's the best-known family of MP3 players ",Thumbnail="https://m.media-amazon.com/images/I/41+6wshUjVS._AC_UY436_FMwebp_QL65_.jpg"},
                new() {Title="iPod 128GB", Price="$299.99", Description="The iPod is a pocket-sized portable music-playing device produced by Apple and sold across the world. It's the best-known family of MP3 players ",Thumbnail="https://m.media-amazon.com/images/I/41+6wshUjVS._AC_UY436_FMwebp_QL65_.jpg"},
                new() {Title="iPod 256GB", Price="$349.99", Description="The iPod is a pocket-sized portable music-playing device produced by Apple and sold across the world. It's the best-known family of MP3 players ",Thumbnail="https://m.media-amazon.com/images/I/41+6wshUjVS._AC_UY436_FMwebp_QL65_.jpg"}
            };


            return new JsonResult(searchResults);
        }
    }
}
