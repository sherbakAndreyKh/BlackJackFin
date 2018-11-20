export class RequestFindWinnerGameView {
    playerHand: PlayerRoundHandFindWinnerGameViewItem;
    dealerHand: PlayerRoundHandFindWinnerGameViewItem;
}
export class PlayerRoundHandFindWinnerGameViewItem {
    id: number;
    score: number;
    playerId: number;
    roundId: number;
}
