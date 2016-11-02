
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GorenjeDashboard.Models
{
    public class MaterialModel
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int MaterialId { get; set; }

        [Display(Name = "Material")]
        public string Material { get; set; }

        [Display(Name = "Šifra materiala")]
        public string MaterialCode { get; set; }

        [Display(Name = "Struktura materiala")]
        public string MaterialStructure { get; set; }

        [Display(Name = "Stroj")]
        public int MachineId { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}