export class RequestGetCardGameView
{
    Round: RoundRoundHandGetCardGameViewItem;  
    Hand: PlayerRoundHandGetCardGameViewItem; 
}

export class PlayerRoundHandGetCardGameViewItem
{
    Id: number;
    Hand: CardGetCardGameViewItem[];
    Score: number;
    PlayerId: number;
}

export class CardGetCardGameViewItem
{
    Id: number;
    Name: string;
    Suit: string;
    ImgPath: string;
}

export class RoundRoundHandGetCardGameViewItem
{
   Id: number;
}