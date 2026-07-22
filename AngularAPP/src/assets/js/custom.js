// Example starter JavaScript for disabling form submissions if there are invalid fields

function initializeValidation() {
    $("form").each(function () {

        var $form = $(this);
        if ($form.data("validator")) {
            $form.removeData("validator");
            $form.removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($form);
        }
    });
}


