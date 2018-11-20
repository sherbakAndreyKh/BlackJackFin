export class RequestFindWinnerGameView {
    PlayerHand: PlayerRoundHandFindWinnerGameViewItem;
    DealerHand: PlayerRoundHandFindWinnerGameViewItem;
}
export class PlayerRoundHandFindWinnerGameViewItem {
    Id: number;
    Score: number;
    PlayerId: number;
    RoundId: number;
}
