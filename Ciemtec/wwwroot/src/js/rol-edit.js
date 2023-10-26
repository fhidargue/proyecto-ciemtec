const div = $('#divRolEdit');

const nombre = $('#nombre-rol');

const moduloSelect = $('#modulosSelectEdit');

const divStyle = $('#controlIndex');

let pemisosArray;

const getValues = () => {

    $(document).ready(() => {

        divStyle.parent().addClass("active");

        $.ajax({
            type: 'POST',
            url: '/EditarRolData',
            async: true,
            cache: false,
            dataType: 'json',
            cache: false,
            success: function (permisos) {

                nombre.val(permisos[0].nombre_Rol);

                pemisosArray = permisos;

                setInput(pemisosArray);
            },
            error: function (data) {
                alert('Hubo un error cargado los datos.');
            }
        });
    });
}

const listeners = () => {

    moduloSelect.change(() => {
        setInput(pemisosArray);
    });

    const checkInput = document.querySelectorAll('.checkbox-custom-edit');

    checkInput.forEach(input => input.addEventListener('click', (input) => {
        var valueInput = input.target;

        pemisosArray.forEach(permiso => {
            if (permiso.identificador_Permiso == valueInput.value)
                (valueInput.checked) ? permiso.valor_Rol_Permiso = 1 : permiso.valor_Rol_Permiso = 0;
        });
    }));
}


const setInput = (permisos) => {

    div.empty();

    let i = 0;

    permisos.forEach(permiso => {

        if (permiso.identificador_Modulo == moduloSelect.val()) {
            var input = document.createElement('input');
            var label = document.createElement('label');
            input.setAttribute("class", "checkbox-crud checkbox-custom-edit");
            input.setAttribute("type", "checkbox");
            input.setAttribute("id", "name" + i);
            input.setAttribute("value", permiso.identificador_Permiso);


            label.setAttribute("for", "name" + i);
            label.setAttribute("class", "mt-1 mr-2");
            label.append(document.createTextNode(permiso.detalle_Permiso));

            (permiso.valor_Rol_Permiso == 0) ? input.checked = false : input.checked = true;

            div.append(input);
            div.append(label);

            i++;
        }
    })

    listeners();
}


getValues();

