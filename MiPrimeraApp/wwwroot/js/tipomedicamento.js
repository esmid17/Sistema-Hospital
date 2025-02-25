window.onload = function () {
    listarTipoMedicamento();
};
function filtrarTipoMedicamento() {
    let nombre = get("txtTipoMedicamento");
    if (nombre == "") {
        listarSucursales();
    } else {
        objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + nombre;
        pintar(objTipoMedicamento);
    }

}

let objTipoMedicamento;

async function listarTipoMedicamento() {
    objTipoMedicamento = {
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["Id Tipo Medicamento", "Nombre", "Descripción"],
        propiedades: ["idTipoMedicamento", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadID: "idTipoMedicamento"
    }
    pintar(objTipoMedicamento);
}

function BuscarTipoMedicamento() {
    let forma = document.getElementById("frmBusqueda");

    let frm = new FormData(forma);

    fetchPost("TipoMedicamento/filtrarTipoMedicamento", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}

function LimpiarTipoMedicamento() {
    LimpiarDatos("frmGuardarTipoMedicamento");
    listarTipoMedicamento();
}

function GuardarTipoMedicamento() {
    let forma = document.getElementById("frmGuardarTipoMedicamento");
    let frm = new FormData(forma);
    fetchPost("TipoMedicamento/GuardarTipoMedicamento", "text", frm, function (res) {
        listarTipoMedicamento();
        LimpiarDatos("frmGuardarTipoMedicamento");

    })
}

function GuardarCambiosTipoMedicamento() {
    let forma = document.getElementById("frmGuardarTipoMedicamento");
    let frm = new FormData(forma);
    fetchPost("TipoMedicamento/GuardarCambiosTipoMedicamento", "text", frm, function (res) {
        listarTipoMedicamento();
        LimpiarDatos("frmGuardarTipoMedicamento");

    })
}

function Editar(id) {
    fetchGet("TipoMedicamento/recuperarTipoMedicamento/?idtipomedicamento=" + id, "json", function (data) {
        setN("idTipoMedicamento", data.idTipoMedicamento)
        setN("nombre", data.nombre)
        setN("descripcion", data.descripcion)
    })
}

function Eliminar(id) {
    
}