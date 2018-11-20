export class ResponseNewRoundGameView {
    Game: GameNewRoundGameViewItem;
    Round: RoundNewRoundGameViewItem;
    Player: PlayerNewRoundGameViewItem;
    Dealer: PlayerNewRoundGameViewItem
    Bots: PlayerNewRoundGameViewItem[];
    Winner: string;
}

export class PlayerNewRoundGameViewItem {
    Id: number;
    Name: string;
    Role: number;
    PlayerRoundHand: PlayerRoundHandNewRoundGameViewItem;
}

export class PlayerRoundHandNewRoundGameViewItem {
    Id: number;
    Hand: CardNewRoundGameViewItem[];
    Score: number;
    PlayerId: number;
    RoundId: number;
}

export class CardNewRoundGameViewItem {
    Id: number;
    Name: string;
    Suit: string;
    ImgPath: string;
}

export class GameNewRoundGameViewItem {
    Id: number;
    GameNumber: number;
}

export class RoundNewRoundGameViewItem {
    Id: number;
    RoundNumber: number;
    Winner: string;
    GameId: number;
    WinnerScore: number;
}
