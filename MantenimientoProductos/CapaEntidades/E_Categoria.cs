using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Categoria
    {
        private int id_categoria;
        private string codigo_categoria;
        private string nombre_categoria;
        private string descripcion_categoria;

        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Codigo_categoria { get => codigo_categoria; set => codigo_categoria = value; }
        public string Nombre_categoria { get => nombre_categoria; set => nombre_categoria = value; }
        public string Descripcion_categoria { get => descripcion_categoria; set => descripcion_categoria = value; }
    }
}
