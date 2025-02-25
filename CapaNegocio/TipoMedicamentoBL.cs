using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TipoMedicamentoBL
    {
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.listarTipoMedicamento();
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(TipoMedicamentoCLS objTipoMedicamento)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.filtrarTipoMedicamento(objTipoMedicamento);
        }

        public int GuardarTipoMedicamento(TipoMedicamentoCLS objTipoMedicamento)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.GuardarTipoMedicamento(objTipoMedicamento);
        }

        public TipoMedicamentoCLS recuperarTipoMedicamento(int idtipomedicamento)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.recuperarTipoMedicamento(idtipomedicamento);
        }

        public int GuardarCambiosTipoMedicamento(TipoMedicamentoCLS objTipoMedicamento)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.GuardarCambiosTipoMedicamento(objTipoMedicamento);
        }
    }
}
