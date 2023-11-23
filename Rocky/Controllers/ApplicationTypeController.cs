using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rocky_DataAccess;
using Rocky_DataAccess.Repostitory.IRepository;
using Rocky_Models;
using Rocky_Utility;

namespace Rocky.Controllers
{
    [Authorize(Roles = WC.AdminRole)]

    public class ApplicationTypeController : Controller
    {
        private readonly IApplicationTypeRepository _appTypeRepo;

        public ApplicationTypeController(IApplicationTypeRepository appTypeRepo)
        {
            _appTypeRepo = appTypeRepo;
        }

        public IActionResult Index() 
        {
            IEnumerable<ApplicationType> objList = _appTypeRepo.GetAll();
            return View(objList);
        }

        // GET QUERY - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST QUERY - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid) 
            {
                _appTypeRepo.Add(obj);
                _appTypeRepo.Save();

                TempData[WC.Success] = "Action completed successfully";

                return RedirectToAction("Index");
            }
           
            return View(obj);
        }

        // GET QUERY - EDIT

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _appTypeRepo.Find(id.GetValueOrDefault());

            if (obj == null) 
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST QUERY - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj) 
        {
            if (ModelState.IsValid)
            {
                _appTypeRepo.Update(obj);
                _appTypeRepo.Save();

                TempData[WC.Success] = "Action completed successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET QUERY - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _appTypeRepo.Find(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST QUERY - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }

            _appTypeRepo.Remove(obj);
            _appTypeRepo.Save();

            TempData[WC.Success] = "Action completed successfully";

            return RedirectToAction("Index");
        }

    }
}
