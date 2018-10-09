var bool = true;
var path = $('tbody').attr('data-myPath');
$('.testButton').on('click', function () {

    if (bool) {
        var roundId = $(this).attr('data-param');
        $.post(path, { roundId: roundId })
            .done(function (data) {
                $('.render').html(data).css({ 'opacity': 1, 'visibility': 'visible' });
                bool = false;
            });
    }
    if (!bool) {
        $('.render').html(null).css({ 'opacity': 0, 'visibility': 'hidden' });
        bool = true;
    }
});