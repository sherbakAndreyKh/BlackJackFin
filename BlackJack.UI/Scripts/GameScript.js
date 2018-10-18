var getFirstDealPath = $('#pathList').data("getFirstDeal");
var getOneCardPath = $('#pathList').data("getCard");
var getNewRoundPath = $('#pathList').data("newRound");
var getBotAndDealerLogicPath = $('#pathList').data("botAndDealerLogic");
var getFindWinnerPath = $('#pathList').data("findWinner");
var BlackJack = 21;

$(function () {
    var Hands = new Array();
    Hands.push(model.Dealer.PlayerRoundHand);
    Hands.push(model.Player.PlayerRoundHand);
    for (var i = 0; i < model.Bots.length; i++) {
        Hands.push(model.Bots[i].PlayerRoundHand);
    }

    $.post(getFirstDealPath, { 'Round': model.Round, 'Hands': Hands })
        .done(function (data) {
            $('.Participant').each(function (i) {
                var firstCard = data.Hands[i].Hand[0].Name + " " + data.Hands[i].Hand[0].Suit;
                var secondCard = data.Hands[i].Hand[1].Name + " " + data.Hands[i].Hand[1].Suit;
                $(this).children('.Hand').html(firstCard + ", " + secondCard);
                $(this).children('p').children('.Score').html(data.Hands[i].Score);
            });
        });
});

$('#Take').on('click', function OneCard() {
    var Hand = model.Player.PlayerRoundHand;

    $.post(getOneCardPath, { 'Round': model.Round, 'Hand': Hand })
        .done(function (data) {
            var card = "";
            for (var i = 0; i < data.Hand.Hand.length; i++) {
                var handI = data.Hand.Hand[i];
                card += handI.Name + " " + handI.Suit + " ";
            }
            $('.Participant').eq(0).children('.Hand').html(card);
            $('.Participant').eq(0).children('p').children('.Score').html(data.Hand.Score);

            if (data.Hand.Score > 21) {
                alert("To Much");

                UseLogicOnBotAndDealer();

            }
            if (data.Hand.Score == 21) {
                alert(model.Player.Name + " Have 21");
                UseLogicOnBotAndDealer();
            }
        });
});

function UseLogicOnBotAndDealer() {
    for (var i = 0; i <= model.Bots.length; i++) {
        BotLogic(i);
    }
    FindWinner();
}

$('#Stop').on('click', function () { UseLogicOnBotAndDealer(); });

function FindWinner() {
    $.post(getFindWinnerPath, { 'PlayerHand': model.Player.PlayerRoundHand, 'DealerHand': model.Dealer.PlayerRoundHand })
        .done(function (data) {
            if (data.Round.Winner == "Draw") {
                alert(data.Round.Winner + " in this Round");
                NewRound();
            }
            if (data.Round.Winner != "Draw") {
                alert(data.Round.Winner + " Win!");
                NewRound();
            }
        });
}

function NewRound() {
    var result = confirm("PLay next Round?");
    if (result) {
        $.post(getNewRoundPath, model)
            .done(function (data) {
                $('body').html(data);
            });
    }
    if (!result) {
        alert("Game Over");
    }
}

function BotLogic(count) {
    var hand;
    if (count < model.Bots.length) {
        hand = model.Bots[count].PlayerRoundHand;
    }
    if (count == model.Bots.length) {
        hand = model.Dealer.PlayerRoundHand;
    }
    $.post(getBotAndDealerLogicPath, { 'Round': model.Round, 'Hand': hand })
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


