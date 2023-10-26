$(document).ready(function () {
    $('#formInicioSesion').validate({
        rules: {
            username: "required",
            password: "required"
        },
        messages: {
            username: "Por favor inserte el usuario.",
            password: "Por favor inserte la contraseña."
        }
    })
});
