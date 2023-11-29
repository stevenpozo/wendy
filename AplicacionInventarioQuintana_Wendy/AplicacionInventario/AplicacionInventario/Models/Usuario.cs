using System;
using System.Collections.Generic;

namespace AplicacionInventario.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Rol { get; set; }
        public DateTime? FechadeNaciemiento { get; set; }
        public int? Edad { get; set; }
    }
}
