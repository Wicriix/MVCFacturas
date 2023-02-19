using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.Entities.ViewModels
{
    public class BaxterViewModel
    {
        [Required]
        public string country { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
