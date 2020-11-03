using System.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Persona
    {
        [Key]
        [StringLength(10)]
        public string Identificacion { get; set; }
        [StringLength(45)]
        public string Nombres { get; set; }
        [StringLength(45)]
        public string Apellidos { get; set; }
        [StringLength(16)]
        public string Sexo { get; set; }
        [StringLength(16)]
        public string Ciudad { get; set; }
        public int Edad { get; set; }
        public int DonacionId { get; set; }
        public virtual Donacion Donacion { get; set; }
    }
}
