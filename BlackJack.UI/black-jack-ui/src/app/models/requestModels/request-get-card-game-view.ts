export class RequestGetCardGameView {
    round: RoundRoundHandGetCardGameViewItem;
    hand: PlayerRoundHandGetCardGameViewItem;
}

export class PlayerRoundHandGetCardGameViewItem {
    id: number;
    hand: CardGetCardGameViewItem[];
    score: number;
    playerId: number;
}

export class CardGetCardGameViewItem {
    id: number;
    name: string;
    suit: string;
    imgPath: string;
}

export class RoundRoundHandGetCardGameViewItem {
    id: number;
}
