using Microsoft.AspNetCore.Mvc;
using SistemasClinica.Data.Repository.Interfaces;
using SistemasClinica.Models;
using System.Threading.Tasks;

namespace SistemasClinica.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IRepository _repository;
        public PatientsController(IRepository repository)
        {
            _repository=repository;
        }
        public async Task<IActionResult> Index()
        {
            var patients = await _repository.GetPatientAsync();
            return View(patients);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.consults = await _repository.GetConsultsAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
                return NotFound();
            _repository.Add(patient);
            await _repository.SaveAll();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var patient = await _repository.GetPatientByIdAsync(id.Value);
            if (patient == null)
                return NotFound();
            return View(patient);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var patient = await _repository.GetPatientByIdAsync(id.Value);
            if (patient == null)
                return NotFound();
            return View(patient);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var patient = await _repository.GetPatientByIdAsync(id.Value);
            _repository.Delete(patient);
            await _repository.SaveAll();
            return RedirectToAction("Index");
        }
    }
}
