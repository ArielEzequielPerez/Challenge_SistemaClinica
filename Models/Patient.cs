using System.Collections.Generic;

namespace SistemasClinica.Models
{
    public class Patient : Person
    {
        public int ConsultId { get; set; }
        public Consult Consult{ get; set; }
        public IEnumerable<Consult> Consults{ get; set; }
    }
}
