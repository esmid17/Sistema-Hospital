window.onload = function () {
    listarLaboratorios();
};

function filtrarLaboratorios() {
    let nombre = get("txtLaboratorio");
    if (nombre == "") {
        listarLaboratorios();
    } else {
        objLaboratorio.url = "Laboratorio/filtrarLaboratorios/?nombre=" + nombre;
        pintar(objLaboratorio);
    }

}

let objLaboratorio;

async function listarLaboratorios() {
    objLaboratorio = {
        url: "Laboratorio/listarLaboratorios",
        cabeceras: ["id Laboratorio", "Nombre", "Direccion", "Persona Contacto"],
        propiedades: ["idLaboratorio", "nombre", "direccion", "personaContacto"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true
    }

    pintar(objLaboratorio);

}

function BuscarLaboratorio() {
    let forma = document.getElementById("frmBusqueda");

    let frm = new FormData(forma);

    fetchPost("Laboratorio/filtrarLaboratorios", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    })
}

function LimpiarLaboratorio() {
    LimpiarDatos("frmBusqueda");
    listarLaboratorios();
}