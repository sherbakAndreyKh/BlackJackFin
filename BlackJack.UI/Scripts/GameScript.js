
var Bool = false;

function GetCard() {
    var card = model.CardDeck.shift();
    return card;
}

function MoreLess(participant) {
    if (participant > 21) {
        alert('Too Much!');
    }
    if (participant === 21) {
        alert('enough');
    }
}

function FindWinner(player, dealer) {
    if (player.Properties[0].Score <= 21 && player.Properties[0].Score > dealer.Properties[0].Score) {
        alert(player.Name + " Win!");
        model.Round.Winner = player.Name;
        model.Round.WinnerScore = player.Properties[0].Score;

    }
    if (player.Properties[0].Score <= 21 && dealer.Properties[0].Score > 21) {
        alert(player.Name + " Win!");
        model.Round.Winner = player.Name;
        model.Round.WinnerScore = player.Properties[0].Score;
    }

    if (player.Properties[0].Score <= 21 && player.Properties[0].Score === dealer.Properties[0].Score) {
        alert("Draw");
        model.Round.Winner = "Draw";
    }
    if (player.Properties[0].Score > 21 && dealer.Properties[0].Score > 21) {
        alert("Draw");
        model.Round.Winner = "Draw";
    }
    if (dealer.Properties[0].Score <= 21 && player.Properties[0].Score < dealer.Properties[0].Score) {
        alert(dealer.Name + " Win!");
        model.Round.Winner = dealer.Name;
        model.Round.WinnerScore = dealer.Properties[0].Score;
    }
    if (dealer.Properties[0].Score <= 21 && player.Properties[0].Score > 21) {
        alert(dealer.Name + " Win!");
        model.Round.Winner = dealer.Name;
        model.Round.WinnerScore = dealer.Properties[0].Score;
    }
}

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

function BotLogic(i) {
    while ($('.Score').eq(i).html() < 17) {
        var Card = GetCard();
        var value = $('.Score').eq(i).html();
        var Hand = $('.Hand').eq(i).html();

        $('.Hand').eq(i).html(Hand + ", " + Card.Name + " " + Card.Suit);
        value >= 11 && Card.Value === 11 ? $('.Score').eq(i).html(+value + Card.Value - 10) : $('.Score').eq(i).html(+value + Card.Value);

        var participantValLength = $('.Participant').length;

        if (i === participantValLength - 1) {
            model.Dealer.Properties[0].Hand.push(Card);
            model.Dealer.Properties[0].Score += Card.Value;
        }
        if (i !== participantValLength - 1) {
            model.Bots[i - 1].Properties[0].Hand.push(Card);
            model.Bots[i - 1].Properties[0].Score += Card.Value;
        }
        if (MoreLess(model.Dealer.Properties[0].Score)) {
            break;
        }
    }
}

$('#History').on('click', function () {
    FindWinner(model.Player, model.Dealer);
    var result = confirm("PLay next Round?");
    if (result) {
        $.post(path, model)
            .done(function (data) {
                $('body').html(data);
            });
    }
    if (!result) {
        $.post(pathEnd, model);
    }
});

//Add Card
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

//First Deal
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

//Stop Button
$('#Stop').on('click', function () {
    $('.Participant').each(function (i) {
        if (i !== 0) {
            BotLogic(i);
        }
    });
});