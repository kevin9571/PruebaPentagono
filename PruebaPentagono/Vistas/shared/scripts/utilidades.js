const Ajax = (url, type, data = new FormData()) => {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: url,
            type: type,
            data: data,
            processData: false, // tell jQuery not to process the data
            contentType: false, // tell jQuery not to set contentType
            success: function (datos) {
                if (datos)
                    resolve(datos);
                else
                    reject();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.warn("Status: " + textStatus);
                console.warn("Error: " + errorThrown);
                reject();
            },
        });
    });
}

const Confirmar = (Mensaje) => {
    return new Promise((resolve, reject) => {
        bootbox.confirm({
            message: Mensaje,
            backdrop: false,
            buttons: {
                cancel: {
                    label: 'Aceptar',
                    className: 'btn btn-success',
                },
                confirm: {
                    label: 'Cancelar',
                    className: 'btn btn-danger',
                }
            },
            closeButton: false,
            callback: function (result) {
                if (result === false)
                    resolve(true);
                else
                    resolve(false);
            }
        });
    });
}

function Alertar(Texto) {
    bootbox.alert({
        message: Texto,
        backdrop: true,
        buttons: {
            ok: {
                label: 'Aceptar'
            }
        },
    });
}