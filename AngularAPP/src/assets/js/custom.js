// Example starter JavaScript for disabling form submissions if there are invalid fields

function initializeValidation() {
    if ($.validator && $.validator.unobtrusive) {
        
        $.validator.setDefaults({
            errorClass: "is-invalid",
            validClass: "is-valid",
            
            highlight: function (element, errorClass, validClass) {
                var $el = $(element);
                $el.addClass(errorClass).removeClass(validClass);
                
                // 1. Manage the validation message display
                var $errorSpan = $("span[data-valmsg-for='" + $el.attr("name") + "']");
                $errorSpan.addClass("invalid-tooltip d-block").removeClass("valid-tooltip");

                // 2. Clear old helper icons inside this input container block
                $el.parent().find(".js-validation-icon").remove();

                // 3. Inject an absolute-positioned Bootstrap Error Icon right after the input field
                var $errIcon = $("<span class='js-validation-icon text-danger' style='position: absolute; right: 12px; top: 50%; transform: translateY(-50%); z-index: 5; pointer-events: none; font-weight: bold;'>🗙</span>");
                
                // Force parent container to relative so the absolute icon aligns cleanly
                $el.parent().css("position", "relative").append($errIcon);

                var $group = $el.closest(".input-group, .form-floating");
                if ($group.length > 0) { $group.addClass("has-validation"); }
            },
            
            unhighlight: function (element, errorClass, validClass) {
                var $el = $(element);
                $el.addClass(validClass).removeClass(errorClass);
                
                var $errorSpan = $("span[data-valmsg-for='" + $el.attr("name") + "']");
                $errorSpan.addClass("valid-tooltip d-block").removeClass("invalid-tooltip");
                
                if (!$errorSpan.text() || $errorSpan.text().trim() === "") {
                    $errorSpan.html("✓ Looks good!");
                }

                // 1. Clear old helper icons inside this input container block
                $el.parent().find(".js-validation-icon").remove();

                // 2. Inject an absolute-positioned Bootstrap Success Icon right after the input field
                var $successIcon = $("<i class='bi bi-check-circle-fill text-success js-validation-icon'></i>");
                $successIcon.css({
                    "position": "absolute",
                    "right": "12px",
                    "top": "50%",
                    "transform": "translateY(-50%)",
                    "z-index": "5"
                });
                
                $el.parent().css("position", "relative").append($successIcon);
                
                $el.closest(".input-group, .form-floating").removeClass("has-validation");
            }
        });

        // Re-parse current page layout form maps
        $("form").each(function () {
            var $form = $(this);
            if ($form.data("validator")) {
                $form.removeData("validator");
                $form.removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse($form);
            }
        });
    }
}
