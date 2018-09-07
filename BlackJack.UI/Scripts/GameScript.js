
var Bool = false;


function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function GetCard() {
    return model.CardDeck[getRandomInt(0, 51)];
}

//Add Card
$(function () {
    $('#Take').on('click', function () {
        var Card = GetCard();
        var value = $('.Score').eq(0).html();
        var Hand = $('.Hand').eq(0).html();
        $('.Hand').eq(0).html(Hand + ", " + Card.Name + " " + Card.Suit);
        value >= 11 && Card.Value === 11 ? $('.Score').eq(0).html(+value + Card.Value - 10) : $('.Score').eq(0).html(+value + Card.Value);
        model.Player.Properties[0].Score = $('.Score').eq(0).html();  
        model.Player.Properties[0].Hand.push(Card);

        MoreLess(model.Player.Properties[0].Score);
       
    });
  
});
function MoreLess(participant) {
    if (participant > 21) {
        alert('Too Much!');
    }
    if (participant === 21) {
        alert('enough');
    }
}

//First Deal
$(function () {
    $('#First').on('click', function () {

        $('.Participant').each(function (i) {
            var FirstCard = GetCard();
            var SecondCard = GetCard();

            if ($(this).children('p').children('.Score').html() === "0") {
                $(this).children('.Hand').html(FirstCard.Name + " " + FirstCard.Suit + ", " + SecondCard.Name + " " + SecondCard.Suit);
                var value = FirstCard.Value === 11 && SecondCard.Value === 11 ? +FirstCard.Value + SecondCard.Value - 10 : +FirstCard.Value + SecondCard.Value;
                $(this).children('p').children('.Score').html(value);
                if (i === 0) {
                    model.Player.Properties[0].Hand.push(FirstCard);
                    model.Player.Properties[0].Hand.push(SecondCard);
                    model.Player.Properties[0].Score = value;
                }
                if (i === $('.Participant').length - 1) {
                    model.Dealer.Properties[0].Hand.push(FirstCard);
                    model.Dealer.Properties[0].Hand.push(SecondCard);
                    model.Dealer.Properties[0].Score = value;
                }
                if (i !== 0 && i !== $('.Participant').length - 1) {
                    model.Bots[i - 1].Properties[0].Hand.push(FirstCard);
                    model.Bots[i - 1].Properties[0].Hand.push(SecondCard);
                    model.Bots[i - 1].Properties[0].Score = value;
                }
            }
        });
        findBlackJack();
    });
});



function findBlackJack() {
    if (model.Player.Properties[0].Score === 21 && model.Player.Properties[0].Score !== model.Dealer.Properties[0].Score) {
        alert(model.Player.Name + ' BlackJack!');
        model.Round.Winner = model.Player.Name;
        model.Round.WinnerScore = model.Player.Score;
    }
    if (model.Dealer.Properties[0].Score === 21 && model.Dealer.Properties[0].Score !== model.Player.Properties[0].Score) {
        alert(model.Dealer.Name + ' BlackJack!');
        model.Round.Winner = model.Dealer.Name;
        model.Round.WinnerScore = model.Dealer.Properties[0].Score;
    }
    if (model.Dealer.Properties[0].Score === 21 && model.Dealer.Properties[0].Score === model.Player.Properties[0].Score) {
        alert('Draw..');
        model.Round.Winner = 'Draw';
        model.Round.WinnerScore = model.Dealer.Properties[0].Score;
    }
}



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
    while ($('.Score').eq(i).html() < 17) {
        var Card = GetCard();
        var value = $('.Score').eq(i).html();
        var Hand = $('.Hand').eq(i).html();

        $('.Hand').eq(i).html(Hand + ", " + Card.Name + " " + Card.Suit);
        value >= 11 && Card.Value === 11 ? $('.Score').eq(i).html(+value + Card.Value - 10) : $('.Score').eq(i).html(+value + Card.Value);
        if (i === $('.Participant').length - 1) {
            model.Dealer.Properties[0].Hand.push(Card);
            model.Dealer.Properties[0].Score += Card.Value;
        }
        else {
            model.Bots[i - 1].Properties[0].Hand.push(Card);
            model.Bots[i - 1].Properties[0].Score += Card.Value;
        }
        if (MoreLess(model.Dealer.Properties[0].Score)) {
            break;
        }
    }
}



$(function () {
    $('#History').on('click', function () {
        $.post(path, model);
    });
});

