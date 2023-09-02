using GauravCrudNagpur.Models;
using Microsoft.AspNetCore.Mvc;

namespace GauravCrudNagpur.Controllers
{
    public class InformationController : Controller
    {
        AppDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public InformationController(AppDbContext db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            var info = _db.Information.ToList();
            var infoVm = new InfoVM();
            infoVm.list = info;
            return View(infoVm);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(InfoVM model, IFormFile? file)
        {
          
            
                string WwwRootPath = _webHost.WebRootPath.ToString();
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(WwwRootPath, @"Image");
                    var Extension = Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, FileName + Extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.Information.Photo = FileName + Extension;
                }
            
            _db.Information.Add(model.Information);
            _db.SaveChanges();
            return RedirectToAction("Index");


            return View();
        }
    }
}
