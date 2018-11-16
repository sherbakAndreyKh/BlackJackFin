import { Component, OnInit, Input } from '@angular/core';
import { ResponseGameProcessGameView } from '../models/responseModels/response-game-process-game.model';
import { HttpGameProcessService } from '../services/http-game-process.servise';
import { RequestGetCardGameView } from '../models/requestModels/request-get-card-game-view';
import { ResponseGetCardGameView } from '../models/responseModels/response-get-card-game.model';
import { RequestGetFirstDealGameView } from '../models/requestModels/request-get-first-deal-game-view';
import { ResponseGetFirstDealGameView } from '../models/responseModels/response-get-first-deal-game.model';

@Component({
  selector: 'app-game-process',
  templateUrl: './game-process.component.html',
  styleUrls: ['./game-process.component.css']
})
export class GameProcessComponent implements OnInit {

@Input() model: ResponseGameProcessGameView;
getCardRequest: RequestGetCardGameView = new RequestGetCardGameView();
getFirstDealRequest: RequestGetFirstDealGameView = new RequestGetFirstDealGameView();

constructor(private service: HttpGameProcessService) { }
  ngOnInit() {
  }

  addGetCardRequest(){
    this.getCardRequest.Hand = this.model.Player.PlayerRoundHand;
    this.getCardRequest.Round = this.model.Round;
  }

  addFirstDealRequest(){
    this.getFirstDealRequest.Hands = this.getAllHands();
    this.getFirstDealRequest.Round = this.model.Round;
  }

  getCardClick(){
    this.addGetCardRequest();
    this.service.HttpGetCard(this.getCardRequest).subscribe((data: ResponseGetCardGameView) =>  this.model.Player.PlayerRoundHand = data.Hand);
  }

  getFirstDealClick(){
    this.addFirstDealRequest();
    this.service.HttpGetFirstDeal(this.getFirstDealRequest).subscribe((data: ResponseGetFirstDealGameView) => this.addFirstDealResponse(data));
  }
 
  


  addFirstDealResponse(data){
    debugger;
    for(var i=0;i< data.Hands.length; i++){
      if(i==0){
        this.model.Player.PlayerRoundHand = data.Hands[i];
      }
      if(i==data.Hands.length-1){
        this.model.Dealer.PlayerRoundHand = data.Hands[i];
      }
      if(i!=0 && i!= data.Hands.length){
        this.model.Bots[i-1].PlayerRoundHand = data.Hands[i];
      }
    }
  }

  getAllHands(){
    var Hands = new Array();
    Hands.push(this.model.Dealer.PlayerRoundHand);
    Hands.push(this.model.Player.PlayerRoundHand);
    for(var i=0;i < this.model.Bots.length;i++){
      Hands.push(this.model.Bots[i].PlayerRoundHand);
    }
    return Hands
  }
}
