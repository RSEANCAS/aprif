var listaSucursal = [], listaSerie = [], listaUsuario = [], listaSucursalUsuario = [], listaSerieUsuario = [], listaPais = [], listaDepartamento = [], listaProvincia = [], listaDistrito = [];

$(document).on('nifty.ready', function () {
    page_Load();

    cargarDataTable('#tblSucursal', listaSucursal, columnsSucursal);
    cargarDataTable('#tblSerie', listaSerie, columnsSerie);
    cargarDataTable('#tblUsuario', listaUsuario, columnsUsuario);

    $('#frmEmisor').bootstrapValidator({
        excluded: [':disabled', '.val-exc'],
        feedbackIcons: faIcon,
        fields: {
            txtEmisorId_Emisor: {
                validators: {
                    callback: {
                        callback: (input) => {
                            debugger;

                            let idEmisor = $("#txtEmisorId_Emisor").val();

                            if (idEmisor.length != 11) return true;

                            let accion = $("#btnGuardar").attr("data-accion");
                            if (accion != 'N') return false;

                            let existeEmisor = false;

                            let urlExisteEmisor = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.emisor.baseUrl}/existeemisor?emisorId=${idEmisor}`;

                            $.ajax({
                                url: urlExisteEmisor,
                                async: false,
                                success: (data) => {
                                    existeEmisor = !data;
                                }
                            });

                            return existeEmisor
                        },
                        message: 'El Ruc ya se encuentra registrado',
                    },
                    notEmpty: {
                        message: 'Ingrese RUC'
                    },
                    stringLength: {
                        min: 11,
                        max: 11,
                        message: 'Debe ingresar 11 caracteres'
                    }
                }
            },
            txtRazonSocial_Emisor: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Razón Social'
                    },
                    stringLength: {
                        max: 500,
                        message: 'Debe ingresar máximo 500 caracteres'
                    }
                }
            },
            txtNombreComercial_Emisor: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Nombre Comercial'
                    },
                    stringLength: {
                        max: 500,
                        message: 'Debe ingresar máximo 500 caracteres'
                    }
                }
            },
            txtEslogan_Emisor: {
                validators: {
                    callback: {
                        message: 'Debe ingresar máximo 500 caracteres',
                        callback: (input) => {
                            return (input || "").length <= 500;
                        }
                    }
                }
            },
            cbbDireccionFiscal_Emisor: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Dirección Fiscal'
                    }
                }
            },
            txtCantidadSucursales_Emisor: {
                container: '#msgErrorSucursal',
                validators: {
                    greaterThan: {
                        value: 1,
                        message: 'Debe ingresar mínimo una sucursal'
                    },
                    notEmpty: {
                        message: 'Debe ingresar mínimo una sucursal'
                    }
                }
            },
            txtCantidadSeries_Emisor: {
                container: '#msgErrorSerie',
                validators: {
                    greaterThan: {
                        value: 1,
                        message: 'Debe ingresar mínimo una serie'
                    },
                    notEmpty: {
                        message: 'Debe ingresar mínimo una serie'
                    }
                }
            },
            txtCantidadUsuarios_Emisor: {
                container: '#msgErrorUsuario',
                validators: {
                    greaterThan: {
                        value: 1,
                        message: 'Debe ingresar mínimo un usuario'
                    },
                    notEmpty: {
                        message: 'Debe ingresar mínimo un usuario'
                    }
                }
            },
            txtSucursalId_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Código'
                    },
                    stringLength: {
                        max: 50,
                        message: 'Debe ingresar máximo 50 caracteres'
                    }
                }
            },
            txtCodigoSUNAT_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Código SUNAT'
                    },
                    stringLength: {
                        max: 4,
                        message: 'Debe ingresar máximo 4 caracteres'
                    }
                }
            },
            txtNombre_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Nombre'
                    },
                    stringLength: {
                        max: 100,
                        message: 'Debe ingresar máximo 100 caracteres'
                    }
                }
            },
            txtDireccion_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Dirección'
                    }
                }
            },
            cbbPaisId_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Pais'
                    }
                }
            },
            cbbDepartamentoId_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Departamento'
                    }
                }
            },
            cbbProvinciaId_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Provincia'
                    }
                }
            },
            cbbDistritoId_Sucursal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Distrito'
                    }
                }
            },
            cbbTipoComprobanteId_Serie: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Tipo de Comprobante'
                    }
                }
            },
            txtSerieId_Serie: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Serie'
                    },
                    stringLength: {
                        min: 4,
                        max: 4,
                        message: 'Debe ingresar máximo 4 caracteres'
                    }
                }
            },
            txtInicial_Serie: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Inicial'
                    },
                    digits: {
                        message: 'El valor ingresado no es numérico'
                    }
                }
            },
            txtFinal_Serie: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Final'
                    },
                    digits: {
                        message: 'El valor ingresado no es numérico'
                    }
                }
            },
            txtActual_Serie: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Actual'
                    },
                    digits: {
                        message: 'El valor ingresado no es numérico'
                    }
                }
            },
            txtUsuarioId_Usuario: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Usuario'
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

    $('#frmsucursalmodal').bootstrapValidator({
        excluded: [':disabled', '.val-exc'],
        feedbackIcons: faIcon,
        fields: {
            txtSucursalId_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Código'
                    }
                }
            },
            txtCodigoSUNAT_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Código SUNAT'
                    }
                }
            },
            txtNombre_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Nombre'
                    }
                }
            },
            txtDireccion_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Ingrese Dirección'
                    }
                }
            },
            cbbPaisId_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Pais'
                    }
                }
            },
            cbbDepartamentoId_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Departamento'
                    }
                }
            },
            cbbProvinciaId_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Provincia'
                    }
                }
            },
            cbbDistritoId_SucursalModal: {
                validators: {
                    notEmpty: {
                        message: 'Seleccione Distrito'
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
    config.totalPeticiones = 5;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {

        $("#cbbDireccionFiscal_Emisor").select2({ width: '100%', placeholder: '[SELECCIONE...]' })
        $("#cbbDireccionFiscal_Emisor").trigger('change');
        $("#cbbDepartamentoId_Sucursal").select2({ data: listaDepartamento, width: '100%', placeholder: '[SELECCIONE...]' })
        $("#cbbDepartamentoId_Sucursal").trigger('change');
        $("#cbbDepartamentoId_SucursalModal").select2({ data: listaDepartamento, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') })
        $("#cbbDepartamentoId_SucursalModal").trigger('change');
        $("#cbbProvinciaId_Sucursal").select2({ data: listaProvincia, width: '100%', placeholder: '[SELECCIONE...]' })
        $("#cbbProvinciaId_Sucursal").trigger('change');
        $("#cbbProvinciaId_SucursalModal").select2({ data: listaProvincia, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') })
        $("#cbbProvinciaId_SucursalModal").trigger('change');
        $("#cbbDistritoId_Sucursal").select2({ data: listaDistrito, width: '100%', placeholder: '[SELECCIONE...]' })
        $("#cbbDistritoId_Sucursal").trigger('change');
        $("#cbbDistritoId_SucursalModal").select2({ data: listaDistrito, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') })
        $("#cbbDistritoId_SucursalModal").trigger('change');

        let dataTipoComprobante = config.variables['listaTipoComprobante'] || [];
        let listaTipoComprobante = dataTipoComprobante.map(x => Object.assign(x, { id: x.TipoComprobanteId, text: x.Descripcion }));

        $("#cbbTipoComprobanteId_Serie").select2({ data: listaTipoComprobante, width: '100%', placeholder: '[SELECCIONE...]' })
        $("#cbbTipoComprobanteId_Serie").trigger('change');

        listaPais = config.variables['listaPais'] || [];
        let dataPais = listaPais.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.PaisId, text: item.Nombre }); });

        $("#cbbPaisId_Sucursal").select2({ data: dataPais, width: '100%', placeholder: '[SELECCIONE...]' })
        $("#cbbPaisId_Sucursal").trigger('change');
        $("#cbbPaisId_SucursalModal").select2({ data: dataPais, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') })
        $("#cbbPaisId_SucursalModal").trigger('change');

        listaDepartamento = config.variables['listaDepartamento'] || [];
        listaProvincia = config.variables['listaProvincia'] || [];
        listaDistrito = config.variables['listaDistrito'] || [];

        $('#frmEmisor').data('bootstrapValidator').resetForm();
        $("a[href*='#tab-'] i").parent().parent().removeClass("bv-tab-error");
        $("a[href*='#tab-'] i").removeClass('text-success').removeClass('text-danger');

        $("#btnBuscar").on("click", btnBuscar_Click);
        $("#btnBuscar").click();
    };

    config.api.aprif.rest.tipoComprobante.listarTipoComprobante('listaTipoComprobante');
    config.api.aprif.rest.pais.listarPais('listaPais');
    config.api.aprif.rest.departamento.listarDepartamento(null, 'listaDepartamento');
    config.api.aprif.rest.provincia.listarProvincia(null, null, 'listaProvincia');
    config.api.aprif.rest.distrito.listarDistrito(null, null, null, 'listaDistrito');
};

var btnBuscar_Click = (e) => {
    e.preventDefault();
    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let data = config.variables['busquedaEmisor'] || [];

        cargarDataTable('#tblEmisor', data, columnsEmisor);
    };

    let emisorId = $("#txtFiltroEmisorId").val();
    let razonSocial = $("#txtFiltroRazonSocial").val();
    let nombreComercial = $("#txtFiltroNombreComercial").val();
    let eslogan = $("#txtFiltroEslogan").val();
    let deBaja = null;

    config.api.aprif.rest.emisor.buscarEmisor(emisorId, razonSocial, nombreComercial, eslogan, deBaja, 'busquedaEmisor');
};

var cbbPais_Change = (e) => {
    let idCbb = $(e.currentTarget).attr("id");
    let paisId = $(`#${idCbb}`).val();

    let dataDepartamento = listaDepartamento.filter(x => x.PaisId == paisId).map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.DepartamentoId, text: item.Nombre }); });

    if (idCbb.toLowerCase().includes("modal")) {
        if ($("#cbbDepartamentoId_SucursalModal").data("select2") != null) $("#cbbDepartamentoId_SucursalModal").select2("destroy");
        $("#cbbDepartamentoId_SucursalModal").empty().select2({ data: dataDepartamento, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') });
        $("#cbbDepartamentoId_SucursalModal").change();
    } else {
        if ($("#cbbDepartamentoId_Sucursal").data("select2") != null) $("#cbbDepartamentoId_Sucursal").select2("destroy");
        $("#cbbDepartamentoId_Sucursal").empty().select2({ data: dataDepartamento, width: '100%', placeholder: '[SELECCIONE...]' });
        $("#cbbDepartamentoId_Sucursal").change();
    }
};

var cbbDepartamento_Change = (e) => {
    let idCbb = $(e.currentTarget).attr("id");
    let idPaisCbb = idCbb.toLowerCase().includes("modal") ? "#cbbPaisId_SucursalModal" : "#cbbPaisId_Sucursal";
    let paisId = $(idPaisCbb).val();
    let departamentoId = $(`#${idCbb}`).val();

    let dataProvincia = listaProvincia.filter(x => x.PaisId == paisId && x.DepartamentoId == departamentoId).map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.ProvinciaId, text: item.Nombre }); });

    if (idCbb.toLowerCase().includes("modal")) {
        if ($("#cbbProvinciaId_SucursalModal").data("select2") != null) $("#cbbProvinciaId_SucursalModal").select2("destroy");
        $("#cbbProvinciaId_SucursalModal").empty().select2({ data: dataProvincia, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') });
        $("#cbbProvinciaId_SucursalModal").change();
    } else {
        if ($("#cbbProvinciaId_Sucursal").data("select2") != null) $("#cbbProvinciaId_Sucursal").select2("destroy");
        $("#cbbProvinciaId_Sucursal").empty().select2({ data: dataProvincia, width: '100%', placeholder: '[SELECCIONE...]' });
        $("#cbbProvinciaId_Sucursal").change();
    }
};

var cbbProvincia_Change = (e) => {
    let idCbb = $(e.currentTarget).attr("id");
    let idPaisCbb = idCbb.toLowerCase().includes("modal") ? "#cbbPaisId_SucursalModal" : "#cbbPaisId_Sucursal";
    let paisId = $(idPaisCbb).val();
    let idDepartamentoCbb = idCbb.toLowerCase().includes("modal") ? "#cbbDepartamentoId_SucursalModal" : "#cbbDepartamentoId_Sucursal";
    let departamentoId = $(idDepartamentoCbb).val();
    let provinciaId = $(`#${idCbb}`).val();

    let dataDistrito = listaDistrito.filter(x => x.PaisId == paisId && x.DepartamentoId == departamentoId && x.ProvinciaId == provinciaId).map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.DistritoId, text: item.Nombre }); });

    if (idCbb.toLowerCase().includes("modal")) {
        if ($("#cbbDistritoId_SucursalModal").data("select2") != null) $("#cbbDistritoId_SucursalModal").select2("destroy");
        $("#cbbDistritoId_SucursalModal").empty().select2({ data: dataDistrito, width: '100%', placeholder: '[SELECCIONE...]', dropdownParent: $('#frm-sucursal-modal') });
    } else {
        if ($("#cbbDistritoId_Sucursal").data("select2") != null) $("#cbbDistritoId_Sucursal").select2("destroy");
        $("#cbbDistritoId_Sucursal").empty().select2({ data: dataDistrito, width: '100%', placeholder: '[SELECCIONE...]' });
    }
};

var obtenerSunatEmisor = (e) => {
    let accion = $("#btnGuardar").attr("data-accion");

    if (accion == "E") return;

    let emisorId = $("#txtEmisorId_Emisor").val();

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let registroEmisor = config.variables["registroEmisor"];

        if (registroEmisor == null) {
            registroEmisor = {
                EmisorId: '',
                RazonSocial: '',
                NombreComercial: '',
                Eslogan: '',
                ListaSucursal: []
            };
        }

        $("#txtEmisorId_Emisor").val(registroEmisor.EmisorId);
        $("#txtRazonSocial_Emisor").val(registroEmisor.RazonSocial);
        $("#txtNombreComercial_Emisor").val(registroEmisor.NombreComercial);
        $("#txtEslogan_Emisor").val(registroEmisor.Eslogan);

        listaSucursal = registroEmisor.ListaSucursal || [];

        cargarDataTable('#tblSucursal', listaSucursal, columnsSucursal);

        $("#txtCantidadSucursales_Emisor").val(listaSucursal.length);

        let listaDireccionFiscal = listaSucursal.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: x.SucursalId, text: `${x.Nombre} - ${x.Direccion}` }); });

        if ($("#cbbDireccionFiscal_Emisor").data("select2") != null) $("#cbbDireccionFiscal_Emisor").select2("destroy");
        $("#cbbDireccionFiscal_Emisor").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });

        let sucursalFiscal = listaSucursal.find(x => x.FlagDireccionFiscal);

        if (sucursalFiscal != null) {
            $("#cbbDireccionFiscal_Emisor").val(sucursalFiscal.SucursalId);
            $("#cbbDireccionFiscal_Emisor").trigger("change");
        }
    };

    config.api.aprif.rest.emisor.obtenerSunatEmisor(emisorId, 'registroEmisor');
}

var obtenerEmisor = (e) => {
    e.preventDefault();

    let emisorId = $(e.currentTarget).attr("data-emisorid");

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        $("#btnGuardar").attr("data-accion", "E");

        let registroEmisor = config.variables["registroEmisor"];

        $("#txtEmisorId_Emisor").prop("readonly", true);

        $("#txtEmisorId_Emisor").val(registroEmisor.EmisorId);
        $("#txtRazonSocial_Emisor").val(registroEmisor.RazonSocial);
        $("#txtNombreComercial_Emisor").val(registroEmisor.NombreComercial);
        $("#txtEslogan_Emisor").val(registroEmisor.Eslogan);

        listaSucursal = registroEmisor.ListaSucursal || [];

        cargarDataTable('#tblSucursal', listaSucursal, columnsSucursal);

        $("#txtCantidadSucursales_Emisor").val(listaSucursal.length);

        let listaDireccionFiscal = listaSucursal.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: x.SucursalId, text: `${x.Nombre} - ${x.Direccion}` }); });

        if ($("#cbbDireccionFiscal_Emisor").data("select2") != null) $("#cbbDireccionFiscal_Emisor").select2("destroy");
        $("#cbbDireccionFiscal_Emisor").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });

        let sucursalFiscal = listaSucursal.find(x => x.FlagDireccionFiscal);

        if (sucursalFiscal != null) {
            $("#cbbDireccionFiscal_Emisor").val(sucursalFiscal.SucursalId);
            $("#cbbDireccionFiscal_Emisor").trigger("change");
        }

        listaSerie = registroEmisor.ListaSerie || [];

        cargarDataTable('#tblSerie', listaSerie, columnsSerie);

        $("#txtCantidadSeries_Emisor").val(listaSerie.length);

        listaUsuario = registroEmisor.ListaUsuario || [];

        cargarDataTable('#tblUsuario', listaUsuario, columnsUsuario);

        $("#txtCantidadUsuarios_Emisor").val(listaUsuario.length);

        $("#panelEmisor .panel-heading .panel-title ul li").removeClass('disabled');
        $("#panelEmisor .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().addClass('disabled');
        $("a[href='#tab-emisor']").tab('show');
        $("#btnNuevo").addClass('hidden');
        $("#btnGuardar").removeClass('hidden');
        $("#btnCancelar").removeClass('hidden');
    };

    config.api.aprif.rest.emisor.obtenerEmisor(emisorId, 'registroEmisor');
};

var columnsEmisor = [
    { data: "EmisorId" },
    { data: "RazonSocial" },
    { data: "NombreComercial" },
    { data: "Eslogan" },
    { data: null, render: (data, type, row) => `${(row.DeBaja ? "SI" : "NO")}` },
    { data: null, render: (data, type, row) => `<button class="btn btn-dark btn-xs" data-emisorid="${row.EmisorId}" onclick="obtenerEmisor(event)">EDITAR</button> <button class="btn btn-danger btn-xs">BAJA</a>` },
];

var columnsUsuario = [
    { data: 'Fila' },
    { data: 'UsuarioId' },
    { data: null, render: (data, type, row) => (row.FlagResetearClave ? "SI" : "NO") },
    { data: null, render: (data, type, row) => `<button class="btn btn-dark btn-xs" data-usuarioid="${row.UsuarioId}" onclick="btnObtenerUsuario_Click(event)">EDITAR</button> <button class="btn btn-danger btn-xs" data-usuarioid="${row.UsuarioId}" onclick="btnEliminarUsuario_Click(event)">ELIMINAR</a>` }
];

var columnsSerie = [
    { data: 'Fila' },
    { data: 'TipoComprobante.Descripcion' },
    { data: 'SerieId' },
    { data: 'Inicial' },
    { data: 'Final' },
    { data: 'Actual' },
    { data: null, render: (data, type, row) => (row.EsSerieFisica ? "SI" : "NO") },
    { data: null, render: (data, type, row) => `<button class="btn btn-dark btn-xs" data-tipocomprobanteid="${row.TipoComprobanteId}" data-serieid="${row.SerieId}" onclick="btnObtenerSerie_Click(event)">EDITAR</button> <button class="btn btn-danger btn-xs" data-tipocomprobanteid="${row.TipoComprobanteId}" data-serieid="${row.SerieId}" onclick="btnEliminarSerie_Click(event)">ELIMINAR</a>` }
];

var columnsSucursal = [
    { data: 'Fila' },
    { data: 'SucursalId' },
    { data: 'CodigoSunat' },
    { data: 'Nombre' },
    { data: 'Direccion' },
    { data: 'Referencia' },
    { data: null, render: (data, type, row) => (row.FlagDireccionFiscal ? "SI" : "NO") },
    { data: null, render: (data, type, row) => `<button class="btn btn-info btn-xs" data-vista="sucursal" data-sucursalid="${row.SucursalId}" onclick="btnVerUsuarioSucursal_Click(event)">VER USUARIOS</button> <button class="btn btn-dark btn-xs" data-sucursalid="${row.SucursalId}" onclick="btnObtenerSucursal_Click(event)">EDITAR</button> <button class="btn btn-danger btn-xs" data-sucursalid="${row.SucursalId}" onclick="btnEliminarSucursal_Click(event)">ELIMINAR</a>` }
];

var faIcon = {
    valid: 'fa fa-check-circle fa-lg text-success',
    invalid: 'fa fa-times-circle fa-lg',
    validating: 'fa fa-refresh'
}

var btnAgregarSucursal_Click = (e) => {
    let accion = $(e.currentTarget).attr("data-accion");

    let tipo = $(e.currentTarget).attr("data-tipo");

    let selectorForm = tipo == "form" ? "#frmEmisor" : "#frmsucursalmodal";

    $(selectorForm).data('bootstrapValidator').resetForm();
    if (tipo == "form") {
        $('[name*=_Sucursal]').removeClass('val-exc');
        $('[name*=_Emisor], [name*=_Serie], [name*=_Usuario]').addClass('val-exc');
    }
    $(selectorForm).data('bootstrapValidator').validate();

    let isValid = $(selectorForm).data('bootstrapValidator').isValid();

    if (!isValid) return;

    let idInputSucursalId = `#txtSucursalId_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputCodigoSUNAT = `#txtCodigoSUNAT_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputNombre = `#txtNombre_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputDireccion = `#txtDireccion_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputReferencia = `#txtReferencia_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputEsDireccionFiscal = `#chkEsDireccionFiscal_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputPaisId = `#cbbPaisId_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputDepartamentoId = `#cbbDepartamentoId_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputProvinciaId = `#cbbProvinciaId_Sucursal${(tipo == "form" ? "" : "Modal")}`;
    let idInputDistritoId = `#cbbDistritoId_Sucursal${(tipo == "form" ? "" : "Modal")}`;

    let sucursalId = $(idInputSucursalId).val();
    let codigoSUNAT = $(idInputCodigoSUNAT).val();
    let nombre = $(idInputNombre).val();
    let direccion = $(idInputDireccion).val();
    let referencia = $(idInputReferencia).val();
    let esDireccionFiscal = $(idInputEsDireccionFiscal).prop("checked");
    let paisId = $(idInputPaisId).val();
    let departamentoId = $(idInputDepartamentoId).val();
    let provinciaId = $(idInputProvinciaId).val();
    let distritoId = $(idInputDistritoId).val();

    if (esDireccionFiscal) listaSucursal.forEach((item) => item.FlagDireccionFiscal = false)

    let itemSucursal = {};

    if (accion == "A") {
        itemSucursal =
            {
                EmisorId: null,
                Emisor: null,
                SucursalId: sucursalId,
                CodigoSunat: codigoSUNAT,
                Nombre: nombre,
                Direccion: direccion,
                Referencia: referencia,
                FlagDireccionFiscal: esDireccionFiscal,
                PaisId: paisId,
                DepartamentoId: departamentoId,
                ProvinciaId: provinciaId,
                DistritoId: distritoId,
                Distrito: null,
                Fila: null,
                ModificadoPor: null,
                IpModificacion: null
            };

        listaSucursal.push(itemSucursal);
    } else if (accion == "E") {
        itemSucursal = listaSucursal.find(x => x.SucursalId == sucursalId);

        let indexSucursal = listaSucursal.findIndex(x => x.SucursalId == sucursalId);

        itemSucursal.SucursalId = sucursalId;
        itemSucursal.CodigoSunat = codigoSUNAT;
        itemSucursal.Nombre = nombre;
        itemSucursal.Direccion = direccion;
        itemSucursal.Referencia = referencia;
        itemSucursal.FlagDireccionFiscal = esDireccionFiscal;
        itemSucursal.PaisId = paisId;
        itemSucursal.DepartamentoId = departamentoId;
        itemSucursal.ProvinciaId = provinciaId;
        itemSucursal.DistritoId = distritoId;

        listaSucursal[indexSucursal] = itemSucursal;

        let btnEditarSucursal = $("#btnAgregarSucursal")[0];
        let btnCancelarSucursal = $("#btnCancelarSucursal")[0];

        let htmlBtn = 'AGREGAR <i class="ion-plus"></i>';

        $(btnEditarSucursal).html(htmlBtn);
        $(btnEditarSucursal).attr("data-accion", "A");
        $(btnEditarSucursal).removeClass("btn-success").addClass("btn-dark");
        $(btnEditarSucursal).parent().addClass("col-sm-offset-6");
        $(btnCancelarSucursal).parent().addClass("hidden");
    }

    listaSucursal.forEach((item, index) => item.Fila = index + 1);

    cargarDataTable('#tblSucursal', listaSucursal, columnsSucursal);

    $("#txtCantidadSucursales_Emisor").val(listaSucursal.length);

    let listaDireccionFiscal = listaSucursal.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: x.SucursalId, text: `${x.Nombre} - ${x.Direccion}` }); });

    if ($("#cbbDireccionFiscal_Emisor").data("select2") != null) $("#cbbDireccionFiscal_Emisor").select2("destroy");
    $("#cbbDireccionFiscal_Emisor").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });
    $("#cbbDireccionFiscal_Emisor").change();

    if ($("#cbbSucursalId_SucursalUsuarioModal").data("select2") != null) $("#cbbSucursalId_SucursalUsuarioModal").select2("destroy");
    $("#cbbSucursalId_SucursalUsuarioModal").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });
    $("#cbbSucursalId_SucursalUsuarioModal").change();

    if (tipo == "modal") $("#frm-sucursal-modal").modal("hide");

    limpiarSucursal(idInputSucursalId, idInputCodigoSUNAT, idInputNombre, idInputDireccion, idInputReferencia, idInputEsDireccionFiscal, idInputPaisId, idInputDepartamentoId, idInputProvinciaId, idInputDistritoId);

    $(selectorForm).data('bootstrapValidator').resetForm();
};

var btnObtenerSucursal_Click = (e) => {
    let btnEditarSucursal = $("#btnAgregarSucursal")[0];
    let btnCancelarSucursal = $("#btnCancelarSucursal")[0];

    let accion = $(btnEditarSucursal).attr("data-accion");

    let sucursalId = $(e.currentTarget).attr("data-sucursalid");

    let sucursal = listaSucursal.find(x => x.SucursalId == sucursalId);

    let bloquearSucursalId = sucursal.EmisorId != null;

    $("#txtSucursalId_Sucursal").val(sucursal.SucursalId);
    $("#txtSucursalId_Sucursal").attr("data-sucursalid", sucursal.SucursalId);
    $("#txtSucursalId_Sucursal").prop("readonly", bloquearSucursalId);
    $("#txtCodigoSUNAT_Sucursal").val(sucursal.CodigoSunat);
    $("#txtNombre_Sucursal").val(sucursal.Nombre);
    $("#txtDireccion_Sucursal").val(sucursal.Direccion);
    $("#txtReferencia_Sucursal").val(sucursal.Referencia);
    $("#chkEsDireccionFiscal_Sucursal").prop("checked", sucursal.FlagDireccionFiscal);
    $("#cbbPaisId_Sucursal").val(sucursal.PaisId);
    $("#cbbPaisId_Sucursal").change();
    $("#cbbDepartamentoId_Sucursal").val(sucursal.DepartamentoId);
    $("#cbbDepartamentoId_Sucursal").change();
    $("#cbbProvinciaId_Sucursal").val(sucursal.ProvinciaId);
    $("#cbbProvinciaId_Sucursal").change();
    $("#cbbDistritoId_Sucursal").val(sucursal.DistritoId);
    $("#cbbDistritoId_Sucursal").change();

    let htmlBtn = 'EDITAR <i class="ion-edit"></i>';

    $(btnEditarSucursal).html(htmlBtn);
    $(btnEditarSucursal).attr("data-accion", "E");
    $(btnEditarSucursal).removeClass("btn-dark").addClass("btn-success");
    $(btnEditarSucursal).parent().removeClass("col-sm-offset-6");
    $(btnCancelarSucursal).parent().removeClass("hidden");

};

var btnCancelarSucursal_Click = () => {
    limpiarSucursal("#txtSucursalId_Sucursal", "#txtCodigoSUNAT_Sucursal", "#txtNombre_Sucursal", "#txtDireccion_Sucursal", "#txtReferencia_Sucursal", "#chkEsDireccionFiscal_Sucursal", "#cbbPaisId_Sucursal", "#cbbDepartamentoId_Sucursal", "#cbbProvinciaId_Sucursal", "#cbbDistritoId_Sucursal");

    $("#frmEmisor").data('bootstrapValidator').resetForm();

    let btnEditarSucursal = $("#btnAgregarSucursal")[0];
    let btnCancelarSucursal = $("#btnCancelarSucursal")[0];

    let htmlBtn = 'AGREGAR <i class="ion-plus"></i>';

    $(btnEditarSucursal).html(htmlBtn);
    $(btnEditarSucursal).attr("data-accion", "A");
    $(btnEditarSucursal).removeClass("btn-success").addClass("btn-dark");
    $(btnEditarSucursal).parent().addClass("col-sm-offset-6");
    $(btnCancelarSucursal).parent().addClass("hidden");
};

var btnEliminarSucursal_Click = (e) => {
    e.preventDefault();

    bootbox.confirm("¿Estás seguro de eliminar el registro?", function (result) {
        if (result) {
            let sucursalId = $(e.currentTarget).attr("data-sucursalid");

            let indexSucursal = listaSucursal.findIndex(x => x.SucursalId == sucursalId);

            listaSucursal.splice(indexSucursal, 1);

            listaSucursal.forEach((item, index) => item.Fila = index + 1);

            cargarDataTable("#tblSucursal", listaSucursal, columnsSucursal);

            $("#txtCantidadSucursales_Emisor").val(listaSucursal.length);

            let listaDireccionFiscal = listaSucursal.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: x.SucursalId, text: `${x.Nombre} - ${x.Direccion}` }); });

            if ($("#cbbDireccionFiscal_Emisor").data("select2") != null) $("#cbbDireccionFiscal_Emisor").select2("destroy");
            $("#cbbDireccionFiscal_Emisor").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });
            $("#cbbDireccionFiscal_Emisor").change();

            if ($("#cbbSucursalId_SucursalUsuarioModal").data("select2") != null) $("#cbbSucursalId_SucursalUsuarioModal").select2("destroy");
            $("#cbbSucursalId_SucursalUsuarioModal").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });
            $("#cbbSucursalId_SucursalUsuarioModal").change();

            $.niftyNoty({
                type: 'success',
                icon: 'pli-like-2 icon-2x',
                message: 'Se eliminó el registro',
                container: 'floating',
                floating: { position: 'top-center' },
                timer: 5000
            });
        };
    });
};

var btnVerUsuarioSucursal_Click = (e) => {
    e.preventDefault();

    let vista = $(e.currentTarget).attr("data-vista").toLowerCase();
    let sucursalId = "", usuarioId = "";
    let firstColumn = {}; 
    let secondColumn = {}; 

    if (vista == 'sucursal') {
        sucursalId = $(e.currentTarget).attr("data-sucursalid");
        $("#cbbSucursalId_SucursalUsuarioModal").val(sucursalId);
        $("#cbbSucursalId_SucursalUsuarioModal").prop('readonly', true);
        firstColumn = { data: null, render: (data, type, row) => `${row.Sucursal.Nombre} - ${row.Sucursal.Direccion}` };
        secondColumn = { data: 'UsuarioId' };

    } else if (vista == 'usuario') {
        usuarioId = $(e.currentTarget).attr("data-usuarioid");
        $("#cbbUsuarioId_SucursalUsuarioModal").val(usuarioId);
        $("#cbbUsuarioId_SucursalUsuarioModal").prop('readonly', true);
        firstColumn = { data: 'UsuarioId' };
        secondColumn = { data: null, render: (data, type, row) => `${row.Sucursal.Nombre} - ${row.Sucursal.Direccion}` };
    }

    let columnsSucursalUsuario = [
        { data: 'Fila' },
        firstColumn,
        secondColumn,
        { data: null, render: (data, type, row) => `<button class="btn btn-danger btn-xs" data-sucursalid="${row.SucursalId}" data-usuarioid="${row.UsuarioId}" onclick="btnEliminarSucursal_Click(event)">ELIMINAR</a>` }
    ];

    cargarDataTable('#tblSucursalUsuario', listaSucursalUsuario, columnsSucursalUsuario);

    $("#frm-sucursalusuario-modal").modal('show');
}

var limpiarSucursal = (idInputSucursalId, idInputCodigoSUNAT, idInputNombre, idInputDireccion, idInputReferencia, idInputEsDireccionFiscal, idInputPaisId, idInputDepartamentoId, idInputProvinciaId, idInputDistritoId) => {
    $(idInputSucursalId).val("");
    $(idInputSucursalId).prop("readonly", false);
    $(idInputCodigoSUNAT).val("");
    $(idInputNombre).val("");
    $(idInputDireccion).val("");
    $(idInputReferencia).val("");
    $(idInputEsDireccionFiscal).prop("checked", false);
    $(idInputPaisId).val("");
    $(idInputPaisId).change();
    $(idInputDepartamentoId).val("");
    $(idInputDepartamentoId).change();
    $(idInputProvinciaId).val("");
    $(idInputProvinciaId).change();
    $(idInputDistritoId).val("");
};

var btnAgregarSerie_Click = (e) => {
    let accion = $(e.currentTarget).attr("data-accion");

    let selectorForm = "#frmEmisor";

    $(selectorForm).data('bootstrapValidator').resetForm();
    $('[name*=_Serie]').removeClass('val-exc');
    $('[name*=_Emisor], [name*=_Sucursal], [name*=_Usuario]').addClass('val-exc');
    $(selectorForm).data('bootstrapValidator').validate();

    let isValid = $(selectorForm).data('bootstrapValidator').isValid();

    if (!isValid) return;

    let tipoComprobanteId = $("#cbbTipoComprobanteId_Serie").val();
    let tipoComprobanteDescripcion = $("#cbbTipoComprobanteId_Serie option:selected").text();
    let serieId = $("#txtSerieId_Serie").val();
    let inicial = $("#txtInicial_Serie").val();
    let final = $("#txtFinal_Serie").val();
    let actual = $("#txtActual_Serie").val();
    let esSerieFisica = $("#chkEsFisica_Serie").prop("checked");

    let tipoComprobanteIdKey = $("#cbbTipoComprobanteId_Serie").attr("data-tipocomprobanteid") || tipoComprobanteId;
    let serieIdKey = $("#txtSerieId_Serie").attr("data-serieid") || serieId;

    let itemSerie = {};

    if (accion == "A") {
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
    }

    listaSerie.forEach((item, index) => item.Fila = index + 1);

    cargarDataTable('#tblSerie', listaSerie, columnsSerie);

    $("#txtCantidadSeries_Emisor").val(listaSerie.length);

    limpiarSerie();

    $(selectorForm).data('bootstrapValidator').resetForm();
};

var btnObtenerSerie_Click = (e) => {
    let btnEditarSerie = $("#btnAgregarSerie")[0];
    let btnCancelarSerie = $("#btnCancelarSerie")[0];

    let accion = $(btnEditarSerie).attr("data-accion");

    let tipoComprobanteId = $(e.currentTarget).attr("data-tipocomprobanteid");
    let serieId = $(e.currentTarget).attr("data-serieid");

    let serie = listaSerie.find(x => x.TipoComprobanteId == tipoComprobanteId && x.SerieId == serieId);

    let bloquearId = serie.EmisorId != null;

    $("#cbbTipoComprobanteId_Serie").val(serie.TipoComprobanteId);
    $("#cbbTipoComprobanteId_Serie").attr("data-tipocomprobanteid", serie.TipoComprobanteId);
    $("#cbbTipoComprobanteId_Serie").prop("readonly", bloquearId);
    $("#txtSerieId_Serie").val(serie.SerieId);
    $("#txtSerieId_Serie").attr("data-serieid", serie.SerieId);
    $("#txtSerieId_Serie").prop("readonly", bloquearId);
    $("#txtInicial_Serie").val(serie.Inicial);
    $("#txtFinal_Serie").val(serie.Final);
    $("#txtActual_Serie").val(serie.Actual);
    $("#chkEsFisica_Serie").prop("checked", serie.EsSerieFisica);

    let htmlBtn = 'EDITAR <i class="ion-edit"></i>';

    $(btnEditarSerie).html(htmlBtn);
    $(btnEditarSerie).attr("data-accion", "E");
    $(btnEditarSerie).removeClass("btn-dark").addClass("btn-success");
    $(btnEditarSerie).parent().removeClass("col-sm-offset-6");
    $(btnCancelarSerie).parent().removeClass("hidden");
};

var btnCancelarSerie_Click = () => {
    limpiarSerie();

    $("#frmEmisor").data('bootstrapValidator').resetForm();

    let btnEditarSerie = $("#btnAgregarSerie")[0];
    let btnCancelarSerie = $("#btnCancelarSerie")[0];

    let htmlBtn = 'AGREGAR <i class="ion-plus"></i>';

    $(btnEditarSerie).html(htmlBtn);
    $(btnEditarSerie).attr("data-accion", "A");
    $(btnEditarSerie).removeClass("btn-success").addClass("btn-dark");
    $(btnEditarSerie).parent().addClass("col-sm-offset-6");
    $(btnCancelarSerie).parent().addClass("hidden");
};

var btnEliminarSerie_Click = (e) => {
    e.preventDefault();

    bootbox.confirm("¿Estás seguro de eliminar el registro?", function (result) {
        if (result) {
            let tipoComprobanteId = $(e.currentTarget).attr("data-tipocomprobanteid");
            let serieId = $(e.currentTarget).attr("data-serieid");

            let indexSerie = listaSerie.findIndex(x => x.TipoComprobanteId == tipoComprobanteId && x.SerieId == serieId);

            listaSerie.splice(indexSerie, 1);

            listaSerie.forEach((item, index) => item.Fila = index + 1);

            cargarDataTable("#tblSerie", listaSerie, columnsSerie);

            $("#txtCantidadSeries_Emisor").val(listaSerie.length);

            $.niftyNoty({
                type: 'success',
                icon: 'pli-like-2 icon-2x',
                message: 'Se eliminó el registro',
                container: 'floating',
                floating: { position: 'top-center' },
                timer: 5000
            });
        };
    });
};

var limpiarSerie = () => {
    $("#cbbTipoComprobanteId_Serie").val("");
    $("#cbbTipoComprobanteId_Serie").prop("readonly", false);
    $("#txtSerieId_Serie").val("");
    $("#txtSerieId_Serie").prop("readonly", false);
    $("#txtInicial_Serie").val("");
    $("#txtFinal_Serie").val("");
    $("#txtActual_Serie").val("");
    $("#chkEsFisica_Serie").prop("checked", false);
};

var btnAgregarUsuario_Click = (e) => {
    let accion = $(e.currentTarget).attr("data-accion");

    let selectorForm = "#frmEmisor";

    $(selectorForm).data('bootstrapValidator').resetForm();
    $('[name*=_Usuario]').removeClass('val-exc');
    $('[name*=_Emisor], [name*=_Sucursal], [name*=_Serie]').addClass('val-exc');
    $(selectorForm).data('bootstrapValidator').validate();

    let isValid = $(selectorForm).data('bootstrapValidator').isValid();

    if (!isValid) return;

    let usuarioId = $("#txtUsuarioId_Usuario").val();
    let resetearContraseña = $("#chkResetearClave_Usuario").prop("checked");

    let usuarioIdKey = $("#txtUsuarioId_Usuario").attr("data-usuarioid") || usuarioId;

    let itemUsuario = {};

    if (accion == "A") {
        itemUsuario =
            {
                EmisorId: null,
                UsuarioId: usuarioId,
                FlagResetearClave: resetearContraseña,
                Fila: null,
                ModificadoPor: null,
                IpModificacion: null
            };

        listaUsuario.push(itemUsuario);
    } else if (accion == "E") {
        itemUsuario = listaUsuario.find(x => x.UsuarioId == usuarioIdKey);

        let indexUsuario = listaUsuario.findIndex(x => x.UsuarioId == usuarioIdKey);

        itemUsuario.UsuarioId = usuarioId;
        itemUsuario.FlagResetearClave = resetearContraseña;

        listaUsuario[indexUsuario] = itemUsuario;

        let btnEditarUsuario = $("#btnAgregarUsuario")[0];
        let btnCancelarUsuario = $("#btnCancelarUsuario")[0];

        let htmlBtn = 'AGREGAR <i class="ion-plus"></i>';

        $(btnEditarUsuario).html(htmlBtn);
        $(btnEditarUsuario).attr("data-accion", "A");
        $(btnEditarUsuario).removeClass("btn-success").addClass("btn-dark");
        $(btnEditarUsuario).parent().addClass("col-sm-offset-6");
        $(btnCancelarUsuario).parent().addClass("hidden");
    }

    listaUsuario.forEach((item, index) => item.Fila = index + 1);

    cargarDataTable('#tblUsuario', listaUsuario, columnsUsuario);

    $("#txtCantidadUsuarios_Emisor").val(listaUsuario.length);

    let listaUsuarioGeneral = listaSucursal.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: x.SucursalId, text: `${x.Nombre} - ${x.Direccion}` }); });

    if ($("#cbbSucursalId_SucursalUsuarioModal").data("select2") != null) $("#cbbSucursalId_SucursalUsuarioModal").select2("destroy");
    $("#cbbSucursalId_SucursalUsuarioModal").empty().select2({ data: listaUsuarioGeneral, width: '100%', placeholder: '[SELECCIONE...]' });
    $("#cbbSucursalId_SucursalUsuarioModal").change();

    limpiarUsuario();

    $(selectorForm).data('bootstrapValidator').resetForm();
};

var btnObtenerUsuario_Click = (e) => {
    let btnEditarUsuario = $("#btnAgregarUsuario")[0];
    let btnCancelarUsuario = $("#btnCancelarUsuario")[0];

    let accion = $(btnEditarUsuario).attr("data-accion");

    let usuarioId = $(e.currentTarget).attr("data-usuarioid");

    let usuario = listaUsuario.find(x => x.UsuarioId == usuarioId);

    let bloquearId = usuario.EmisorId != null;

    $("#txtUsuarioId_Usuario").val(usuario.UsuarioId);
    $("#txtUsuarioId_Usuario").attr("data-usuarioid", usuario.UsuarioId);
    $("#txtUsuarioId_Usuario").prop("readonly", bloquearId);
    $("#chkResetearClave_Usuario").prop("checked", usuario.FlagResetearClave);

    let htmlBtn = 'EDITAR <i class="ion-edit"></i>';

    $(btnEditarUsuario).html(htmlBtn);
    $(btnEditarUsuario).attr("data-accion", "E");
    $(btnEditarUsuario).removeClass("btn-dark").addClass("btn-success");
    $(btnEditarUsuario).parent().removeClass("col-sm-offset-6");
    $(btnCancelarUsuario).parent().removeClass("hidden");
};

var btnCancelarUsuario_Click = () => {
    limpiarUsuario();

    $("#frmEmisor").data('bootstrapValidator').resetForm();

    let btnEditarUsuario = $("#btnAgregarUsuario")[0];
    let btnCancelarUsuario = $("#btnCancelarUsuario")[0];

    let htmlBtn = 'AGREGAR <i class="ion-plus"></i>';

    $(btnEditarUsuario).html(htmlBtn);
    $(btnEditarUsuario).attr("data-accion", "A");
    $(btnEditarUsuario).removeClass("btn-success").addClass("btn-dark");
    $(btnEditarUsuario).parent().addClass("col-sm-offset-6");
    $(btnCancelarUsuario).parent().addClass("hidden");
};

var btnEliminarUsuario_Click = (e) => {
    e.preventDefault();

    bootbox.confirm("¿Estás seguro de eliminar el registro?", function (result) {
        if (result) {
            let usuarioId = $(e.currentTarget).attr("data-usuarioid");

            let indexUsuario = listaUsuario.findIndex(x => x.UsuarioId == usuarioId);

            listaUsuario.splice(indexUsuario, 1);

            listaUsuario.forEach((item, index) => item.Fila = index + 1);

            cargarDataTable("#tblUsuario", listaUsuario, columnsUsuario);

            $("#txtCantidadUsuarios_Emisor").val(listaUsuario.length);

            $.niftyNoty({
                type: 'success',
                icon: 'pli-like-2 icon-2x',
                message: 'Se eliminó el registro',
                container: 'floating',
                floating: { position: 'top-center' },
                timer: 5000
            });
        };
    });
};

var limpiarUsuario = () => {
    $("#txtUsuarioId_Usuario").val("");
    $("#txtUsuarioId_Usuario").prop("readonly", false);
    $("#chkResetearClave_Usuario").prop("checked", false);
};

var btnNuevo_Click = (e) => {
    e.preventDefault();

    $("#panelEmisor .panel-heading .panel-title ul li").removeClass('disabled');
    $("#panelEmisor .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().addClass('disabled');
    $("a[href='#tab-emisor']").tab('show');
    $("#btnNuevo").addClass('hidden');
    $("#btnGuardar").removeClass('hidden');
    $("#btnCancelar").removeClass('hidden');
};

var limpiarEmisor = () => {
    $("#txtEmisorId_Emisor").prop("readonly", false);
    $("#txtEmisorId_Emisor").val('');
    $("#txtRazonSocial_Emisor").val('');
    $("#txtNombreComercial_Emisor").val('');
    $("#txtEslogan_Emisor").val('');
    $("#txtCantidadSucursales_Emisor").val('');
    $("#txtCantidadSeries_Emisor").val('');
    $("#txtCantidadUsuarios_Emisor").val('');

    listaSucursal = [], listaSerie = [], listaUsuario = [], listaSucursalUsuario = [], listaSerieUsuario = [];

    cargarDataTable('#tblSucursal', listaSucursal, columnsSucursal);
    cargarDataTable('#tblSerie', listaSerie, columnsSerie);
    cargarDataTable('#tblUsuario', listaUsuario, columnsUsuario);
}

var btnGuardar_Click = (e) => {
    debugger;
    e.preventDefault();

    $('#frmEmisor').data('bootstrapValidator').resetForm();
    $('[name*=_Emisor]').removeClass('val-exc');
    $('[name*=_Usuario], [name*=_Serie], [name*=_Sucursal]').addClass('val-exc');
    $('#frmEmisor').data('bootstrapValidator').validate();

    let isValid = $('#frmEmisor').data('bootstrapValidator').isValid();

    if (!isValid) return;

    let emisor = {};
    emisor.EmisorId = $("#txtEmisorId_Emisor").val().trim();
    emisor.RazonSocial = $("#txtRazonSocial_Emisor").val().trim();
    emisor.NombreComercial = $("#txtNombreComercial_Emisor").val().trim();
    emisor.Eslogan = $("#txtEslogan_Emisor").val().trim();
    //emisor.DeBaja = $("#").val().trim();
    emisor.ListaUsuario = listaUsuario.map(x => { x.EmisorId = emisor.EmisorId; return Object.assign({}, x); });
    emisor.ListaSucursal = listaSucursal.map(x => { x.EmisorId = emisor.EmisorId; return Object.assign({}, x); });
    emisor.ListaSerie = listaSerie.map(x => { x.EmisorId = emisor.EmisorId; return Object.assign({}, x); });
    emisor.ListaSucursalUsuario = listaSucursalUsuario.map(x => { x.EmisorId = emisor.EmisorId; return Object.assign({}, x); });
    emisor.ListaSerieUsuario = listaSerieUsuario.map(x => { x.EmisorId = emisor.EmisorId; return Object.assign({}, x); });

    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        let transaccionEmisor = config.variables["transaccionEmisor"];

        if (!transaccionEmisor) {
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

        limpiarEmisor();
        limpiarSucursal();
        limpiarSerie();
        limpiarUsuario();

        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: '¡Se guardó correctamente el registro!',
            container: 'floating',
            floating: { position: 'top-center' },
            timer: 5000
        });

        $('#frmEmisor').data('bootstrapValidator').resetForm();

        $("a[href*='#tab-'] i").parent().parent().removeClass("bv-tab-error");
        $("a[href*='#tab-'] i").removeClass('text-success').removeClass('text-danger');

        $("#panelEmisor .panel-heading .panel-title ul li").addClass('disabled');
        $("#panelEmisor .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().removeClass('disabled');
        $("a[href='#tab-busqueda']").tab('show');
        $("#btnNuevo").removeClass('hidden');
        $("#btnGuardar").addClass('hidden');
        $("#btnCancelar").addClass('hidden');

        $("#btnBuscar").click();
    };

    config.api.aprif.rest.emisor.mantenerEmisor(emisor, 'transaccionEmisor');
};

var btnCancelar_Click = (e) => {
    e.preventDefault();

    $("#btnGuardar").attr("data-accion", "N");

    limpiarEmisor();
    limpiarSucursal();
    limpiarSerie();
    limpiarUsuario();

    listaSucursal = [], listaSerie = [], listaUsuario = [], listaSucursalUsuario = [], listaSerieUsuario = [];

    cargarDataTable('#tblSucursal', listaSucursal, columnsSucursal);
    cargarDataTable('#tblSerie', listaSerie, columnsSerie);
    cargarDataTable('#tblUsuario', listaUsuario, columnsUsuario);

    let listaDireccionFiscal = listaSucursal.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: x.SucursalId, text: `${x.Nombre} - ${x.Direccion}` }); });

    if ($("#cbbDireccionFiscal_Emisor").data("select2") != null) $("#cbbDireccionFiscal_Emisor").select2("destroy");
    $("#cbbDireccionFiscal_Emisor").empty().select2({ data: listaDireccionFiscal, width: '100%', placeholder: '[SELECCIONE...]' });


    $("a[href*='#tab-'] i").parent().parent().removeClass("bv-tab-error");
    $("a[href*='#tab-'] i").removeClass('text-success').removeClass('text-danger');

    $("#panelEmisor .panel-heading .panel-title ul li").addClass('disabled');
    $("#panelEmisor .panel-heading .panel-title ul li a[href='#tab-busqueda']").parent().removeClass('disabled');
    $("a[href='#tab-busqueda']").tab('show');
    $("#btnNuevo").removeClass('hidden');
    $("#btnGuardar").addClass('hidden');
    $("#btnCancelar").addClass('hidden');
};