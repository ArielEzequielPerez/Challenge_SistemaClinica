using System;
using System.Collections.Generic;

namespace SistemasClinica.Models
{
    public class Consult : EntityBase
    {
        public DateTime DateRealitazion { get; set; }
        public int ProfessionalId { get; set; }
        public Professional Professional { get; set; }
        public IEnumerable<Professional> Professionals { get; set; }
        public float Cost { get; set; }
        public float CostMaterial { get; set; }
        public string Description { get; set; }
    }
}