using Microsoft.AspNetCore.Mvc;
using SistemasClinica.Data.Repository.Interfaces;
using SistemasClinica.Models;
using System.Threading.Tasks;
namespace SistemasClinica.Controllers
{
    public class ProfessionalsController : Controller
    {
        private readonly IRepository _repository;
        public ProfessionalsController(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var professionals = await _repository.GetProfessionalAsync();
            return View(professionals);
        }
        
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Professional professional)
        {
            if (!ModelState.IsValid)
                 return NotFound();
            
            _repository.Add(professional);
            await _repository.SaveAll();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var professional = await _repository.GetProfessionalByIdAsync(id.Value);
            if (professional == null)
                return NotFound();
            return View(professional);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var professional = await _repository.GetProfessionalByIdAsync(id.Value);
            if (professional == null)
                return NotFound();
            return View(professional);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var professional = await _repository.GetProfessionalByIdAsync(id.Value);

            _repository.Delete(professional);
            await _repository.SaveAll();
            return RedirectToAction("Index");
        }
    }
}
