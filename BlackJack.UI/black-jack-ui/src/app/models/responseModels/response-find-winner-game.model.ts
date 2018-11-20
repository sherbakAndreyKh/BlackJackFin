export class ResponseFindWinnerGameView {
    Round: RoundFindWinnerGameViewItem;
}

export class RoundFindWinnerGameViewItem {
    Id: number;
    Winner: string;
    WinnerScore: number;
    RoundNumber: number;
    GameId: number;
}
