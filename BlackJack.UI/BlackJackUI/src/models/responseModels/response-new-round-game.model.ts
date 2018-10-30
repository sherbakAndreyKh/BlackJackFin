export class ResponseNewRoundGameView{
    game: GameNewRoundGameViewItem;
    round: RoundNewRoundGameViewItem;
    player: PlayerNewRoundGameViewItem;
    dealer: PlayerNewRoundGameViewItem
    bots: PlayerNewRoundGameViewItem[];
    winner: string;
}

export class PlayerNewRoundGameViewItem{
    id: number;
    name: string;
    role: number;
    playerRoundHand: PlayerRoundHandNewRoundGameViewItem;
}

export class PlayerRoundHandNewRoundGameViewItem{
    id: number;
    hand: CardNewRoundGameViewItem[];
    score: number;
    playerId: number;
    roundId: number;
}

export class CardNewRoundGameViewItem{
    id: number;
    name: string;
    suit: string;
    imgPath: string;
}

export class GameNewRoundGameViewItem{
    id: number;
    gameNumber: number;
}

export class RoundNewRoundGameViewItem{
    id: number;
    roundNumber: number;
    Winner: string;
    gameId: number;
    winnerScore: number;
}
