
export class ResponseBotLogicGameView{
    Hand: PlayerRoundHandBotLogicGameViewItem;
}

export class PlayerRoundHandBotLogicGameViewItem{
    Id: number;
    Hand: CardBotLogicGameViewItem[];
    Score: number;
    PlayerId: number;
    RoundId: number;
} 

export class CardBotLogicGameViewItem{
    Id: number;
    Name: string;
    Suit: string;
    ImgPath: string;
}
