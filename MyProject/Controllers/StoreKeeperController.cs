using System.Linq;
using System.Web.Mvc;
using Test_1.Models.ViewModels;
using Test_1.Services;


namespace Test_1.Controllers
{
    public class StoreKeeperController : Controller
    {
        private IStoreKeeperService _storeKeeperService { get; set; }
        public StoreKeeperController(IStoreKeeperService storeKeeperService)
        {
            _storeKeeperService = storeKeeperService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new StorekeeperViewModel
            {
                Storekeepers = _storeKeeperService.GetStoreKeepers().Select(c => new Storekeeper
                {
                    Id = c.Id,
                    Name = c.Name,
                    DetailsCount = _storeKeeperService.GetCoung(c.Id)                    
                }).ToList()
            };

            return View(model);
        }
        [HttpGet]
        public ActionResult AddStoreKeeper()
        {
            var model = new AddStoreKeeperViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddStoreKeeper(AddStoreKeeperViewModel SK)
        {
            if (ModelState.IsValid)
            {
                var result = _storeKeeperService.AddStoreKeeper(SK);

                return Json(new
                {
                    success = result.Success,
                    info = result.Info,
                });
            }
            return Json(new
            {
                success = false,
                info = ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage))
            });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _storeKeeperService.DeleteStoreKeeper(id);

            return Json(new
            {
                success = result.Success,
                info = result.Info,
            });
        }
    }
}