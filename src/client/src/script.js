$('textarea').on({
    focus: function () {
        $(this).siblings("label").addClass("focused");

    },

    blur: function () {
        tmpval = $(this).val();
        if (tmpval == '') {
            $(this).siblings("label").removeClass("focused");
        }

    }
});