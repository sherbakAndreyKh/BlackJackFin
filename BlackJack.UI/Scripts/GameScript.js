var bool = true;

$('#First').on('click', function FirstDeal() {

    if (bool) {
        bool = false;
        var Hands = new Array();
        Hands.push(model.Dealer.PlayerRoundHand);
        Hands.push(model.Player.PlayerRoundHand);
        for (var i = 0; i < model.Bots.length; i++) {
            Hands.push(model.Bots[i].PlayerRoundHand);
        }

        $.post(testPath, { 'Round': model.Round, 'Hands': Hands })
            .done(function (data) {
                $('.Participant').each(function (i) {
                    var firstCard = data.Hands[i].Hand[0].Name + " " + data.Hands[i].Hand[0].Suit;
                    var secondCard = data.Hands[i].Hand[1].Name + " " + data.Hands[i].Hand[1].Suit;
                    $(this).children('.Hand').html(firstCard + ", " + secondCard);
                    $(this).children('p').children('.Score').html(data.Hands[i].Score);
                });
            });
    }
});

$('#Take').on('click', function OneCard() {
    var Hand = model.Player.PlayerRoundHand;

    $.post(singleTestPath, { 'Round': model.Round, 'Hand': Hand })
        .done(function (data) {
            var card = "";
            for (var i = 0; i < data.Hand.Hand.length; i++) {
                var handI = data.Hand.Hand[i];
                card += handI.Name + " " + handI.Suit + " ";
            }
            $('.Participant').eq(0).children('.Hand').html(card);
            $('.Participant').eq(0).children('p').children('.Score').html(data.Hand.Score);

            if (data.Hand.Score >= 21) {
                for (i = 0; i <= model.Bots.length; i++) {
                    BotLogic(i);
                }
                //findWinner();
            }
        });
});



function test() {
    for (var i = 0; i <= model.Bots.length; i++) {
        BotLogic(i);
    }
    findWinner();
}
    $('#Stop').on('click', function () { test(); });




    function findWinner() {
        $.post(pathTestTest, { 'PlayerHand': model.Player.PlayerRoundHand, 'DealerHand': model.Dealer.PlayerRoundHand })
            .done(function (data) {
                alert(data.Round.Winner);
            });
    }

    function BotLogic(count) {
        var hand;
        if (count < model.Bots.length) {
            hand = model.Bots[count].PlayerRoundHand;
        }
        if (count == model.Bots.length) {
            hand = model.Dealer.PlayerRoundHand;
        }
        $.post(botTestPath, { 'Round': model.Round, 'Hand': hand })
            .done(function (data) {
                var card = "";
                for (var i = 0; i < data.Hand.Hand.length; i++) {
                    var handI = data.Hand.Hand[i];
                    card += handI.Name + " " + handI.Suit + " ";
                }
                $('.Participant').eq(count + 1).children('.Hand').html(card);
                $('.Participant').eq(count + 1).children('p').children('.Score').html(data.Hand.Score);
            });
    }

    $('#History').on('click', function () {
        //FindWinner(model.Player, model.Dealer);
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



//function BotLogic(i) {
//    while ($('.Score').eq(i).html() < 17) {
//        var card = GetCard();
//        var value = $('.Score').eq(i).html();
//        var hand = $('.Hand').eq(i).html();

//        $('.Hand').eq(i).html(hand + ", " + card.Name + " " + card.Suit);
//        value >= 11 && card.Value === jackValue ? $('.Score').eq(i).html(+value + card.Value - 10) : $('.Score').eq(i).html(+value + card.Value);

//        var participantValLength = $('.Participant').length;

//        if (i === participantValLength - 1) {
//            model.Dealer.PlayerRoundHand[0].Hand.push(card);
//            model.Dealer.PlayerRoundHand[0].Score += card.Value;
//        }
//        if (i !== participantValLength - 1) {
//            model.Bots[i - 1].PlayerRoundHand[0].Hand.push(card);
//            model.Bots[i - 1].PlayerRoundHand[0].Score += card.Value;
//        }
//        if (MoreLess(model.Dealer.PlayerRoundHand[0].Score)) {
//            break;
//        }
//    }
//}


//$('#History').on('click', function () {
//    FindWinner(model.Player, model.Dealer);
//    var result = confirm("PLay next Round?");
//    if (result) {
//        $.post(path, model)
//            .done(function (data) {
//                $('body').html(data);
//            });
//    }
//    if (!result) {
//        $.post(pathEnd, model);
//    }
//});

//function GetCard() {
//    var card = model.CardDeck.shift();
//    return card;
//}

//function MoreLess(participant) {
//    if (participant > 21) {
//        alert('Too Much!');
//    }
//    if (participant === 21) {
//        alert('enough');
//    }
//}

//function FindWinner(player, dealer) {
//    if (player.PlayerRoundHand[0].Score <= 21 && player.PlayerRoundHand[0].Score > dealer.PlayerRoundHand[0].Score) {
//        alert(player.Name + " Win!");
//        model.Round.Winner = player.Name;
//        model.Round.WinnerScore = player.PlayerRoundHand[0].Score;

//    }
//    if (player.PlayerRoundHand[0].Score <= 21 && dealer.PlayerRoundHand[0].Score > 21) {
//        alert(player.Name + " Win!");
//        model.Round.Winner = player.Name;
//        model.Round.WinnerScore = player.PlayerRoundHand[0].Score;
//    }

//    if (player.PlayerRoundHand[0].Score <= 21 && player.PlayerRoundHand[0].Score === dealer.PlayerRoundHand[0].Score) {
//        alert("Draw");
//        model.Round.Winner = "Draw";
//    }
//    if (player.PlayerRoundHand[0].Score > 21 && dealer.PlayerRoundHand[0].Score > 21) {
//        alert("Draw");
//        model.Round.Winner = "Draw";
//    }
//    if (dealer.PlayerRoundHand[0].Score <= 21 && player.PlayerRoundHand[0].Score < dealer.PlayerRoundHand[0].Score) {
//        alert(dealer.Name + " Win!");
//        model.Round.Winner = dealer.Name;
//        model.Round.WinnerScore = dealer.PlayerRoundHand[0].Score;
//    }
//    if (dealer.PlayerRoundHand[0].Score <= 21 && player.PlayerRoundHand[0].Score > 21) {
//        alert(dealer.Name + " Win!");
//        model.Round.Winner = dealer.Name;
//        model.Round.WinnerScore = dealer.PlayerRoundHand[0].Score;
//    }
//}

//function findBlackJack() {
//    if (model.Player.PlayerRoundHand[0].Score === 21 && model.Player.PlayerRoundHand[0].Score !== model.Dealer.PlayerRoundHand[0].Score) {
//        alert(model.Player.Name + ' BlackJack!');
//        model.Round.Winner = model.Player.Name;
//        model.Round.WinnerScore = model.Player.Score;
//    }
//    if (model.Dealer.PlayerRoundHand[0].Score === 21 && model.Dealer.PlayerRoundHand[0].Score !== model.Player.PlayerRoundHand[0].Score) {
//        alert(model.Dealer.Name + ' BlackJack!');
//        model.Round.Winner = model.Dealer.Name;
//        model.Round.WinnerScore = model.Dealer.PlayerRoundHand[0].Score;
//    }
//    if (model.Dealer.PlayerRoundHand[0].Score === 21 && model.Dealer.PlayerRoundHand[0].Score === model.Player.PlayerRoundHand[0].Score) {
//        alert('Draw..');
//        model.Round.Winner = 'Draw';
//        model.Round.WinnerScore = model.Dealer.PlayerRoundHand[0].Score;
//    }
//}

//function BotLogic(i) {
//    while ($('.Score').eq(i).html() < 17) {
//        var card = GetCard();
//        var value = $('.Score').eq(i).html();
//        var hand = $('.Hand').eq(i).html();

//        $('.Hand').eq(i).html(hand + ", " + card.Name + " " + card.Suit);
//        value >= 11 && card.Value === jackValue ? $('.Score').eq(i).html(+value + card.Value - 10) : $('.Score').eq(i).html(+value + card.Value);

//        var participantValLength = $('.Participant').length;

//        if (i === participantValLength - 1) {
//            model.Dealer.PlayerRoundHand[0].Hand.push(card);
//            model.Dealer.PlayerRoundHand[0].Score += card.Value;
//        }
//        if (i !== participantValLength - 1) {
//            model.Bots[i - 1].PlayerRoundHand[0].Hand.push(card);
//            model.Bots[i - 1].PlayerRoundHand[0].Score += card.Value;
//        }
//        if (MoreLess(model.Dealer.PlayerRoundHand[0].Score)) {
//            break;
//        }
//    }
//}

//

//$('#Take').on('click', function AddCard () {
//    var card = GetCard();
//    var value = $('.Score').eq(0).html();
//    var hand = $('.Hand').eq(0).html();
//    $('.Hand').eq(0).html(hand + ", " + card.Name + " " + card.Suit);
//    value >= 11 && card.Value === jackValue ? $('.Score').eq(0).html(+value + card.Value - 10) : $('.Score').eq(0).html(+value + card.Value);
//    model.Player.PlayerRoundHand[0].Score = $('.Score').eq(0).html();
//    model.Player.PlayerRoundHand[0].Hand.push(card);

//    MoreLess(model.Player.PlayerRoundHand[0].Score);
//});


    //$('.Participant').each(function (i) {
    //    var firstCard = GetCard();
    //    var secondCard = GetCard();

    //    if ($(this).children('p').children('.Score').html() === "0") {
    //        $(this).children('.Hand').html(firstCard.Name + " " + firstCard.Suit + ", " + secondCard.Name + " " + secondCard.Suit);
    //        var value = firstCard.Value === jackValue && secondCard.Value === jackValue ? +firstCard.Value + secondCard.Value - 10 : +firstCard.Value + secondCard.Value;
    //        $(this).children('p').children('.Score').html(value);
    //        if (i === 0) {
    //            model.Player.PlayerRoundHand[0].Hand.push(firstCard);
    //            model.Player.PlayerRoundHand[0].Hand.push(secondCard);
    //            model.Player.PlayerRoundHand[0].Score = value;
    //        }
    //        if (i === $('.Participant').length - 1) {
    //            model.Dealer.PlayerRoundHand[0].Hand.push(firstCard);
    //            model.Dealer.PlayerRoundHand[0].Hand.push(secondCard);
    //            model.Dealer.PlayerRoundHand[0].Score = value;
    //        }
    //        if (i !== 0 && i !== $('.Participant').length - 1) {
    //            model.Bots[i - 1].PlayerRoundHand[0].Hand.push(firstCard);
    //            model.Bots[i - 1].PlayerRoundHand[0].Hand.push(secondCard);
    //            model.Bots[i - 1].PlayerRoundHand[0].Score = value;
    //        }
    //    }
    ////});
    //findBlackJack();


//$('#Stop').on('click', function Stop () {
//    $('.Participant').each(function (i) {
//        if (i !== 0) {
//            BotLogic(i);
//        }
//    });
//});