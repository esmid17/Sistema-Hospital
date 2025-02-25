using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraApp.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        // GET: TipoMedicamentoController
        public ActionResult Index()
        {
            return View();
        }
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
