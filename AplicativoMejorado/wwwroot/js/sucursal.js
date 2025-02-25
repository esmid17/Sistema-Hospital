window.onload = function () {
    listarSucursales();
};
function filtrarSucursales() {
    let nombre = get("txtSucursales");
    if (nombre == "") {
        listarSucursales();
    } else {
        objSucursales.url = "Sucursal/filtrarSucursales/?nombre=" + nombre;
        pintar(objSucursales);
    }

}

let objSucursales;

async function listarSucursales() {
    objSucursales = {
        url: "Sucursal/listarSucursales",
        cabeceras: ["id Sucursal", "Nombre", "Direccion"],
        propiedades: ["idSucursal", "nombre", "direccion"],
        editar: true,
        eliminar: true
    }
    pintar(objSucursales);
}

function BuscarSucursal() {
    let forma = document.getElementById("frmBusqueda");

    let frm = new FormData(forma);

    fetchPost("Sucursal/filtrarSucursales", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}

function LimpiarSucursal() {
    LimpiarDatos("frmGuardarSucursal");
    listarSucursales();
}


function GuardarSucursal() {
    let forma = document.getElementById("frmGuardarSucursal");
    let frm = new FormData(forma);
    fetchPost("Sucursal/GuardarSucursal", "text", frm, function (res) {
        listarSucursales();
        LimpiarDatos("frmGuardarSucursal");
        
    })
}
