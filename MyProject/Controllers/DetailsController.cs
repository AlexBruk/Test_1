using System.Linq;
using System.Web.Mvc;
using Test_1.Models.ViewModels;
using Test_1.Services;
namespace Test_1.Controllers
{
    public class DetailsController : Controller
    {
        private IDetailsService _detailsService { get; set; }
        public DetailsController(IDetailsService detailsService)
        {
            _detailsService = detailsService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var detailsModel = new DetailsViewModel
                {
                    Details = _detailsService.GetDetails().ToList()
                };
                return View(detailsModel);
            }
            catch
            {
                return Json(new { success = false, info = "Ошибка базы" }, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult SearchDetails(string keyword)
        {
            var detailsModel = new DetailsViewModel
            {
                Details = _detailsService.GetDetails(keyword).ToList()
            };
            return PartialView(detailsModel);
        }

        [HttpGet]
        public ActionResult AddDetail()
        {
            var storeKeepers = _detailsService.GetStoreKeepers().ToList();
            var model = new AddDetailViewModel { StoreKeepers = new SelectList(storeKeepers, "Id", "Name") };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddDetail(AddDetailViewModel detail)
        {
            if (ModelState.IsValid)
            {
                var result = _detailsService.AddDetail(detail);

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
            var result = _detailsService.DeleteDetail(id);

            return Json(new
            {
                success = result.Success,
                info = result.Info
            });
        }
    }
}