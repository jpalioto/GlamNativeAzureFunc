// Load the Glam specific classes
#load "glamNative.csx"
#load "common.csx"
#r "System.Drawing"
using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, Stream outputBlob, TraceWriter log)
{

    // This is the path that the output will be written to.
    var outputPath = Common.GetEnvironmentVariable("BaseOutputPath",
        @"D:\home\site\wwwroot\GlamSample\output\");

    // The base folder for our binaries.
    var binPath    = Common.GetEnvironmentVariable("BinPath",
        @"D:\home\site\wwwroot\GlamSample\bin\");

    log.Info($"Output path: {outputPath}");
    log.Info($"Bin path: {binPath}");
    
    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Get the name of the image
    string sourceName = data?.image;

    // Get binaries from our bin path 
    Common.SetDLLDirectory(binPath);
    
    // A unique directory name for our output.
    var id = Guid.NewGuid().ToString("N");

    // Create the directory for our output.
    Directory.CreateDirectory(outputPath + id);
    
    EffectsApplication.init(outputPath + id + @"\log.xml");
    EffectsApplication.process(input);
    EffectsApplication.terminate();

    var img = Common.GetImageFile(outputPath + id + "output.jpg")
    
    log.Info($"Image width: {img.Width}");
    log.Info($"Image to process: {sourceName}");

    // Save my image stream out to the blob
    img.Save( outputBlob, ImageFormat.Jpeg );

    return String.IsNullOrEmpty(sourceName)
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass an image name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Processed image " + sourceName);
}