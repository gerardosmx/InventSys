let datatable;

$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {
    datatable = $('#tblAlmacenes').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar page _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Admin/Almacen/ObtenerTodos"
        },
        "columns": [
            { "data": "nombre", "width": "20%" },
            { "data": "descrip", "width": "20%" },
            { "data": "direccion", "width": "20%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    } else {
                        return "Inactivo";
                    }
                }, "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                            <a href="/Admin/Almacen/Actualizar/${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">
                                <i class="bi bi-pencil-square"></i> Editar
                            </a>
                            <a onclick=Delete("/Admin/Almacen/Eliminar/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:70px;">
                                <i class="bi bi-trash"></i> Eliminar
                            </a>
                        </div>
                    `;

                }, "width": "20%"
            }
        ]
    });
} 

function Delete(url) {
    swal({
        title: "¿Estas seguro de eliminar?",
        text: "No podras recuperar la informacion",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: 'POST',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
 }
