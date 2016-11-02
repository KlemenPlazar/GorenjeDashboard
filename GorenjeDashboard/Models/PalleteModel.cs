using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GorenjeDashboard.Models
{
    public class PalleteModel
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int PalleteId { get; set; }

        [Display(Name = "Paleta")]
        public string PalleteName { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}