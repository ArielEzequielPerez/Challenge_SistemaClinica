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
        /// <summary>
        /// Get professionals information.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var professionals = await _repository.GetProfessionalAsync();
            return View(professionals);
        }
        public IActionResult Create() 
        {
            return View();
        }
        /// <summary>
        ///  Creates a new professional.
        /// </summary>
        /// <param name="professional"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Professional professional)
        {
            if (!ModelState.IsValid)
                 return NotFound();
            
            _repository.Add(professional);
            await _repository.SaveAll();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Edit a professional
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Confirm the delete of a professional
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
