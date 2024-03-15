using Microsoft.AspNetCore.Mvc;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class ConvidadoController : Controller
    {
        /*Lista com os convidados*/
        public static IList<Convidado> convidados = new List<Convidado>() {
            new Convidado()
            {
                convidadoID = 1,
                Nome = "Robert",
                EMail = "robert@gmail.com",
                Telefone = "35899978555",
                comparecimento= true
            },
            new Convidado()
            {
                convidadoID = 2,
                Nome = "Robert Silva",
                EMail = "robertsilva@gmail.com",
                Telefone = "35899978555",
                comparecimento= true
            },
            new Convidado()
            {
                convidadoID = 3,
                Nome = "Robert Vagner",
                EMail = "robertvagner@gmail.com",
                Telefone = "35899978555",
                comparecimento= false
            }
        };
        /*Página Index*/
        public IActionResult Index()
        {
            /*return View(convidados.Where(m=>m.comparecimento != false));*/
            return View(convidados);
        }
        /*Adicionando Convidadado*/
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Convidado convidado)
        {
            convidados.Add(convidado);
            convidado.convidadoID = convidados.Select(m => m.convidadoID).Max() + 1;
            return RedirectToAction("Index");
        }
        /*Editar Convidadado*/
        public IActionResult Edit(long id)
        {
            return View(convidados.Where(m=>m.convidadoID== id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Convidado convidado)
        {
            convidados.Remove(convidados.Where(c => c.convidadoID == convidado.convidadoID).First());
            convidados.Add(convidado);
            return RedirectToAction("Index");
        }
        /*Detalhes do Convidadado*/
        public IActionResult Details(long id)
        {
            return View(convidados.Where(m => m.convidadoID == id).First());
        }
        /*Apagar Convidadado*/
        public IActionResult Delete(long id)
        {
            return View(convidados.Where(m => m.convidadoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            convidados.Remove(convidados.Where(c => c.convidadoID == id).First());
            return RedirectToAction("Index");
        }
    }
}
