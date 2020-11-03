using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Donacion
    {
        [Key]
        public int DonacionId { get; set; }
        [StringLength(15)]
        public string Modalidad { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ValorDonacion { get; set; }
    }
}
