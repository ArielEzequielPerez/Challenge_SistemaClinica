using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemasClinica.Models
{
    public class Patient : Person
    {
        [Required]
        [Display(Name ="Consulta")]
        public int ConsultId { get; set; }
        [ForeignKey("ConsultId")]
        public Consult Consult{ get; set; }
        public IEnumerable<Consult> Consults{ get; set; }
    }
}
