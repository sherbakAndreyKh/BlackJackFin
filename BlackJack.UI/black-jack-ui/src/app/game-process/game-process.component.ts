import { Component, OnInit, Input } from '@angular/core';
import { ResponseGameProcessGameView } from '../models/responseModels/response-game-process-game.model';
import { HttpGameProcessService } from '../services/http-game-process.servise';
import { RequestGetCardGameView } from '../models/requestModels/request-get-card-game-view';
import { ResponseGetCardGameView } from '../models/responseModels/response-get-card-game.model';

@Component({
  selector: 'app-game-process',
  templateUrl: './game-process.component.html',
  styleUrls: ['./game-process.component.css']
})
export class GameProcessComponent implements OnInit {
@Input() model: ResponseGameProcessGameView;
getCardModel: RequestGetCardGameView = new RequestGetCardGameView();


  constructor(private service: HttpGameProcessService) { }

  ngOnInit() {
  }

 

  getCardClick(){
    this.getCardModel.Hand = this.model.Player.PlayerRoundHand
    this.getCardModel.Round = this.model.Round;

  
    this.service.HttpGetCard(this.getCardModel)
    .subscribe((data:ResponseGetCardGameView)=> this.model.Player.PlayerRoundHand = data.Hand);
  }
}
