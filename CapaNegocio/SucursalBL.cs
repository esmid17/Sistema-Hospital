using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SucursalBL
    {

        public List<SucursalCLS> listarSucursales()
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.listarSucursales();
        }

        public List<SucursalCLS> filtrarSucursales(SucursalCLS objSucursal)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursales(objSucursal);
        }

        public int GuardarSucursal(SucursalCLS objSucursal)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.GuardarSucursal(objSucursal);
        }
    }
}
