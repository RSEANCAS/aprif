$(document).on('nifty.ready', function () {
    page_Load();

    $('#frmPlataforma').bootstrapValidator({
        excluded: [':disabled', '.val-exc'],
        feedbackIcons: faIcon,
        fields: {
            txtIdentificador_Plataforma: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Identificador'
                    },
                    stringLength: {
                        max: 100,
                        message: 'Debe ingresar máximo 100 caracteres'
                    }
                }
            },
            txtNombre_Plataforma: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Nombre'
                    },
                    stringLength: {
                        max: 100,
                        message: 'Debe ingresar máximo 100 caracteres'
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
});

var page_Load = () => {
    $("#btnBuscar").on("click", btnBuscar_Click);
    $("#btnBuscar").click();
};

var btnBuscar_Click = (e) => {
    e.preventDefault();
    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let data = config.variables['busquedaPlataforma'] || [];

        cargarDataTable('#tblPlataforma', data, columnsPlataforma);
    };

    let plataformaId = $("#txtFiltroPlataformaId").val().trim() == '' ? null : $("#txtFiltroPlataformaId").val().trim();
    let identificador = $("#txtFiltroIdentificador").val().trim() == '' ? null : $("#txtFiltroIdentificador").val().trim();
    let nombre = $("#txtFiltroNombre").val().trim() == '' ? null : $("#txtFiltroNombre").val().trim();

    config.api.aprif.rest.plataforma.buscarPlataforma(plataformaId, identificador, nombre, 'busquedaPlataforma');
};

var obtenerPlataforma = (e) => {
    e.preventDefault();

    let plataformaId = $(e.currentTarget).attr("data-plataformaid");

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        $("#btnGuardar").attr("data-accion", "E");

        let registroPlataforma = config.variables["registroPlataforma"];

        //$("#txtPlataformaId_Plataforma").prop("readonly", true);

        $("#txtPlataformaId_Plataforma").val(registroPlataforma.PlataformaId);
        $("#txtIdentificador_Plataforma").val(registroPlataforma.Identificador);
        $("#txtNombre_Plataforma").val(registroPlataforma.Nombre);

        $("#panelPlataforma .panel-heading .panel-title ul li").removeClass('disabled');
        $("#panelPlataforma .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().addClass('disabled');
        $("a[href='#tab-plataforma']").tab('show');
        $("#btnNuevo").addClass('hidden');
        $("#btnGuardar").removeClass('hidden');
        $("#btnCancelar").removeClass('hidden');
    };

    config.api.aprif.rest.plataforma.obtenerPlataforma(plataformaId, 'registroPlataforma');
};

var columnsPlataforma = [
    { data: "PlataformaId" },
    { data: "Identificador" },
    { data: "Nombre" },
    { data: null, render: (data, type, row) => `<button class="btn btn-dark btn-xs" data-plataformaid="${row.PlataformaId}" onclick="obtenerPlataforma(event)">EDITAR</button> <button class="btn btn-danger btn-xs">BAJA</a>` },
];

var faIcon = {
    valid: 'fa fa-check-circle fa-lg text-success',
    invalid: 'fa fa-times-circle fa-lg',
    validating: 'fa fa-refresh'
}

var btnNuevo_Click = (e) => {
    e.preventDefault();

    $("#panelPlataforma .panel-heading .panel-title ul li").removeClass('disabled');
    $("#panelPlataforma .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().addClass('disabled');
    $("a[href='#tab-plataforma']").tab('show');
    $("#btnNuevo").addClass('hidden');
    $("#btnGuardar").removeClass('hidden');
    $("#btnCancelar").removeClass('hidden');
};

var limpiarPlataforma = () => {
    $("#txtPlataformaId_Plataforma").val('');
    $("#txtIdentificador_Plataforma").val('');
    $("#txtNombre_Plataforma").val('');
}

var btnGuardar_Click = (e) => {
    debugger;
    e.preventDefault();

    $('#frmPlataforma').data('bootstrapValidator').resetForm();
    $('[name*=_Plataforma]').removeClass('val-exc');
    $('[name*=_Usuario], [name*=_Serie], [name*=_Sucursal]').addClass('val-exc');
    $('#frmPlataforma').data('bootstrapValidator').validate();

    let isValid = $('#frmPlataforma').data('bootstrapValidator').isValid();

    if (!isValid) return;

    let plataforma = {};
    plataforma.PlataformaId = $("#txtPlataformaId_Plataforma").val().trim() == "" ? -1 : $("#txtPlataformaId_Plataforma").val().trim();
    plataforma.Identificador = $("#txtIdentificador_Plataforma").val().trim();
    plataforma.Nombre = $("#txtNombre_Plataforma").val().trim();

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let transaccionPlataforma = config.variables["transaccionPlataforma"];

        if (!transaccionPlataforma) {
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

        limpiarPlataforma();

        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: '¡Se guardó correctamente el registro!',
            container: 'floating',
            floating: { position: 'top-center' },
            timer: 5000
        });

        $('#frmPlataforma').data('bootstrapValidator').resetForm();

        $("a[href*='#tab-'] i").parent().parent().removeClass("bv-tab-error");
        $("a[href*='#tab-'] i").removeClass('text-success').removeClass('text-danger');

        $("#panelPlataforma .panel-heading .panel-title ul li").addClass('disabled');
        $("#panelPlataforma .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().removeClass('disabled');
        $("a[href='#tab-busqueda']").tab('show');
        $("#btnNuevo").removeClass('hidden');
        $("#btnGuardar").addClass('hidden');
        $("#btnCancelar").addClass('hidden');

        $("#btnBuscar").click();
    };

    config.api.aprif.rest.plataforma.mantenerPlataforma(plataforma, 'transaccionPlataforma');
};

var btnCancelar_Click = (e) => {
    e.preventDefault();

    $("#btnGuardar").attr("data-accion", "N");

    limpiarPlataforma();

    $("a[href*='#tab-'] i").parent().parent().removeClass("bv-tab-error");
    $("a[href*='#tab-'] i").removeClass('text-success').removeClass('text-danger');

    $("#panelPlataforma .panel-heading .panel-title ul li").addClass('disabled');
    $("#panelPlataforma .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().removeClass('disabled');
    $("a[href='#tab-busqueda']").tab('show');
    $("#btnNuevo").removeClass('hidden');
    $("#btnGuardar").addClass('hidden');
    $("#btnCancelar").addClass('hidden');
};