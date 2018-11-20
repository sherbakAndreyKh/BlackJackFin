export class RequestNewRoundGameView
{
    game: GameNewRoundGameViewItem;
    round: RoundNewRoundGameViewItem;
    player: PlayerNewRoundGameViewItem;
    dealer: PlayerNewRoundGameViewItem;
    bots: PlayerNewRoundGameViewItem[];
}

export class PlayerNewRoundGameViewItem
{
    id: number;
    name: string;
    role: number;
    playerRoundHand: PlayerRoundHandNewRoundGameViewItem;
}

export class PlayerRoundHandNewRoundGameViewItem
{
    id: number;
    score: number;
    playerId: number;
    roundId: number;
}

export class GameNewRoundGameViewItem
{
    id: number;
    gameNumber: number;
}

export class RoundNewRoundGameViewItem
{
    id: number;
    roundNumber: number;
    winner: string;
}