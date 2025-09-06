using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        
        public List<E_Categoria> ListarCategorias(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    Id_categoria = LeerFilas.GetInt32(0),
                    Codigo_categoria = LeerFilas.GetString(1),
                    Nombre_categoria = LeerFilas.GetString(2),
                    Descripcion_categoria = LeerFilas.GetString(3)
                });
            }

            conexion.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombre_categoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcion_categoria);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EditarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.Id_categoria);
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombre_categoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcion_categoria);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarCategoria(E_Categoria idcategoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", idcategoria);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
