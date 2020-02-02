$(document).ready(function () {
	$('[data-toggle="popover"]').popover({
		html: true,
		content: '<p class="text-center"><a href="#" class="btn btn-outline-success">Identifícate</a></p>' +
						 '<p>¿Eres nuevo? <a href="#">Registrarse</a></p>'
	});
});