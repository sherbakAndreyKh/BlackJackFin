export class ResponseGetFirstDealGameView{
    Hands: PlayerRoundHandGetFirstDealGameViewItem[];
}

export class PlayerRoundHandGetFirstDealGameViewItem{
    Id: number;
    Hand: CardGetFirstDealGameViewItem[];
    Score: number;
    PlayerId: number;
}

export class CardGetFirstDealGameViewItem{
    Id: number;
    Name: string;
    Suit: string;
    ImgPath: string; 
}

