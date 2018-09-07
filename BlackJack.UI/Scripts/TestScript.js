var bool = true;


$(function () {
    $('.testButton').on('click', function () {
        if (bool) {
            var roundId = $(this).attr('data-param');
            $.post(path, { id: roundId })
                .done(function (data) {
                    $('.render').html(data).css({ 'opacity': 1, 'visibility': 'visible' });
                
                bool = false;
                });

            //$.ajax({  .css({ 'opacity': 0, 'visibility': 'hidden' })
            //    type: "POST",
            //    url: path,
            //    data: id,
            //    succes: function (ret) {
            //        $(element).next().html(data);
            //        bool = false;
            //    }
            //});
        }
        if (!bool) {
            $('.render').html(null);
            bool = true;
        }
    });


});