using System;
using System.Collections.Generic;

namespace AplicacionInventario.Models
{
    public partial class InventarioMueble
    {
        public int Id { get; set; }
        public string? NombreMaterial { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public float? Cantidad { get; set; }
        public string? Costo { get; set; }
    }
}
