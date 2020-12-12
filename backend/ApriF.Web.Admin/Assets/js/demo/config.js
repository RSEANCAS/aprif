const config =
{
    variables: {},
    cantidadPeticiones: 0,
    totalPeticiones: 0,
    loading: false,
    hacerAlFinalizarPeticion: () => { },
    selectorLoading: 'body',
    finalizarPeticiones: () => {
        config.cantidadPeticiones += 1;
        if (config.cantidadPeticiones >= config.totalPeticiones) {
            config.cantidadPeticiones = 0;
            config.totalPeticiones = 0;
            config.loading = false;
            config.cerrarCargando(config.selectorLoading);
            config.selectorLoading = 'body';
            let hacerAlFinalizarPeticion = config.hacerAlFinalizarPeticion;
            config.hacerAlFinalizarPeticion = () => { };
            hacerAlFinalizarPeticion();
        }
    },
    abrirCargando: (selector) => {
        $(selector).block({
            baseZ: 1000000,
            message: '<div class="load8"><div class="loader"></div></div>',
            overlayCSS: {
                backgroundColor: '#1B2024',
                opacity: 0.85,
                cursor: 'wait'
            },
            css: {
                border: 0,
                padding: 0,
                backgroundColor: 'none',
                color: '#fff'
            }
        });
    },
    cerrarCargando: (selector) => {
        $(selector).unblock();
    },
    api: {
        aprif: {
            rest: {
                //baseUrl: 'http://ronaldseancas.com/aprif/aprif.rest/api',
                baseUrl: 'http://localhost/aprif/aprif.rest/api',
                //baseUrl: 'http://localhost:54816/api',
                opcion: {
                    baseUrl: 'opcion',
                    method: 'GET',
                    actualizarOrdenOpcion: (plataformaId, opcionId, opcionPadreId, accionOrden, key = 'transaccionOpcion') => {
                        let paramList = [{ key: "plataformaId", value: plataformaId }, { key: "opcionId", value: opcionId }, { key: "opcionPadreId", value: opcionPadreId }, { key: "accionOrden", value: accionOrden }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');
                        let url = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.opcion.baseUrl}/manteneropcion`;

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open('POST', url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.setRequestHeader("Content-Type", "application/json");
                        xhr.send(JSON.stringify(opcion));
                    },
                    mantenerOpcion: (opcion, key = 'transaccionOpcion') => {
                        let url = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.opcion.baseUrl}/manteneropcion`;

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open('POST', url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.setRequestHeader("Content-Type", "application/json");
                        xhr.send(JSON.stringify(opcion));
                    },
                    listarOpcion: (plataformaId, key = 'listarOpcion') => {
                        let paramList = [{ key: "plataformaId", value: plataformaId }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.opcion.baseUrl}/listaropcion?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.opcion.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    },
                    buscarOpcion: (plataformaId = null, opcionId = null, opcionPadreId = null, nombre = null, enlace = null, orden = null, key = 'buscarOpcion') => {
                        let paramList = [{ key: "plataformaId", value: plataformaId }, { key: "opcionId", value: opcionId }, { key: "opcionPadreId", value: opcionPadreId }, { key: "nombre", value: nombre }, { key: "enlace", value: enlace }, { key: "orden", value: orden }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.opcion.baseUrl}/buscaropcion?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.opcion.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    },
                    obtenerOpcion: (plataformaId, opcionId, key = 'obtenerOpcion') => {
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.opcion.baseUrl}/obteneropcion?plataformaId=${plataformaId}&opcionId=${opcionId}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.opcion.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                plataforma: {
                    baseUrl: 'plataforma',
                    method: 'GET',
                    mantenerPlataforma: (plataforma, key = 'transaccionPlataforma') => {
                        let url = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.plataforma.baseUrl}/mantenerplataforma`;

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open('POST', url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.setRequestHeader("Content-Type", "application/json");
                        xhr.send(JSON.stringify(plataforma));
                    },
                    listarPlataforma: (key = 'listarPlataforma') => {
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.plataforma.baseUrl}/listarplataforma`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.plataforma.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    },
                    buscarPlataforma: (plataformaId = null, identificador = null, nombre = null, key = 'buscarPlataforma') => {
                        let paramList = [{ key: "plataformaId", value: plataformaId }, { key: "identificador", value: identificador }, { key: "nombre", value: nombre }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.plataforma.baseUrl}/buscarplataforma?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.plataforma.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    },
                    obtenerPlataforma: (plataformaId, key = 'obtenerPlataforma') => {
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.plataforma.baseUrl}/obtenerplataforma?plataformaId=${plataformaId}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.plataforma.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                pais: {
                    baseUrl: 'pais',
                    method: 'GET',
                    listarPais: (key = 'listarPais') => {
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.pais.baseUrl}/listarpais`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.pais.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                departamento: {
                    baseUrl: 'departamento',
                    method: 'GET',
                    listarDepartamento: (paisId = null, key = 'listarDepartamento') => {
                        let paramList = [{ key: "paisId", value: paisId }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');

                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.departamento.baseUrl}/listardepartamento?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.departamento.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                provincia: {
                    baseUrl: 'provincia',
                    method: 'GET',
                    listarProvincia: (paisId = null, departamentoId = null, key = 'listarProvincia') => {
                        let paramList = [{ key: "paisId", value: paisId }, { key: "departamentoId", value: departamentoId }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');

                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.provincia.baseUrl}/listarprovincia?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.provincia.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                distrito: {
                    baseUrl: 'distrito',
                    method: 'GET',
                    listarDistrito: (paisId = null, departamentoId = null, provinciaId = null, key = 'listarDistrito') => {
                        let paramList = [{ key: "paisId", value: paisId }, { key: "departamentoId", value: departamentoId }, { key: "provinciaId", value: provinciaId }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');

                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.distrito.baseUrl}/listardistrito?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.distrito.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                tipoComprobante: {
                    baseUrl: 'tipocomprobante',
                    method: 'GET',
                    listarTipoComprobante: (key = 'listarTipoComprobante') => {
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipoComprobante.baseUrl}/listartipocomprobante`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.tipoComprobante.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                emisor: {
                    baseUrl: 'emisor',
                    method: 'POST',
                    mantenerEmisor: (emisor, key = 'transaccionEmisor') => {
                        let url = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.emisor.baseUrl}/manteneremisor`;

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.emisor.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.setRequestHeader("Content-Type", "application/json");
                        xhr.send(JSON.stringify(emisor));
                    },
                    buscarEmisor: (emisorId = null, razonSocial = null, nombreComercial = null, eslogan = null, deBaja = null, key = 'listarEmisor') => {
                        let paramList = [{ key: "emisorId", value: emisorId }, { key: "razonSocial", value: razonSocial }, { key: "nombreComercial", value: nombreComercial }, { key: "eslogan", value: eslogan }, { key: "deBaja", value: deBaja }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&')

                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.emisor.baseUrl}/buscaremisor?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.emisor.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    },
                    obtenerEmisor: (emisorId = null, key = 'listarEmisor') => {
                        let paramList = [{ key: "emisorId", value: emisorId }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&')

                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.emisor.baseUrl}/obteneremisor?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.emisor.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    },
                    obtenerSunatEmisor: (emisorId = null, key = 'listarEmisor') => {
                        let paramList = [{ key: "emisorId", value: emisorId }];
                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&')

                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.emisor.baseUrl}/obtenersunatemisor?${paramListString}`);

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.emisor.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                }
            }
        }
    }
};

var cargarDataTable = (selector, data, columns) => {
    return $(selector).DataTable({
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