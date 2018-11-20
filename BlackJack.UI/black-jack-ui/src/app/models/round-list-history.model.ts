export class RoundListHistoryView{
    PlayersAmount: number;
    Rounds: RoundRoundListHistoryViewItem[];
}

export class RoundRoundListHistoryViewItem{
    Id: number;
    Winner: string;
    WinnerScore: number;
    RoundNumber: number;
}