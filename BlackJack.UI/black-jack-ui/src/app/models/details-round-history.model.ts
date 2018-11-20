export class DetailRoundHistoryView {
    players: PlayerDetailsRoundHistoryViewItem[];
}

export class PlayerDetailsRoundHistoryViewItem {
    name: string;
    playerRoundHand: PlayerRoundHandDetailsRoundHistoryViewItem[];
}

export class PlayerRoundHandDetailsRoundHistoryViewItem {
    score: number;
    playerId: number;
    roundId: number;
    hand: CardDetailsRoundHistoryViewItem[];
}

export class CardDetailsRoundHistoryViewItem {
    name: string;
    suit: string;
    value: number;
    imgPath: string;
}
