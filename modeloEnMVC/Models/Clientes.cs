using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace modeloEnMVC.Models
{
    public class Clientes
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display (Name="Fecha de registro")]
        public DateTime fechaAlta { get; set; }
        [Display(Name ="Edad")]
        public int edad { get; set; }
    }
}