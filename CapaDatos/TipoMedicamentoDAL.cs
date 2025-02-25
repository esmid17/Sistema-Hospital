using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TipoMedicamentoDAL:ConexionSQL
    {
        public TipoMedicamentoCLS recuperarTipoMedicamento(int idTipoMedicamento)
        {
            TipoMedicamentoCLS oTipoMedicamentoCLS = new TipoMedicamentoCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOMEDICAMENTO as idTipoMedicamento, NOMBRE, DESCRIPCION FROM TipoMedicamento WHERE BHABILITADO = 1 AND IIDTIPOMEDICAMENTO = @iidtipomedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@iidtipomedicamento", idTipoMedicamento);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);

                        if (dr.HasRows)
                        {
                            int posIdTipoMedicamento = dr.GetOrdinal("idTipoMedicamento");
                            int posNombre = dr.GetOrdinal("nombre");
                            int posDescripcion = dr.GetOrdinal("descripcion");

                            while (dr.Read())
                            {
                                oTipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(posIdTipoMedicamento) ? 0 : dr.GetInt32(posIdTipoMedicamento);
                                oTipoMedicamentoCLS.nombre = dr.IsDBNull(posNombre) ? " " : dr.GetString(posNombre);
                                oTipoMedicamentoCLS.descripcion = dr.IsDBNull(posDescripcion) ? " " : dr.GetString(posDescripcion);
                            }
                        }
                        else
                        {
                            oTipoMedicamentoCLS.idTipoMedicamento = 0;
                            oTipoMedicamentoCLS.nombre = "";
                            oTipoMedicamentoCLS.descripcion = "";
                        }

                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    oTipoMedicamentoCLS = new TipoMedicamentoCLS();
                }
            }

            return oTipoMedicamentoCLS;
        }

        public int GuardarTipoMedicamento(TipoMedicamentoCLS obj)
        {
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOMEDICAMENTO as idTipoMedicamento, NOMBRE, DESCRIPCION FROM TipoMedicamento WHERE BHABILITADO = 1 AND IIDTIPOMEDICAMENTO = @iidtipomedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public int GuardarCambiosTipoMedicamento(TipoMedicamentoCLS obj)
        {
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE TipoMedicamento SET NOMBRE = @nombre, DESCRIPCION = @descripcion WHERE IIDTIPOMEDICAMENTO = @idTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                        cmd.Parameters.AddWithValue("@idTipoMedicamento", obj.idTipoMedicamento);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }


        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new TipoMedicamentoCLS
                                {
                                    idTipoMedicamento = dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? null : dr.GetString(1),
                                    descripcion = dr.IsDBNull(2) ? null : dr.GetString(2),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    lista = null;
                    throw;
                }
            }
            return lista;
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(TipoMedicamentoCLS obj)
        {
            List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", (object)obj.nombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@descripcion", (object)obj.descripcion ?? DBNull.Value);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new TipoMedicamentoCLS
                                {
                                    idTipoMedicamento = dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? null : dr.GetString(1),
                                    descripcion = dr.IsDBNull(2) ? null : dr.GetString(2),
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    lista = null;
                    throw;
                }
            }
            return lista;
        }
    }
}
