using System.Collections.Generic;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Categoria Categoria { get; set; }

        public Marca Marca { get; set; }
        
        public List<Imagen> Imagenes { get; set; } = new List<Imagen>();
    }
}