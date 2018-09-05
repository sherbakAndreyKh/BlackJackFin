var bool = true;


$(function () {
    $('.testButton').on('click', function () {

        var id = $(this).attr('data-param');
        var element = $(this);
        if (bool) {
            $.post(path, id, function (data) {
                $(element).next().html(data);
                bool = false;
            });
        }
        if (!bool) {
            $(element).next().html(null);
            bool = true;
        }
    });


});