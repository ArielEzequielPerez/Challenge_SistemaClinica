using System.ComponentModel.DataAnnotations;

namespace SistemasClinica.Models
{
    public class Person : EntityBase
    {
       [Required(ErrorMessage ="Ingrese un nombre")]
       [Display (Name = "Nombre")]
       public string Name { get; set; }
       [Required]
       [Display(Name = "Codigo")]
       
       public string NumberKey { get; set; }

    }
}
