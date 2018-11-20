export class ResponseGetCardGameView {
    hand: PlayerRoundHandGetCardGameViewItem;
}

export class PlayerRoundHandGetCardGameViewItem {
    id: number;
    hand: CardGetCardGameViewItem[];
    score: number;
    playerId: number;
    roundId: number;
}

export class CardGetCardGameViewItem {
    id: number;
    name: string;
    suit: string;
    imgPath: string;
}
