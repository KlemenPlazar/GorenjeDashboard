
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GorenjeDashboard.Models
{
    public class MachineModel
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int MachineId { get; set; }

        [Display(Name = "Stroj")]
        public string Machine { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}