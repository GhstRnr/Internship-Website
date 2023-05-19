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

    public String? FullDesc { get; set; }

    public String? Thumbnail { get; set; }

    public String? terms { get; set; }

    public String? categories { get; set; }
}
}
