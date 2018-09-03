
    var Bool = false;

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function GetCard() {
        return model.CardDeck[getRandomInt(0, 51)]
    }


//Add Card
$(function () {
    $('#Take').on('click', function () {
        var Card = GetCard();
        var value = parseInt($('.Score').eq(0).html());
        var Hand = $('.Hand').eq(0).html();
        $('.Hand').eq(0).html(Hand + ", " + Card.Name + " " + Card.Suit);
        value >= 11 && Card.Value === 11 ? $('.Score').eq(0).html(value + Card.Value - 10) : $('.Score').eq(0).html(value + Card.Value);
        model.Player.Score = 21;
        model.Player.Properties[0].Hand.push(Card);
        $.post(path, model);
    });

});

$(function () {
    $('#First').on('click', function () {


        $('.Participant').each(function (i) {
            var FirstCard = GetCard();
            var SecondCard = GetCard();
            if ($(this).children('p').children('.Score').html() === "0") {
                $(this).children('.Hand').html(FirstCard.Name + " " + FirstCard.Suit + ", " + SecondCard.Name + " " + SecondCard.Suit);
                var value = FirstCard.Value === 11 && SecondCard.Value === 11 ? +FirstCard.Value + SecondCard.Value - 10 : +FirstCard.Value + SecondCard.Value;
                $(this).children('p').children('.Score').html(value);
                var CardArray = new Array();
                CardArray.push(FirstCard);
                CardArray.push(SecondCard);

                $.post(path, { PlayerName: $(this).children("h4").html(), Cards: CardArray, Score: value, GameId: model.GameId, RoundId: model.RoundId });
            }
        });

    });
});
//Stop Button
$(function () {

    $('#Stop').on('click', function () {
        $('.Participant').each(function (i) {
            if (i !== 0) {
                BotLogic(i);
            }
        });
    });
});

function BotLogic(i) {
        var CardArray = new Array();
        while ($('.Score').eq(i).html() < 17) {
            var Card = GetCard();
            var value = $('.Score').eq(i).html();
            var Hand = $('.Hand').eq(i).html();

            $('.Hand').eq(i).html(Hand + ", " + Card.Name + " " + Card.Suit);
            value >= 11 && Card.Value === 11 ? $('.Score').eq(i).html(+value + Card.Value - 10) : $('.Score').eq(i).html(+value + Card.Value);
            CardArray.push(Card);
        }
        $.post(path, { PlayerName: $('.Participant').eq(i).children("h4").html(), Cards: CardArray, Score: +$('.Score').eq(i).html(), GameId: model.GameId, RoundId: model.RoundId });
}



$(function () {
    $('#History').on('click', function () {
        var players = model.Bots;
        players.push(model.Player.Properties[0].Hand);
        players.push(model.Dealer);

        $.post(path, model)
    });
});


