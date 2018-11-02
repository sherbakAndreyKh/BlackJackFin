 export class ResponseGameStartOptionsGameView{
    PlayerName: string;
    BotsAmount: number;
    Players: PlayerGameStartOptionsViewItem[];
    constructor() {
        this.Players = new Array<PlayerGameStartOptionsViewItem>();
    }
}

 export class PlayerGameStartOptionsViewItem{
    PlayerName: string;
}