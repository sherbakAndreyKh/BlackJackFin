export class RequestBotLogicGameView{
    Round: RoundRoundHandBotLogicGameViewItem;
    Hand: PlayerRoundHandBotLogicGameViewItem;
}

export class PlayerRoundHandBotLogicGameViewItem{
    Id: number;
    Hand: CardBotLogicGameViewItem[];
    Score: number;
    PlayerId: number;
}

export class CardBotLogicGameViewItem
{
    Id: number;
    Name: string;
    Suit: string;
    IMgPath: string;
}

export class RoundRoundHandBotLogicGameViewItem
{
    Id: number;
}