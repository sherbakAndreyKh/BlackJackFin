import { Component, OnInit } from '@angular/core';
import { HttpStartGameOptionsService } from 'src/app/services/http-start-game-options.service';
import { ResponseGameStartOptionsGameView } from 'src/app/models/responseModels/response-game-start-options-game.model';
import { RequestGameStartOptionsView } from 'src/app/models/requestModels/request-game-start-options-game.model';
import { ResponseGameProcessGameView } from 'src/app/models/responseModels/response-game-process-game.model';
import { HttpGameProcessService } from 'src/app/services/http-game-process.servise';

@Component({
    selector: 'app-start-game-options',
    templateUrl: './start-game-options.component.html',
    styleUrls: ['./start-game-options.component.css'],
    providers: [HttpStartGameOptionsService, HttpGameProcessService]
})

export class StartGameOptionsComponent implements OnInit {

    listPlayersName: string[];
    botsAmount: number[] = [0, 1, 2, 3, 4, 5];
    public opened = true;
    model: ResponseGameStartOptionsGameView;
    reqModel: RequestGameStartOptionsView = new RequestGameStartOptionsView();
    responseModel: ResponseGameProcessGameView;

    constructor(private service: HttpStartGameOptionsService) { }

    ngOnInit() {
        this.service.HttpGetStartOptions().subscribe((data: ResponseGameStartOptionsGameView) => {
            this.listPlayersName = this.getNames(data);
        });
    }

    public getNames(test: ResponseGameStartOptionsGameView): string[] {
        var result: string[] = new Array();

        for (var i = 0; i < test.players.length; i++) {
            result.push(test.players[i].playerName);
        }

        return result;
    }

    public close() {
        this.opened = false;
    }

    public open() {
        this.opened = true;
    }

    public submit(playerName: string, botsAmount: number) {
        this.reqModel.playerName = playerName;
        this.reqModel.botsAmount = botsAmount;

        this.service.HttpPostStartOptions(this.reqModel).subscribe((data: ResponseGameProcessGameView) => {
            this.responseModel = data;
        });

        this.close();
    }
}
