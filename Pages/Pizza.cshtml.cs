using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
    public void OnGet()
    {

        pizzas = PizzaService.GetAll();
    
    }

    public List<PizzaModel> pizzas = new();

    public string GlutenFreeText(Pizza pizza)
    {
        return pizza.IsGlutenFree ? "Gluten Free" : "Not Gluten Free";
    }

    public IActionResult OnPost()
    {
    if (!ModelState.IsValid)
    {
        return Page();
    }
    PizzaService.Add(NewPizza);
    return RedirectToAction("Get");
    }

    [BindProperty]
    public Pizza NewPizza { get; set; } = new();

    }
}
