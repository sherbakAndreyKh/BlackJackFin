export class ResponseGetFirstDealGameView {
    hands: PlayerRoundHandGetFirstDealGameViewItem[];
}

export class PlayerRoundHandGetFirstDealGameViewItem {
    id: number;
    hand: CardGetFirstDealGameViewItem[];
    score: number;
    playerId: number;
}

export class CardGetFirstDealGameViewItem {
    id: number;
    name: string;
    suit: string;
    imgPath: string;
}

