export class ResponseGetCardGameView{
    Hand: PlayerRoundHandGetCardGameViewItem;
}

export class PlayerRoundHandGetCardGameViewItem{
    Id: number;
    Hand: CardGetCardGameViewItem[];
    Score: number;
    PlayerId: number;
    RoundId: number;
}

export class CardGetCardGameViewItem{
    Id: number;
    Name: string;
    Suit: string;
    ImgPath: string;
}