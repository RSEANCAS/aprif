const config =
{
    cantdecimals : 3,
    variables: {},
    cantidadPeticiones: 0,
    totalPeticiones: 0,
    loading: false,
    hacerAlFinalizarPeticion: () => { },
    selectorLoading: 'body',
    finalizarPeticiones: () => {
        config.cantidadPeticiones += 1;
        if (config.cantidadPeticiones == config.totalPeticiones) {
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
                baseUrl: 'http://localhost/aprif/aprif.rest/api',
                tipooperacion: {
                    baseUrl: 'tipooperacion',
                    method: 'GET',
                    listarTipoOperacion: (key = 'listarTipoOperacion') => {
                        let jj = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipooperacion.baseUrl}/listartipooperacion`;
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipooperacion.baseUrl}/listartipooperacion`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState == 4) {
                                if (xhr.status == 200) {
                                    d = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }
                        xhr.open(config.api.aprif.rest.tipooperacion.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                serie: {
                    baseUrl: 'serie',
                    method: 'GET',
                    listarSeriePorTipo: (emisorId = null, tipocomprobanteid =null,key = 'listarSeriePorTipo') => {

                        let paramList = [{ key: "emisorId", value: emisorId }, { key: "tipocomprobanteId", value: tipocomprobanteid}];

                        let paramListString = paramList.filter(x => x.value != null && x != '').map(x => `${x.key}=${x.value}`).join('&');

                        let jj = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.serie.baseUrl}/listarserieportipo?${paramListString}`;
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.serie.baseUrl}/listarserieportipo?${paramListString}`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState == 4) {
                                if (xhr.status == 200) {
                                    d = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }
                        xhr.open(config.api.aprif.rest.serie.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                        
                    }
                },
                tipodocumentoidentidad: {
                    baseUrl: 'tipodocumentoidentidad',
                    method: 'GET',
                    listartipodocumentoidentidad: (key = 'listartipodocumentoidentidad') => {
                        let jj = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipodocumentoidentidad.baseUrl}/listartipodocumentoidentidad`;
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipodocumentoidentidad.baseUrl}/listartipodocumentoidentidad`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState == 4) {
                                if (xhr.status == 200) {
                                    d = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }
                        xhr.open(config.api.aprif.rest.tipodocumentoidentidad.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                tipoafectacionigv: {
                    baseUrl: 'tipoafectacionigv',
                    method: 'GET',
                    listartipoafectacionigv: (key = 'listartipoafectacionigv') => {
                        let jj = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipoafectacionigv.baseUrl}/listartipoafectacionigv`;
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipoafectacionigv.baseUrl}/listartipoafectacionigv`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState == 4) {
                                if (xhr.status == 200) {
                                    d = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }
                        xhr.open(config.api.aprif.rest.tipoafectacionigv.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                unidadmedida: {
                    baseUrl: 'unidadmedida',
                    method: 'GET',
                    listarunidadmedida: (key = 'listarunidadmedida') => {
                        let jj = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.unidadmedida.baseUrl}/listarunidadmedida`;
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.unidadmedida.baseUrl}/listarunidadmedida`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState == 4) {
                                if (xhr.status == 200) {
                                    d = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }
                        xhr.open(config.api.aprif.rest.unidadmedida.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                tipomoneda: {
                    baseUrl: 'tipomoneda',
                    method: 'GET',
                    listartipomoneda: (key = 'listartipomoneda') => {
                        let jj = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipomoneda.baseUrl}/listartipomoneda`;
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipomoneda.baseUrl}/listartipomoneda`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState == 4) {
                                if (xhr.status == 200) {
                                    d = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }
                        xhr.open(config.api.aprif.rest.tipomoneda.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                /*tipotributo: {
                    baseUrl: 'tipotributo',
                    method: 'GET',
                    listartipotributo: (key = 'listartipotributo') => {
                        let jj = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipotributo.baseUrl}/listartipotributo`;
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.tipotributo.baseUrl}/listartipotributo`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState == 4) {
                                if (xhr.status == 200) {
                                    d = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }
                        xhr.open(config.api.aprif.rest.tipotributo.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },*/
                cliente: {
                    baseUrl: 'cliente',
                    method: 'POST',
                    obtenerCliente: (emisorId= '',clienteId='',tipodocumentoId='', key = 'listarCliente') => {

                        let paramList = [{ key: "emisorId", value: emisorId }, { key: "clienteId", value: clienteId }, { key: "tipodocumentoId", value: tipodocumentoId }];

                    let paramListString = paramList.filter(x => x.value != null /*&& x != ''*/).map(x => `${x.key}=${x.value}`).join('&')

                    let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.cliente.baseUrl}/obtenercliente?${paramListString}`);
                    config.variables[key] = null;
                    var xhr = new XMLHttpRequest();
                    xhr.onreadystatechange = () => {
                        if (xhr.readyState === 4 && config.variables[key] == null) {
                            if (xhr.status === 200) {
                                let sdd = JSON.parse(xhr.responseText);
                                config.variables[key] = JSON.parse(xhr.responseText);
                            }
                            config.finalizarPeticiones();
                        }
                    }

                    xhr.open(config.api.aprif.rest.cliente.method, url, true);
                    xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                    xhr.send();
                    }
                },
                factura: {
                    baseUrl: 'factura',
                    method: 'POST',
                    registrafactura: (factura, key = 'transaccionfactura') => {
                        let url = `${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.factura.baseUrl}/registrafactura`;

                        config.variables[key] = null;

                        var xhr = new XMLHttpRequest();

                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    let jj = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.factura.method, url, true);
                        //xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.setRequestHeader("Content-Type", "application/json");
                        xhr.send(JSON.stringify(factura));
                    }
                },
                producto: {
                    baseUrl: 'producto',
                    method: 'POST',
                    obtenerProducto: (emisorId = '', productoId = '', key = 'obtenerProducto') => {

                        let paramList = [{ key: "emisorId", value: emisorId }, { key: "productoId", value: productoId }];

                        let paramListString = paramList.filter(x => x.value != null /*&& x != ''*/).map(x => `${x.key}=${x.value}`).join('&')

                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.producto.baseUrl}/obtenerproducto?${paramListString}`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4 && config.variables[key] == null) {
                                if (xhr.status === 200) {
                                    let sdd = JSON.parse(xhr.responseText);
                                    config.variables[key] = JSON.parse(xhr.responseText);
                                }
                                config.finalizarPeticiones();
                            }
                        }

                        xhr.open(config.api.aprif.rest.producto.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                },
                tipoComprobante: {
                    baseUrl: 'tipocomprobante',
                    method: 'POST',
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
                reporteventa: {
                    baseUrl: 'reporteventa',
                    method: 'POST',
                    listarReporteVenta: (key = 'listarReporteVenta') => {
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.reporteventa.baseUrl}/listarreporteventa`);
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

                        xhr.open(config.api.aprif.rest.reporteventa.method, url, true);
                        xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                        xhr.send();
                    }
                }
                /*pais: {
                    baseUrl: 'pais',
                    method: 'GET',
                    listarPais: (key = 'listarPais') => {
                        let url = encodeURI(`${config.api.aprif.rest.baseUrl}/${config.api.aprif.rest.pais.baseUrl}/listarpais`);
                        config.variables[key] = null;
                        var xhr = new XMLHttpRequest();
                        xhr.onreadystatechange = () => {
                            if (xhr.readyState === 4) {
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
                            if (xhr.readyState === 4) {
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
                            if (xhr.readyState === 4) {
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
                            if (xhr.readyState === 4) {
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
                            if (xhr.readyState === 4) {
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
                }*/
                
            }
        }
    }
};

