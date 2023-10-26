const divPermiso = $('#checkbox-permisos');
const moduloSelect = $('#modulosSelect');

const rolesButton = $('#RolesButton');

const buttonSubmit = $('#new-role');

const form = $('#form-rol');

let pemisosArray;

const validation = () => {

    $(document).ready(() => {
        form.validate({
            rules: {
                nombreRol: "required"
            },
            messages: {
                nombreRol: "Por favor inserte el nombre del rol.",
            },

            submitHandler: (form) => {
                var nombre = { NombreRol: document.getElementById('nombre-rol').value };

                pemisosArray.push(nombre);

                $.ajax({
                    type: form.method,
                    url: form.action,
                    data: {
                        permisos: JSON.stringify(pemisosArray)
                    },
                    async: true,
                    cache: false,
                    dataType: 'json',
                    cache: false,
                    success: function (permisos) {
                        window.location.reload();

                    },
                    error: function (data) {
                        alert('Hubo un error cargado los datos.');
                    }
                });
            }
        });
    });
}

const cargaRol = () => {

    $(document).ready(() => {

        $.ajax({
            type: 'POST',
            url: '/GetPermisoByModulo',
            async: true,
            cache: false,
            dataType: 'json',
            cache: false,
            success: function (permisos) {

                pemisosArray = [];

                permisos.forEach(r => pemisosArray.push({
                    idPermiso: r.identificadorPermiso, detalle: r.detallePermiso, valorPermiso: 0,
                    modulo: r.identificadorModuloNavigation.identificadorModulo
                }));

                setInputText(pemisosArray);
            },
            error: function (data) {
                alert('Hubo un error cargado los datos.');
            }
        });
    })
}

const setInputText = (permisos) => {

    divPermiso.empty();

    let i = 0;
    //Esta logica guarda si un checkbox es marcado de manera temporal y crea los inputs y labels y los pone en la vista
    permisos.forEach(permiso => {

        if (permiso.modulo == moduloSelect.val()) {
            var input = document.createElement('input');
            var label = document.createElement('label');
            input.setAttribute("class", "checkbox-crud checkbox-custom");
            input.setAttribute("type", "checkbox");
            input.setAttribute("id", "name" + i);
            input.setAttribute("value", permiso.idPermiso);


            label.setAttribute("for", "name" + i);
            label.setAttribute("class", "mt-1 mr-2");
            label.append(document.createTextNode(permiso.detalle));

            (permiso.valorPermiso == 0) ? input.checked = false : input.checked = true;


            divPermiso.append(input);
            divPermiso.append(label);

            i++;
        }
    })
    listeners();
}

const listeners = () => {

    moduloSelect.change(() => {
        setInputText(pemisosArray);
    });

    const checkInput = document.querySelectorAll('.checkbox-custom');

    checkInput.forEach(input => input.addEventListener('click', (input) => {
        var valueInput = input.target;

        pemisosArray.forEach(permiso => {
            if (permiso.idPermiso == valueInput.value) (valueInput.checked) ? permiso.valorPermiso = 1 : permiso.valorPermiso = 0;
        });
    }));



}

cargaRol();

validation();
