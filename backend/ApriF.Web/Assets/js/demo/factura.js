var listaDetalle = []

$(document).on('nifty.ready', function () {
   
    $('#demo-dp-component .input-group.date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        todayHighlight: true,
        todayBtn: "linked",
        text:Date.now
    });

    page_Load();

    TipoCalculo($('input[name=inline-form-radio]:checked', '#tipocalculo').val())

    /*$('#frmfactura').bootstrapValidator({
        excluded: [':disabled'],
        feedbackIcons: faIcon,
        fields: {
            txtNumeroDocumentoIdentidad: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese el dato mierda o de Identidad'
                    }
                }
            },
            rSocial: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese el nombre o razón social'
                    }
                }
            },
            direccion: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese la Dirección'
                    }
                }
            },
            phoneNumber: {
                validators: {
                    notEmpty: {
                        message: 'The address is required'
                    }
                }
            },
            cit: {
                validators: {
                    notEmpty: {
                        message: 'The city is required'
                    }
                }
            },
            country: {
                validators: {
                    notEmpty: {
                        message: 'The city is required'
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
    });*/

});

var page_Load = () => {
    cargarDataTable('#tblDetalle', listaDetalle, columnsDetalle);
    config.cantidadPeticiones = 0;
    config.totalPeticiones = 6;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        /*$("#cbbDireccionFiscal_Emisor").select2({ width: '100%', placeholder: '[SELECCIONE...]' });
        $("#cbbDepartamentoId_Sucursal").select2({ data: listaDepartamento, width: '100%', placeholder: '[SELECCIONE...]' });
        $("#cbbDepartamentoId_SucursalModal").select2({ data: listaDepartamento, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') });
        $("#cbbProvinciaId_Sucursal").select2({ data: listaProvincia, width: '100%', placeholder: '[SELECCIONE...]' });
        $("#cbbProvinciaId_SucursalModal").select2({ data: listaProvincia, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') });
        $("#cbbDistritoId_Sucursal").select2({ data: listaDistrito, width: '100%', placeholder: '[SELECCIONE...]' });
        $("#cbbDistritoId_SucursalModal").select2({ data: listaDistrito, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') });

        let dataTipoComprobante = config.variables['listaTipoComprobante'] || [];
        let listaTipoComprobante = dataTipoComprobante.map(x => Object.assign(x, { id: x.TipoComprobanteId, text: x.Descripcion }));

        $("#cbbTipoComprobanteId_Serie").select2({ data: listaTipoComprobante, width: '100%', placeholder: '[SELECCIONE...]' });*/

        //NEW
        listaTipoOperacion = config.variables['listaTipoOperacion'] || [];
        let dataTipoOperacion = listaTipoOperacion.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.Id, text: item.Descripcion }); });
        $("#cmbtipooperacion").select2({ data: dataTipoOperacion, width: '100%', placeholder: '[SELECCIONE...]' });

        listatipomoneda = config.variables['listatipomoneda'] || [];
        let datatipomoneda = listatipomoneda.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.Id, text: item.Descripcion }); });
        $("#cmbtipomoneda").select2({ data: datatipomoneda, width: '100%', placeholder: '[SELECCIONE...]' });

        listaserieportipo = config.variables['listaserieportipo'] || [];
        let dataSeriePorTipo = listaserieportipo.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.SerieId, text: item.SerieId }); });
        $("#cmbserie").select2({ data: dataSeriePorTipo, width: '100%', placeholder: '[SELECCIONE...]' });

        listatipodocumentoidentidad = config.variables['listatipodocumentoidentidad'] || [];
        let datatipodocumentoidentidad = listatipodocumentoidentidad.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.Id, text: item.Descripcion }); });
        $("#cmbtipodocumentoidentidad").select2({ data: datatipodocumentoidentidad, width: '100%', placeholder: '[SELECCIONE...]' });

        listatipoafectacionigv = config.variables['listatipoafectacionigv'] || [];
        let datatipoafectacionigv = listatipoafectacionigv.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.Id, text: item.Descripcion }); });
        $("#cmbtipoafectacionigv").select2({ data: datatipoafectacionigv, width: '100%', placeholder: '[SELECCIONE...]' });

        listaunidadmedida = config.variables['listaunidadmedida'] || [];
        let dataunidadmedida = listaunidadmedida.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.Id, text: item.Descripcion }); });
        $("#det_unidadmedida").select2({ data: dataunidadmedida, width: '100%', placeholder: '[SELECCIONE...]' });

        /*listatipotributo = config.variables['listatipotributo'] || [];
        let datatipotributo = listatipotributo.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.Id, text: item.Descripcion }); });
        $("#cmbtipotributo").select2({ data: datatipotributo, width: '100%', placeholder: '[SELECCIONE...]' });*/

        /*$("#txtEmisorId_Emisor").val(registroEmisor.EmisorId);
        $("#txtRazonSocial_Emisor").val(registroEmisor.RazonSocial);
        $("#txtNombreComercial_Emisor").val(registroEmisor.NombreComercial);
        $("#txtEslogan_Emisor").val(registroEmisor.Eslogan);*/

        //fin NEW


        /*  listaPais = config.variables['listaPais'] || [];
          let dataPais = listaPais.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.PaisId, text: item.Nombre }); });
  
          $("#cbbPaisId_Sucursal").select2({ data: dataPais, width: '100%', placeholder: '[SELECCIONE...]' });
          $("#cbbPaisId_SucursalModal").select2({ data: dataPais, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') });
  
          listaDepartamento = config.variables['listaDepartamento'] || [];
          listaProvincia = config.variables['listaProvincia'] || [];
          listaDistrito = config.variables['listaDistrito'] || [];*/


    };

    config.api.aprif.rest.tipooperacion.listarTipoOperacion('listaTipoOperacion');
    config.api.aprif.rest.tipomoneda.listartipomoneda('listatipomoneda');
    config.api.aprif.rest.serie.listarSeriePorTipo('10762193987', '01', 'listaserieportipo');
    config.api.aprif.rest.tipodocumentoidentidad.listartipodocumentoidentidad('listatipodocumentoidentidad');
    config.api.aprif.rest.tipoafectacionigv.listartipoafectacionigv('listatipoafectacionigv');
    config.api.aprif.rest.unidadmedida.listarunidadmedida('listaunidadmedida');
    //config.api.aprif.rest.tipotributo.listartipotributo('listatipotributo');


    /*config.api.aprif.rest.tipoComprobante.listarTipoComprobante('listaTipoComprobante');
    config.api.aprif.rest.pais.listarPais('listaPais');
    config.api.aprif.rest.departamento.listarDepartamento(null, 'listaDepartamento');
    config.api.aprif.rest.provincia.listarProvincia(null, null, 'listaProvincia');
    config.api.aprif.rest.distrito.listarDistrito(null, null, null, 'listaDistrito');*/
};

var buscacliente = () => {
    config.cantidadPeticiones = 0;
    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let registrocliente = config.variables['listacliente'] || [];
        $("#txtNombres").val(registrocliente.Nombre);

        listaSucursal = registrocliente.ListaSucursal || [];
        let listaDireccionFiscal = listaSucursal.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: x.SucursalId, text: `${x.Nombre} - ${x.Direccion} | ${x.Ubigeo}` }); });
        if ($("#cmbdireccion").data("select2") != null) $("#cmbdireccion").select2("destroy");
        $("#cmbdireccion").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });
    };

    let clienteId = $("#txtNumeroDocumentoIdentidad").val();
    let tipodocumentoid = $("#cmbtipodocumentoidentidad").val();

    config.api.aprif.rest.cliente.obtenerCliente('', clienteId, tipodocumentoid, 'listacliente');
};

var TipoCalculo = (val) => {
    
    switch (val) {
        case "VALORUNITARIO":
            $("#det_valorunitario").prop('disabled', false); //HABILITADO
            $("#det_valorunitario").focus();
            $("#det_importetotal").prop('disabled', true); //DESHABILITADO
            $("#det_preciounitario").prop('disabled', true); //DESHABILITADO

            break;
        case "PRECIOUNITARIO":
            $("#det_valorunitario").prop('disabled', true); //DESHABILITADO
            $("#det_importetotal").prop('disabled', true); //DESHABILITADO
            $("#det_preciounitario").prop('disabled', false); //HABILITADO
            $("#det_preciounitario").focus();

            break;
        case "IMPORTETOTAL":
            $("#det_valorunitario").prop('disabled', true); //desHABILITADO
            $("#det_importetotal").prop('disabled', false); //HABILITADO
            $("#det_preciounitario").prop('disabled', true); //desHABILITADO
            $("#det_importetotal").focus();
            break;
    }
};

var Calcula = (val) => {

    let cantidad = $("#det_cantidad").val();
    let descuento = $("#det_descuento").val();
    let otroscargos = parseFloat($("#det_otroscargos").val() || 0);
    let otrostributos = parseFloat($("#det_otrostributos").val() || 0);

    let valorunitario = 0;
    let preciounitario = 0;
    let valorventa = 0;
    let igv = 0;
    let importetotal = 0;

    switch (val) {
        case "VALORUNITARIO":
            valorunitario = $("#det_valorunitario").val();
            preciounitario = parseFloat(valorunitario * 1.18, 5).toFixed(config.cantdecimals);
            valorventa = parseFloat(cantidad * valorunitario - descuento).toFixed(config.cantdecimals);
            igv = parseFloat(cantidad * valorunitario * 0.18).toFixed(config.cantdecimals);
            importetotal = parseFloat(valorventa + igv + otroscargos + otrostributos).toFixed(config.cantdecimals);

            break;
        case "PRECIOUNITARIO":
            preciounitario = $("#det_preciounitario").val();
            valorunitario = parseFloat(preciounitario / 1.18).toFixed(config.cantdecimals);
            valorventa = parseFloat(cantidad * valorunitario - descuento).toFixed(config.cantdecimals);
            igv = parseFloat(cantidad * valorunitario * 0.18).toFixed(config.cantdecimals);
            importetotal = parseFloat(valorventa + igv + otroscargos + otrostributos).toFixed(config.cantdecimals);


            break;
        case "IMPORTETOTAL":

            break;
    }

    $("#det_preciounitario").val(preciounitario);
    $("#det_valorunitario").val(valorunitario);
    $("#det_valorventa").val(valorventa);
    $("#det_igv").val(igv);
    $("#det_importetotal").val(importetotal);

};

var btnAgregarDetalle_Click = () => {
    validadetalle();

    let DetalleId = 1;
    let CodigoId = $("#det_codigo").val();
    let Descripcion = $("#det_descripcion").val();
    let UnidadMedidadId = $("#det_unidadmedida").val();
    let UnidadMedidadDescripcion = $("#det_unidadmedida option:selected").text();
    let CodigoSunat = $("#det_codigosunat").val();
    let AfectacionIgvId = $("#cmbtipoafectacionigv").val();
    let Concepto = "";
    let Cantidad = $("#det_cantidad").val() || 0;
    let ValorUnitaro = $("#det_valorunitario").val() || 0;
    let PrecioUnitario = $("#det_preciounitario").val() || 0;
    let Descuento = $("#det_descuento").val() || 0;
    let DescuentoPorcentaje = "0" || 0;
    let BaseImponible = $("#det_valorventa").val() || 0;
    let Isc = $("#det_isc").val() || 0;
    let IscPorcentaje = "" || 0;
    let Igv = $("#det_igv").val() || 0;
    let IgvPorcentaje = 0 || 0;
    let OtrosCargos = $("#det_otroscargos").val() || 0;
    let OtrosCargosPorcentaje = 0 || 0;
    let OtrosTributos = $("#det_otrostributos").val() || 0;
    let OtrosTributosPorcentaje = 0 || 0;
    let ICBPERCantidad = 0 || 0;
    let ICBPERMonto = 0 || 0;
    let ICBPERTotal = 0 || 0;
    let ImporteVenta = $("#det_importetotal").val() || 0;

    let itemDetalle = {};
    itemDetalle =
    {
        EmisorId: null,
        Serie: null,
        Numero: 0,
        DetalleId: DetalleId,
        CodigoId: CodigoId,
        Descripcion: Descripcion,
        UnidadMedidadId: UnidadMedidadId,
        UnidadMedida: { Id: UnidadMedidadId, Descripcion: UnidadMedidadDescripcion },
        CodigoSunat: CodigoSunat,
        AfectacionIgvId: AfectacionIgvId,
        Concepto: Concepto,
        Cantidad: Cantidad,
        ValorUnitaro: ValorUnitaro,
        PrecioUnitario: PrecioUnitario,
        Descuento: Descuento,
        DescuentoPorcentaje: DescuentoPorcentaje,
        BaseImponible: BaseImponible,
        Isc: Isc,
        IscPorcentaje: IscPorcentaje,
        Igv: Igv,
        IgvPorcentaje: IgvPorcentaje,
        OtrosCargos: OtrosCargos,
        OtrosCargosPorcentaje: OtrosCargosPorcentaje,
        OtrosTributos: OtrosTributos,
        OtrosTributosPorcentaje: OtrosTributosPorcentaje,
        ICBPERCantidad: ICBPERCantidad,
        ICBPERMonto: ICBPERMonto,
        ICBPERTotal: ICBPERTotal,
        ImporteVenta: ImporteVenta
    };

    listaDetalle.push(itemDetalle);

    cargarDataTable('#tblDetalle', listaDetalle, columnsDetalle);

    /*if (accion == "A") {
        itemSerie =
        {
            EmisorId: null,
            TipoComprobanteId: tipoComprobanteId,
            TipoComprobante: { TipoComprobanteId: tipoComprobanteId, Descripcion: tipoComprobanteDescripcion },
            SerieId: serieId,
            Inicial: inicial,
            Final: final,
            Actual: actual,
            EsSerieFisica: esSerieFisica,
            Fila: null,
            ModificadoPor: null,
            IpModificacion: null
        };

        listaSerie.push(itemSerie);
    } else if (accion == "E") {
        itemSerie = listaSerie.find(x => x.TipoComprobanteId == tipoComprobanteIdKey && x.SerieId == serieIdKey);

        let indexSerie = listaSerie.findIndex(x => x.TipoComprobanteId == tipoComprobanteIdKey && x.SerieId == serieIdKey);

        itemSerie.TipoComprobanteId = tipoComprobanteId;
        itemSerie.TipoComprobante = { TipoComprobanteId: tipoComprobanteId, Descripcion: tipoComprobanteDescripcion };
        itemSerie.SerieId = serieId;
        itemSerie.Inicial = inicial;
        itemSerie.Final = final;
        itemSerie.Actual = actual;
        itemSerie.EsSerieFisica = esSerieFisica;

        listaSerie[indexSerie] = itemSerie;

        let btnEditarSerie = $("#btnAgregarSerie")[0];
        let btnCancelarSerie = $("#btnCancelarSerie")[0];

        let htmlBtn = 'AGREGAR <i class="ion-plus"></i>';

        $(btnEditarSerie).html(htmlBtn);
        $(btnEditarSerie).attr("data-accion", "A");
        $(btnEditarSerie).removeClass("btn-success").addClass("btn-dark");
        $(btnEditarSerie).parent().addClass("col-sm-offset-6");
        $(btnCancelarSerie).parent().addClass("hidden");
    }*/
    /*
    listaSerie.forEach((item, index) => item.Fila = index + 1);

    cargarDataTable('#tblSerie', listaSerie, columnsSerie);

    $("#txtCantidadSeries_Emisor").val(listaSerie.length);

    limpiarSerie();

    $(selectorForm).data('bootstrapValidator').resetForm();*/
};

var btnEliminarDetalle_Click = (e) => {
    e.preventDefault();
    let codigoId = $(e.currentTarget).attr("data-CodigoId");
    bootbox.confirm("¿Estás seguro de eliminar el registro?", function (result) {
        if (result) {
            let indexDetalle = listaDetalle.findIndex(x => x.CodigoId == codigoId);
            listaDetalle.splice(indexDetalle, 1);
            cargarDataTable('#tblDetalle', listaDetalle, columnsDetalle);
        };
    });
};

var columnsDetalle = [
    { data: 'UnidadMedidadId' },
    { data: 'Descripcion' },
    { data: 'Cantidad' },
    { data: 'PrecioUnitario' },
    { data: 'Descuento' },
    { data: 'ImporteVenta' },
    { data: null, render: (data, type, row) => `<button class="btn btn-dark btn-xs btn-rounded" data-CodigoId="${row.CodigoId}" onclick="btnObtenerDetalle_Click(event)">EDITAR</a> <button class="btn btn-danger btn-xs btn-rounded" data-CodigoId="${row.CodigoId}" onclick="btnEliminarDetalle_Click(event)">ELIMINAR</a>` }
];

var vp_columnsDetalle = [
    { data: 'UnidadMedidadId' },
    { data: 'Descripcion' },
    { data: 'Cantidad' },
    { data: 'PrecioUnitario' },
    { data: 'Descuento' },
    { data: 'ImporteVenta' }
];

var cargarDataTable = (selector, data, columns) => {
    $(selector).DataTable({
        "destroy": true,
        "data": data,
        "columns": columns,
        "responsive": true,
        "lengthChange": false,
        "searching": false,
        "language": {
            "paginate": {
                "previous": '<i class="demo-psi-arrow-left"></i>',
                "next": '<i class="demo-psi-arrow-right"></i>'
            }
        }
    });
};

var validadetalle = () => {
    alert("entro a validar");
    var faIcon = {
        valid: 'fa fa-check-circle fa-lg text-success',
        invalid: 'fa fa-times-circle fa-lg',
        validating: 'fa fa-refresh'
    };

    $("#demo-acd-purple-3").bootstrapValidator({
        excluded: ['disabled'],
        feedbackIcons: faIcon,
        fields: {
            det_descripcion: {
                validators: {
                    notEmpty: {
                        message: 'Debe de ingresar una descripción'
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
};

var EmiteFactura = () => {

    let SucursalId = 1;
    let TipoOperacion = $("#cmbtipooperacion").val();
    let Serie = $("#cmbserie").val();
    let FechaEmision = "2020-03-26 23:50:00";
    let FechaVencimiento = "2020-03-26 23:55:00";
    let TipoMonedaId = $("#cmbtipomoneda").val();
    let EmisorTipoDocumentoIdentidad = 6;
    let EmisorId = "10762193987";
    let EmisorRazonSocial = "LUIS JESUS YUPANQUI FLORES";
    let EmisorDireccion = "MZ S10 D LOTE 04, AA.HH. JOSE CARLOS MARIATEGUI";
    let EmisorUbigeoCodigo = "150206";
    let EmisorUbigeoDescripcion ="LIMA - LIMA - SAN JUAN DE LURIGANCHO";
    let EmisorCorreo = "luis_jyf@hotmail.com";
    let ClienteTipoDocumentoIdentidad = $("#cmbtipodocumentoidentidad").val();
    let ClienteId = $("#txtNumeroDocumentoIdentidad").val();
    let ClienteRazonSocial = $("#txtNombres").val();
    let ClienteDireccion =$("#cmbdireccion").text();
    let ClienteUbigeoCodigo = $("#cmbdireccion").val();
    let ClienteUbigeoDescripcion = $("#cmbdireccion").val();
    let ClienteCorreo = "cliente@correo.com";
    let TotalIgv = "18.00";
    let TotalIsc = "0.00";
    let TotalOtrosTributos = "0.00";
    let TotalOtrosCargos = "0.00";
    let TotalBaseImponible = "100.00";
    let TotalDescuento = "0.00";
    let TotalImporteVenta = "100.00";
    let TotalImportePagar = "118.00";
    let TotalICBPER = "0.00";
    let EsDetraccion = 0;
    let EsExportacion = 0;
    let EsComprobanteFisico = 0;
    let CreadoPor = "mi";
    let FechaCreacion = null;
    let IpCreacion = "";
    let ModificadoPor = "";
    let FechaModificacion = null;
    let IpModificacion = "";

    ofactura= {
        SucursalId: SucursalId,
        TipoOperacion: TipoOperacion,
        Serie: Serie,
        Numero: null,
        FechaEmision: FechaEmision,
        FechaVencimiento: FechaVencimiento,
        TipoMonedaId: TipoMonedaId,
        EmisorTipoDocumentoIdentidad: EmisorTipoDocumentoIdentidad,
        EmisorId: EmisorId,
        EmisorRazonSocial: EmisorRazonSocial,
        EmisorDireccion: EmisorDireccion,
        EmisorUbigeoCodigo: EmisorUbigeoCodigo,
        EmisorUbigeoDescripcion: EmisorUbigeoDescripcion,
        EmisorCorreo: EmisorCorreo,
        ClienteTipoDocumentoIdentidad: ClienteTipoDocumentoIdentidad,
        ClienteId: ClienteId,
        ClienteRazonSocial: ClienteRazonSocial,
        ClienteDireccion: ClienteDireccion,
        ClienteUbigeoCodigo: ClienteUbigeoCodigo,
        ClienteUbigeoDescripcion: ClienteUbigeoDescripcion,
        ClienteCorreo: ClienteCorreo,
        TotalIgv: TotalIgv,
        TotalIsc: TotalIsc,
        TotalOtrosTributos: TotalOtrosTributos,
        TotalOtrosCargos: TotalOtrosCargos,
        TotalBaseImponible: TotalBaseImponible,
        TotalDescuento: TotalDescuento,
        TotalImporteVenta: TotalImporteVenta,
        TotalImportePagar: TotalImportePagar,
        TotalICBPER: TotalICBPER,
        EsDetraccion: EsDetraccion,
        EsExportacion: EsExportacion,
        EsComprobanteFisico: EsComprobanteFisico,
        CreadoPor: CreadoPor,
        FechaCreacion: FechaCreacion,
        IpCreacion: IpCreacion,
        ModificadoPor: ModificadoPor,
        FechaModificacion: FechaModificacion,
        IpModificacion: IpModificacion,
        ListaFacturaDetalle: listaDetalle
    }

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);
    config.hacerAlFinalizarPeticion = () => {
        let transaccionEmisor = config.variables["transaccionfactura"];

        if (transaccionEmisor!="BIEN") {
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
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: '¡Se guardó correctamente el registro!',
            container: 'floating',
            floating: { position: 'top-center' },
            timer: 5000
        });

    };

    config.api.aprif.rest.factura.registrafactura(ofactura, 'transaccionfactura');
   
};

var DevuelveIp = () => {
    let ip = "";
    $.ajax({
        url: 'https://api.ipify.org/?format=jsonp&callback=getIP',
        dataType: 'jsonp',
        success: function (json) {

            alert(json.location.capital);
            ip = json.location.capital;
        }
    });
        return ip;
};

var ValidaTipoDocumentoCliente = (select) => {

    alert(select);
    if (select.substr(0, 2) == "02") {
        alert("bloquea");
        $("#cmbtipodocumentoidentidad option[value='1']").attr('disabled',true);
       /* $("#cmbtipodocumentoidentidad option").each(function () {
            let valopcion = $(this).attr('value');
            alert(valopcion);
            if (valopcion == "1" || valopcion == "6") {
                $(this).prop('disabled', true);
                $(this).attr('disabled', true);
                alert("bloquea");
            }
            //$("#det-valorunitario").prop('disabled', false); //HABILITADO
            //alert('opcion ' + $(this).text() + ' valor ' + $(this).attr('value'))
        });*/
    }

};

var BuscaProducto = () => {
   
    config.cantidadPeticiones = 0;
    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let productobuscado = config.variables['obtenerProducto'] || [];

        $("#det_codigosunat").val(productobuscado.CodigoSunat);
        $("#det_descripcion").val(productobuscado.Descripcion);
        $("#det_unidadmedida").val(productobuscado.UnidadMedidadId);
        $("#cmbtipoafectacionigv").val(productobuscado.TipoAfectacionIgvId);

        var oblig = $('input:radio[name=inline-form-radio]');
        

        switch (productobuscado.TipoCalculo) {
            case "VALORUNITARIO":
                $("#det_valorunitario").val(productobuscado.Monto);
                break;
            case "PRECIOUNITARIO":
                $("#det_preciounitario").val(productobuscado.Monto);
                break;
            case "IMPORTETOTAL":
                $("#det_importetotal").val(productobuscado.Monto);
                break;
        }
        oblig.filter('[value=' + productobuscado.TipoCalculo + ']').attr('checked', true);
        TipoCalculo(productobuscado.TipoCalculo);
        Calcula(productobuscado.TipoCalculo);
    };

    let ProductoId = $("#det_codigo").val();

    config.api.aprif.rest.producto.obtenerProducto("10762193987", ProductoId, 'obtenerProducto');
};

var vistapreliminar = () => {

    alert("entro vp");



    $("#vp_serie").text($("#cmbserie").val());
    $("#vp_cliente_tipodocumentoidentidad").text($("#cmbtipodocumentoidentidad option:selected").text());
    $("#vp_cliente_razonsocial").text($("#txtNombres").val());
    $("#vp_cliente_direccion").text($("#cmbdireccion option:selected").text());
    $("#vp_tipomoneda").text($("#cmbtipomoneda option:selected").text());


    cargarDataTable('#vp_tblDetalle', listaDetalle, vp_columnsDetalle);

};