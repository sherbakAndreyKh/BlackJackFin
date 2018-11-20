export class GameListHistoryView {
    player: PlayerGameListHistoryViewItem;
    games: GameGameListHistoryViewItem[];
}

export class PlayerGameListHistoryViewItem {
    id: number;
    name: string;
}

export class GameGameListHistoryViewItem {
    id: number;
    number: number;
    roundsAmount: number;
}
