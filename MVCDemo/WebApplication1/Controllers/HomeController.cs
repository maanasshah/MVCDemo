using System.Web.Mvc;
using MVCDemo.Model;
using MVCDemo.Repository;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var data = _transactionRepository.GetTransactions();
            return Json(new { Data = data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories()
        {
            var data = _categoryRepository.GetCategories();
            return Json(new { Data = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int id)
        {
            var data = _transactionRepository.GetTransactionById(id);
            return Json(new { Data = data != null ? data : new Transaction() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Transaction tran)
        {
            _transactionRepository.UpdateTransaction(tran);
            var data = _transactionRepository.GetTransactions();
            return Json(new { Data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}