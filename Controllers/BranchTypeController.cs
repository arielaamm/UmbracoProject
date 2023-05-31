//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Web.PublishedCache;


namespace UmbracoProject.Controllers
{
    public class BranchTypeController : Controller
    {
        [HttpPost]
        public ActionResult? Submit() => toJson();

        [HttpPost]
        private ActionResult? toJson()
        {
            IPublishedContentCache publishedContentCache = Umbraco.Web.Composing.Current.UmbracoContext.Content;
            IPublishedContent ? page = publishedContentCache.GetByXPath("//branchType").FirstOrDefault();

            if (page != null)
            {
                // Convert the data to JSON
                var jsonData = new
                {
                    Property1 = page.Value<string>("BranchName"),
                    Property2 = page.Value<int>("BranchId"),
                    // Add more properties as needed
                };

                string jsonString = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

                // Save the JSON data to a file
                string filePath = "path/to/your/file.json";
                System.IO.File.WriteAllText(filePath, jsonString);
            }
            return Content("JSON file generated successfully!");
        }
    }
}
