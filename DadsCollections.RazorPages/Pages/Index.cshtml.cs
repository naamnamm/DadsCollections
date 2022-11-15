using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace DadsCollections.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IWebHostEnvironment _webHostEnvironment;


        public List<string> CeramicImages { get; set; }
        public List<string> WatchImages { get; set; }
        public List<string> JewelryImages { get; set; }
        public List<string> ImageList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            //display products
            var provider = new PhysicalFileProvider(_webHostEnvironment.WebRootPath);
            var ceramicImgs = provider.GetDirectoryContents(Path.Combine("images", "ceramics"));
            var watchImgs = provider.GetDirectoryContents(Path.Combine("images", "watches"));
            var jewelryImgs = provider.GetDirectoryContents(Path.Combine("images", "jewelries"));

            CeramicImages = new List<string>();

            foreach (var item in ceramicImgs.ToList())
            {
                CeramicImages.Add(item.Name);
            }

            WatchImages = new List<string>();
            foreach (var item in watchImgs.ToList())
            {
                WatchImages.Add(item.Name);
            }

            JewelryImages = new List<string>();
            foreach (var item in jewelryImgs.ToList())
            {
                JewelryImages.Add(item.Name);
            }

        }
    }
}