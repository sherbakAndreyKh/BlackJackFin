export class ResponseGameProcessGameView {
    game: GameGameProcessGameViewItem;
    round: RoundGameProcessGameViewItem;
    player: PlayerGameProcessGameViewItem;
    dealer: PlayerGameProcessGameViewItem;
    bots: PlayerGameProcessGameViewItem[];
}

export class PlayerGameProcessGameViewItem {
    id: number;
    name: string;
    role: number;
    playerRoundHand: PlayerRoundHandGameProcessGameViewItem;
}

export class PlayerRoundHandGameProcessGameViewItem {
    id: number;
    hand: CardGameProcessGameViewItem[];
    score: number;
    playerId: number;
    roundId: number;
}

export class CardGameProcessGameViewItem {
    id: number;
    name: string;
    suit: string;
    imgPath: string;
}

export class GameGameProcessGameViewItem {
    id: number;
    gameNumber: number;
}

export class RoundGameProcessGameViewItem {
    id: number;
    roundNumber: number;
    winner: string;
}
