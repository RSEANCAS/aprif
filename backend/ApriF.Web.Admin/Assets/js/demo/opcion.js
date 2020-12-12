var listaOpcionPadre = [],  tblOpcion = null;
$(document).on('nifty.ready', function () {
    page_Load();

    $('#frmOpcion').bootstrapValidator({
        excluded: [':disabled', '.val-exc'],
        feedbackIcons: faIcon,
        fields: {
            cbbPlataformaId_Opcion: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Plataforma'
                    }
                }
            },
            txtNombre_Opcion: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Nombre'
                    },
                    stringLength: {
                        max: 50,
                        message: 'Debe ingresar máximo 50 caracteres'
                    }
                }
            },
            txtEnlace_Opcion: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Enlace'
                    },
                    stringLength: {
                        max: 100,
                        message: 'Debe ingresar máximo 100 caracteres'
                    }
                }
            },
            txtOrden_Opcion: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Orden'
                    },
                    digits: {
                        message: 'El valor ingresado no es numérico'
                    }
                }
            }
        }
    }).on('status.field.bv', function (e, data) {
        var $form = $(e.target),
            validator = data.bv,
            $tabPane = data.element.parents('.tab-pane'),
            tabId = $tabPane.attr('id');

        if (tabId) {
            var $icon = $('a[href="#' + tabId + '"][data-toggle="tab"]').parent().find('i');

            // Add custom class to tab containing the field
            if (data.status == validator.STATUS_INVALID) {
                $icon.removeClass(faIcon.valid).addClass(faIcon.invalid);
            } else if (data.status == validator.STATUS_VALID) {
                var isValidTab = validator.isValidContainer($tabPane);
                $icon.removeClass(faIcon.valid).addClass(isValidTab ? faIcon.valid : faIcon.invalid);
            }
        }
    });

    //$('#tblOpcion tbody').on('click', 'td.details-control', function () {
    //    debugger;
    //    var tr = $(this).closest('tr');
    //    var row = tblOpcion.row(tr);

    //    if (row.child.isShown()) {
    //        // This row is already open - close it
    //        row.child.hide();
    //        tr.removeClass('shown');
    //    }
    //    else {
    //        // Open this row
    //        row.child(formatDetail_tblOpcion(row.data())).show();
    //        tr.addClass('shown');
    //    }
    //});
});

var formatDetail_tblOpcion = (d) => {
    // `d` is the original data object for the row
    //console.log(d)
    return
    `<table id="tblOpcion" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead class="bg-dark">
            <tr>
                <th></th>
                <th class="text-light">Plataforma</th>
                <th class="text-light">Opcion ID</th>
                <th class="text-light">Opcion Padre</th>
                <th class="text-light">Nombre</th>
                <th class="text-light">Enlace</th>
                <th class="text-light">Orden</th>
                <th class="text-light">Opciones</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>`;
};

var page_Load = () => {
    config.totalPeticiones = 2;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let dataPlataforma = config.variables['listaPlataforma'] || [];
        let listaPlataforma = dataPlataforma.map(x => Object.assign(x, { id: x.PlataformaId, text: x.Nombre }));

        listaOpcionPadre = config.variables['listaOpcionPadre'] || [];

        $("#cbbPlataformaId_Opcion").select2({ data: listaPlataforma, width: '100%', placeholder: '[SELECCIONE...]' });

        $("#cbbFiltroPlataformaId").select2({ data: listaPlataforma, width: '100%', placeholder: '[TODOS...]' });
        $("#cbbFiltroPlataformaId").trigger('change');

        $("#cbbOpcionPadreId_Opcion").select2({ width: '100%', placeholder: '[SELECCIONE...]' });
        $("#cbbFiltroOpcionPadreId").select2({ width: '100%', placeholder: '[TODOS...]' });

        $("#btnBuscar").on("click", btnBuscar_Click);
        $("#btnBuscar").click();
    };

    config.api.aprif.rest.plataforma.listarPlataforma('listaPlataforma');
    config.api.aprif.rest.opcion.listarOpcion(null, 'listaOpcionPadre');
};

var btnBuscar_Click = (e) => {
    e.preventDefault();
    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let data = config.variables['busquedaOpcion'] || [];

        tblOpcion = cargarDataTable('#tblOpcion', data, columnsOpcion);
    };

    let plataformaId = ($("#cbbFiltroPlataformaId").val() || '').trim() == '' ? null : $("#cbbFiltroPlataformaId").val().trim();
    let opcionId = $("#txtFiltroOpcionId").val().trim() == '' ? null : $("#txtFiltroOpcionId").val().trim();
    let opcionPadreId = ($("#cbbFiltroOpcionPadreId").val() || '').trim() == '' ? null : $("#cbbFiltroOpcionPadreId").val().trim();
    let nombre = $("#txtFiltroNombre").val().trim() == '' ? null : $("#txtFiltroNombre").val().trim();
    let enlace = $("#txtFiltroEnlace").val().trim() == '' ? null : $("#txtFiltroEnlace").val().trim();
    let orden = $("#txtFiltroOrden").val().trim() == '' ? null : $("#txtFiltroOrden").val().trim();

    config.api.aprif.rest.opcion.buscarOpcion(plataformaId, opcionId, opcionPadreId, nombre, enlace, orden, 'busquedaOpcion');
};

var cbbFiltroPlataforma_Change = (e) => {
    let plataformaId = $(e.currentTarget).val();

    let dataOpcionPadre = listaOpcionPadre.filter(x => x.PlataformaId == plataformaId).map(x => Object.assign(x, { id: x.OpcionId, text: x.Nombre }));

    $("#cbbFiltroOpcionPadreId").empty().select2({ data: dataOpcionPadre, width: '100%', placeholder: '[TODOS...]' });
    $("#cbbFiltroOpcionPadreId").val(null).trigger('change');
};

var cbbPlataforma_Change = (e) => {
    let plataformaId = $(e.currentTarget).val();

    let dataOpcionPadre = listaOpcionPadre.filter(x => x.PlataformaId == plataformaId).map(x => Object.assign(x, { id: x.OpcionId, text: x.Nombre }));

    $("#cbbOpcionPadreId_Opcion").empty().select2({ data: dataOpcionPadre, width: '100%', placeholder: '[SELECCIONE...]' });
    $("#cbbOpcionPadreId_Opcion").val(null).trigger('change');
};

var obtenerOpcion = (e) => {
    e.preventDefault();

    let plataformaId = $("#cbbPlataformaId_Opcion").val();
    let opcionId = $(e.currentTarget).attr("data-opcionid");

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        $("#btnGuardar").attr("data-accion", "E");

        let registroOpcion = config.variables["registroOpcion"];
        
        $("#cbbPlataformaId_Opcion").prop("disabled", true);

        $("#cbbPlataformaId_Opcion").val(registroOpcion.PlataformaId).trigger('change');
        $("#txtOpcionId_Opcion").val(registroOpcion.OpcionId);
        $("#cbbOpcionPadreId_Opcion").val(registroOpcion.OpcionPadreId).trigger('change');
        $("#txtNombre_Opcion").val(registroOpcion.Nombre);
        $("#txtEnlace_Opcion").val(registroOpcion.Enlace);

        $("#panelOpcion .panel-heading .panel-title ul li").removeClass('disabled');
        $("#panelOpcion .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().addClass('disabled');
        $("a[href='#tab-opcion']").tab('show');
        $("#btnNuevo").addClass('hidden');
        $("#btnGuardar").removeClass('hidden');
        $("#btnCancelar").removeClass('hidden');
    };

    config.api.aprif.rest.opcion.obtenerOpcion(plataformaId, opcionId, 'registroOpcion');
};

var columnsOpcion = [
    { className: 'details-control', orderable: false, data: null, defaultContent: '' },
    { data: "Plataforma.Nombre" },
    { data: "OpcionId" },
    { data: null, render: (data, type, row) => row.OpcionPadre == null ? '' : row.OpcionPadre.Nombre },
    { data: "Nombre" },
    { data: "Enlace" },
    { data: "Orden" },
    { data: null, render: (data, type, row) => `<button class="btn btn-warning btn-xs">BAJAR</button> <button class="btn btn-success btn-xs">SUBIR</button> <button class="btn btn-dark btn-xs" data-opcionid="${row.OpcionId}" onclick="obtenerOpcion(event)">EDITAR</button> <button class="btn btn-danger btn-xs">ELIMINAR</button>` },
];

var faIcon = {
    valid: 'fa fa-check-circle fa-lg text-success',
    invalid: 'fa fa-times-circle fa-lg',
    validating: 'fa fa-refresh'
}

var btnNuevo_Click = (e) => {
    e.preventDefault();

    $("#panelOpcion .panel-heading .panel-title ul li").removeClass('disabled');
    $("#panelOpcion .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().addClass('disabled');
    $("a[href='#tab-opcion']").tab('show');
    $("#btnNuevo").addClass('hidden');
    $("#btnGuardar").removeClass('hidden');
    $("#btnCancelar").removeClass('hidden');
};

var limpiarOpcion = () => {
    $("#txtOpcionId_Opcion").val('');
    $("#txtIdentificador_Opcion").val('');
    $("#txtNombre_Opcion").val('');
}

var btnGuardar_Click = (e) => {
    debugger;
    e.preventDefault();

    $('#frmOpcion').data('bootstrapValidator').resetForm();
    $('[name*=_Opcion]').removeClass('val-exc');
    $('[name*=_Usuario], [name*=_Serie], [name*=_Sucursal]').addClass('val-exc');
    $('#frmOpcion').data('bootstrapValidator').validate();

    let isValid = $('#frmOpcion').data('bootstrapValidator').isValid();

    if (!isValid) return;

    let opcion = {};
    opcion.PlataformaId = $("#cbbPlataformaId_Opcion").val();
    opcion.OpcionId = $("#txtOpcionId_Opcion").val().trim() == "" ? -1 : $("#txtOpcionId_Opcion").val().trim();
    opcion.OpcionPadreId = ($("#cbbOpcionPadreId_Opcion").val() || "").trim() == "" ? null : $("#txtOpcionId_Opcion").val().trim();
    opcion.Nombre = $("#txtNombre_Opcion").val().trim();
    opcion.Enlace = $("#txtEnlace_Opcion").val().trim();

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let transaccionOpcion = config.variables["transaccionOpcion"];

        if (!transaccionOpcion) {
            $.niftyNoty({
                type: 'danger',
                icon: 'pli-like-2 icon-2x',
                message: '¡Ocurrió un error inesperado! Contactarse con el administrador del sistema',
                container: 'floating',
                floating: { position: 'top-center' },
                timer: 5000
            });

            return;
        }

        limpiarOpcion();

        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: '¡Se guardó correctamente el registro!',
            container: 'floating',
            floating: { position: 'top-center' },
            timer: 5000
        });

        $('#frmOpcion').data('bootstrapValidator').resetForm();

        $("a[href*='#tab-'] i").parent().parent().removeClass("bv-tab-error");
        $("a[href*='#tab-'] i").removeClass('text-success').removeClass('text-danger');

        $("#panelOpcion .panel-heading .panel-title ul li").addClass('disabled');
        $("#panelOpcion .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().removeClass('disabled');
        $("a[href='#tab-busqueda']").tab('show');
        $("#btnNuevo").removeClass('hidden');
        $("#btnGuardar").addClass('hidden');
        $("#btnCancelar").addClass('hidden');

        $("#btnBuscar").click();
    };

    config.api.aprif.rest.opcion.mantenerOpcion(opcion, 'transaccionOpcion');
};

var btnCancelar_Click = (e) => {
    e.preventDefault();

    $("#btnGuardar").attr("data-accion", "N");

    limpiarOpcion();

    $("a[href*='#tab-'] i").parent().parent().removeClass("bv-tab-error");
    $("a[href*='#tab-'] i").removeClass('text-success').removeClass('text-danger');

    $("#panelOpcion .panel-heading .panel-title ul li").addClass('disabled');
    $("#panelOpcion .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().removeClass('disabled');
    $("a[href='#tab-busqueda']").tab('show');
    $("#btnNuevo").removeClass('hidden');
    $("#btnGuardar").addClass('hidden');
    $("#btnCancelar").addClass('hidden');
};