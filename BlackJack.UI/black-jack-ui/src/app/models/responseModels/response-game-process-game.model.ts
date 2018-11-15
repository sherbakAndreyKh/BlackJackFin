export class ResponseGameProcessGameView{
    Game: GameGameProcessGameViewItem;
    Round: RoundGameProcessGameViewItem;
    Player: PlayerGameProcessGameViewItem;
    Dealer: PlayerGameProcessGameViewItem;
    Bots: PlayerGameProcessGameViewItem[];
}

export class PlayerGameProcessGameViewItem{
    Id: number;
    Name: string;
    Role: number;
    PlayerRoundHand: PlayerRoundHandGameProcessGameViewItem;
}

export class PlayerRoundHandGameProcessGameViewItem{
    Id: number;
    Hand: CardGameProcessGameViewItem[];
    Score: number;
    PlayerId: number;
    RoundId: number;    
}

export class CardGameProcessGameViewItem{
    Id: number;
    Name: string;
    Suit: string;
    ImgPath: string; 
}

export class GameGameProcessGameViewItem{
    Id: number;
    GameNumber: number;
}

export class RoundGameProcessGameViewItem{
    Id: number;
    RoundNumber: number;
    Winner: string;
}