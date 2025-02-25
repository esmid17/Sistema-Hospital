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
    public class LaboratorioDAL:ConexionSQL
    {

        public List<LaboratorioCLS> listarLaboratorios()
        {
            List<LaboratorioCLS> lista = new List<LaboratorioCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarLaboratorio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new LaboratorioCLS
                                {
                                    idLaboratorio = dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? null : dr.GetString(1),
                                    direccion = dr.IsDBNull(2) ? null : dr.GetString(2),
                                    personaContacto = dr.IsDBNull(3) ? null : dr.GetString(3)
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


        public List<LaboratorioCLS> filtrarLaboratorios(LaboratorioCLS obj)
        {
            List<LaboratorioCLS> lista = new List<LaboratorioCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarLaboratorio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", (object)obj.nombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@direccion", (object)obj.direccion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@personacontacto", (object)obj.personaContacto ?? DBNull.Value);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new LaboratorioCLS
                                {
                                    idLaboratorio = dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? null : dr.GetString(1),
                                    direccion = dr.IsDBNull(2) ? null : dr.GetString(2),
                                    personaContacto = dr.IsDBNull(3) ? null : dr.GetString(3)
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
