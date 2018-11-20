export class DetailRoundHistoryView {
    Players: PlayerDetailsRoundHistoryViewItem[];
}

export class PlayerDetailsRoundHistoryViewItem {
    Name: string;
    PlayerRoundHand: PlayerRoundHandDetailsRoundHistoryViewItem[];
}

export class PlayerRoundHandDetailsRoundHistoryViewItem {
    Score: number;
    PlayerId: number;
    RoundId: number;
    Hand: CardDetailsRoundHistoryViewItem[];
}

export class CardDetailsRoundHistoryViewItem {
    Name: string;
    Suit: string;
    Value: number;
    ImgPath: string;
}
