export class GameListHistoryView{
    Player: PlayerGameListHistoryViewItem;
    Games: GameGameListHistoryViewItem[];
}

export class PlayerGameListHistoryViewItem{
    Id: number;
    Name: string; 
}

export class GameGameListHistoryViewItem{
    Id: number;
    Number: number;
    RoundsAmount: number;
}