using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultipleImageUpload.Data;
using MultipleImageUpload.Models;

namespace MultipleImageUpload.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment hostEnvironment;

        public UserController(AppDbContext context,IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.hostEnvironment = hostEnvironment;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var user = context.Users.Include(img => img.ImageGalleries).ToList();
            return View(user);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                        if (user.ImageFile != null)
                        {
                            foreach (var item in user.ImageFile)
                            {
                                var folder = "images/";
                                var extension = Path.GetExtension(item.FileName);
                                folder += Guid.NewGuid().ToString() + item.FileName;
                                var imagefile = folder;
                                var serverFolder = Path.Combine(hostEnvironment.WebRootPath, folder);
                                using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                                {
                                    item.CopyTo(fileStream);
                                }
                                if(user.ImageGalleries!=null)
                                {
                                user.ImageGalleries.Add(new ImageGallery {ImageName = imagefile });
                                }
                            }
                        }
                        context.Add(user);
                        context.SaveChanges();
                }
                
                    return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user=context.Users.Include(img=>img.ImageGalleries).FirstOrDefault(x=>x.Id==id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string lol)
        {
            try
            {
                var user = context.Users.Include(img => img.ImageGalleries).FirstOrDefault(x=>x.Id==id);
                
                var images = user.ImageGalleries.Where(x => x.UserId == id);
                foreach(var item in images)
                {
                    var imageName = item.ImageName;
                    if(imageName!=null)
                    {
                        var imagePath = Path.Combine(hostEnvironment.WebRootPath, imageName);
                        if(System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                }
                context.Remove(user);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
