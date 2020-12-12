var ListaReporteVenta = [];

$(document).on('nifty.ready', function () {
    $('#demo-dp-component .input-group.date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        todayHighlight: true,
        todayBtn: "linked",
        text: Date.now
    });

    page_Load();
});

var page_Load = () => {
    //cargarDataTable('#tblDetalle', listaDetalle, columnsDetalle);

    config.cantidadPeticiones = 0;
    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {
        
        //NEW
        listaTipoComprobante = config.variables['listaTipoComprobante'] || [];
        let dataTipoComprobante = listaTipoComprobante.map(x => { let item = Object.assign({}, x); return Object.assign(item, { id: item.TipoComprobanteId, text: item.Descripcion }); });
        $("#cmbtipocomprobante").select2({ data: dataTipoComprobante, width: '100%', placeholder: '[SELECCIONE...]' });

    };

    config.api.aprif.rest.tipoComprobante.listarTipoComprobante('listaTipoComprobante');

    //config.api.aprif.rest.tipotributo.listartipotributo('listatipotributo');

};

var btnReporte_Click = () => {
    config.cantidadPeticiones = 0;
    config.totalPeticiones = 1;
    config.loading = true;
    config.abrirCargando(config.selectorLoading);

    config.hacerAlFinalizarPeticion = () => {

        //NEW
        listaReporteVenta = config.variables['listaReporteVenta'] || [];

        cargarDataTable('#tblReporteVenta', listaReporteVenta, columnsReporte);

    };

    config.api.aprif.rest.reporteventa.listarReporteVenta('listaReporteVenta');
};

var columnsReporte = [
    { data: 'ClienteInfo' },
    { data: 'ComprobanteInfo' },
    { data: 'TipoMonedaId' },
    { data: 'FechaEmision' },
    { data: 'TotalImportePagar' },
    { data: null, render: (data, type, row) => `<button class="btn btn-dark btn-xs btn-rounded" data-CodigoId="${row.CodigoId}" onclick="btnObtenerDetalle_Click(event)">EDITAR</a> <button class="btn btn-danger btn-xs btn-rounded" data-CodigoId="${row.CodigoId}" onclick="btnEliminarDetalle_Click(event)">ELIMINAR</a>` }
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
