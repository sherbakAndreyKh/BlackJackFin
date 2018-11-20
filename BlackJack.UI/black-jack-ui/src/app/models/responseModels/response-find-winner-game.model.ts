export class ResponseFindWinnerGameView {
    round: RoundFindWinnerGameViewItem;
}

export class RoundFindWinnerGameViewItem {
    id: number;
    winner: string;
    winnerScore: number;
    roundNumber: number;
    gameId: number;
}
