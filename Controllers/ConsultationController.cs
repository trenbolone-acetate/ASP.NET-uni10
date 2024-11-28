using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET10.Controllers;

public class ConsultationController : Controller
{
    [HttpGet]
    public ActionResult Apply()
    {
        ViewBag.Products = GetProducts();
        return View(new ConsultationFormModel());
    }

    [HttpPost]
    public ActionResult Apply(ConsultationFormModel model)
    {
        ViewBag.Products = GetProducts();

        if (ModelState.IsValid)
        {
            ViewBag.Message = "Заявка прийнята.";
            return View("Success");
        }

        return View(model);
    }
    private SelectList GetProducts()
    {
        return new SelectList(new[]
        {
            "JavaScript", "C#", "Java", "Python", "Основи"
        });
    }
}
