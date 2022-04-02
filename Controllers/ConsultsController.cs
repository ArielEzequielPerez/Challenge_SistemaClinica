using Microsoft.AspNetCore.Mvc;
using SistemasClinica.Data.Repository.Interfaces;
using SistemasClinica.Models;
using System.Threading.Tasks;

namespace SistemasClinica.Controllers
{
    public class ConsultsController : Controller
    {
        private readonly IRepository _repository;
        public ConsultsController(IRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get consults information.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var consults = await _repository.GetConsultsAsync();
            return View(consults);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.profesionals =  await _repository.GetProfessionalAsync();
            return View();
        }
        /// <summary>
        ///  Creates a new Consult.
        /// </summary>
        /// <param name="consult"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Consult consult)
        {
            if (!ModelState.IsValid)
                return NotFound();

            _repository.Add(consult);
            await _repository.SaveAll();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Edit a consult
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var consult = await _repository.GetConsultsByIdAsync(id.Value);
            if (consult == null)
                return NotFound();
            return View(consult);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var consult = await _repository.GetConsultsByIdAsync(id.Value);
            if (consult == null)
                return NotFound();
            return View(consult);
        }
        /// <summary>
        /// Confirm the delete of a consult
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var consult = await _repository.GetConsultsByIdAsync(id.Value);
            _repository.Delete(consult);
            await _repository.SaveAll();
            return RedirectToAction("Index");
        }
    }
}
