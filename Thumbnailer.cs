// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.Messaging.EventGrid;
using Azure.Storage.Blobs;
using Azure.Messaging.EventGrid.Models;
using Newtonsoft.Json.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Siliconvalve.Demo
{
    public static class Thumbnailer
    {
        private static readonly string BLOB_STORAGE_CONNECTION_STRING = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

        [FunctionName("Thumbnailer")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, 
        [Blob("{data.url}", FileAccess.Read)] Stream input, ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
        }
    }
}
