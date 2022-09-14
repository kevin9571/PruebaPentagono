
//Variables
let id_cerrar;


//Funciones varias

function FormatearFecha(fecha) {
    return fecha.substr(0, 4) + '/' + fecha.substr(5, 2) + '/' + fecha.substr(8, 2) + ' ' + fecha.substr(11);
}

function AbrirModalDiagnostico(id) {
    $("#AgregarDiagnostico").modal("show");
    id_cerrar = id;
}

//Funciones POST

function IngresarCita() {

    let validacion=true;

    if ($("#SelectPaciente").val() == "") validacion=false;
    if ($("#SelectMedico").val() == "") validacion = false;
    if ($("#FechaHora").val() == "") validacion = false;

    if (validacion == false) {
        Alertar("Ingrese correctamente todos los campos");
        return;
    }

    let temp = FormatearFecha($("#FechaHora").val());

    var fd = new FormData();
    fd.append('id_paciente', $("#SelectPaciente").val());
    fd.append('id_medico', $("#SelectMedico").val());
    fd.append('fecha_hora', temp);

    
    Ajax("../Controladores/CitaMedicaController.ashx?opc=save", "post", fd)
        .then((datos) => {

            if (datos == "True") {
                Alertar("La cita se registro correctamente");
                $("#CrearCita").modal("hide");
                ListarCitas();
            } else
                Alertar("Ocurrió un error mientras se creaba la cita medica");

        }).catch(() => {
            Alertar("Ocurrió un error mientras se creaba la cita medica");
        });
    
}




//Funciones GET

function ListarCitas() {
    Ajax("../Controladores/CitaMedicaController.ashx?opc=show", "get")
        .then((datos) => {
            datos = JSON.parse(datos);

            html = "";
            for (i = 0; i < datos.length; i++) {
                html = html + "<tr>";
                html = html + "<td>" + datos[i].paciente + "</td>";
                html = html + "<td>" + datos[i].medico + "</td>";
                html = html + "<td>" + datos[i].especialidad + "</td>";
                html = html + "<td>" + FormatearFecha(datos[i].fecha_hora) + "</td>";
                html = html + "<td><button style='color:white' class='btn btn-warning' onclick='AbrirModalDiagnostico(" + datos[i].id +")'><i class='fas fa-times-circle'></i> Cerrar</button></td>";
                html = html + "</tr>";
            }

            $("#BodyCitas").html(html);           

        }).catch(() => {
            Alertar("Ocurrió un error solicitando la información a la base de datos");
        });
}

function ListarPacientes() {
    Ajax("../Controladores/PacienteController.ashx?opc=show", "get")
        .then((datos) => {
            datos = JSON.parse(datos);

            html = "";
            for (i = 0; i < datos.length; i++)
                html = html + "<option value='" + datos[i].id + "'>" + datos[i].nombre + " " + datos[i].apellido + "</option>";

            $("#SelectPaciente").html(html);

        }).catch(() => {
            Alertar("Ocurrió un error solicitando la información a la base de datos");
        });
}

function ListarEspecialidades() {
    Ajax("../Controladores/EspecialidadController.ashx?opc=show", "get")
        .then((datos) => {
            datos = JSON.parse(datos);

            html = "";
            for (i = 0; i < datos.length; i++)
                html = html + "<option value='" + datos[i].id + "'>" + datos[i].nombre + "</option>";

            $("#SelectEspecialidad").html(html);
            ListarDoctores();

        }).catch(() => {
            Alertar("Ocurrió un error solicitando la información a la base de datos");
        });
}

function ListarDoctores() {

    Ajax("../Controladores/MedicoController.ashx?opc=FindByEspecialidad&id_especialidad=" + $("#SelectEspecialidad").val(), "get")
        .then((datos) => {
            datos = JSON.parse(datos);

            html = "";
            for (i = 0; i < datos.length; i++)
                html = html + "<option value='" + datos[i].id + "'>" + datos[i].nombre + " " + datos[i].apellido + "</option>";

            $("#SelectMedico").html(html);

        }).catch(() => {
            Alertar("Ocurrió un error solicitando la información a la base de datos");
        });
}

function CerrarCita() {

    let validacion = true;
    if ($("#TextArea").val() == "") validacion = false;

    if (validacion == false) {
        Alertar("Ingrese correctamente todos los campos");
        return;
    }

    Ajax("../Controladores/CitaMedicaController.ashx?opc=terminar&id=" + id_cerrar, "get")
        .then((datos) => {

            if (datos == "True") {

                var fd = new FormData();
                fd.append('diagnostico', $("#TextArea").val());

                Ajax("../Controladores/HistorialController.ashx?opc=save&id_cita_medica=" + id_cerrar, "post", fd)
                    .then((datos) => {

                        if (datos == "True") {
                            Alertar("El Diagnostico se ingreso correctamente");
                            $("#AgregarDiagnostico").modal("hide");
                            ListarCitas();
                        } else
                            Alertar("Ocurrió un error mientras se ingresaba el diagnostico");

                    }).catch(() => {
                        Alertar("Ocurrió un error mientras se ingresaba el diagnostico");
                    });

            } else
                Alertar("Ocurrió un error mientras se cerraba la cita medica");

        }).catch(() => {
            Alertar("Ocurrió un error mientras se cerraba la cita medica");
        });
}


ListarCitas();
ListarPacientes();
ListarEspecialidades();