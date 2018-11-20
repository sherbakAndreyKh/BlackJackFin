export class RoundListHistoryView {
    playersAmount: number;
    rounds: RoundRoundListHistoryViewItem[];
}

export class RoundRoundListHistoryViewItem {
    id: number;
    winner: string;
    winnerScore: number;
    roundNumber: number;
}
