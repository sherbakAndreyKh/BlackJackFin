export class ResponseBotLogicGameView{
    hand: PlayerRoundHandBotLogicGameViewItem[];
}

export class PlayerRoundHandBotLogicGameViewItem{
    id: number;
    hand: CardBotLogicGameViewItem[];
    score: number;
    playerId: number;
} 

export class CardBotLogicGameViewItem{
    id: number;
    name: string;
    suit: string;
    imgPath: string;
}