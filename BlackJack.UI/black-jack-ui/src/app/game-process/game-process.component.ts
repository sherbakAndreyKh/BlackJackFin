import { Component, OnInit, Input } from '@angular/core';
import { ResponseGameProcessGameView } from '../models/responseModels/response-game-process-game.model';
import { HttpGameProcessService } from '../services/http-game-process.servise';
import { RequestGetCardGameView } from '../models/requestModels/request-get-card-game-view';
import { ResponseGetCardGameView } from '../models/responseModels/response-get-card-game.model';
import { RequestGetFirstDealGameView } from '../models/requestModels/request-get-first-deal-game-view';
import { ResponseGetFirstDealGameView } from '../models/responseModels/response-get-first-deal-game.model';
import { RequestBotLogicGameView } from '../models/requestModels/request-bot-logic-game-view';
import { ResponseBotLogicGameView } from '../models/responseModels/response-bot-logic-game.model'; 
import { RequestFindWinnerGameView } from '../models/requestModels/request-find-winner-game-view';
import { ResponseFindWinnerGameView} from '../models/responseModels/response-find-winner-game.model';

@Component({
  selector:   'app-game-process',
  templateUrl: './game-process.component.html',
  styleUrls: ['./game-process.component.css']
})
export class GameProcessComponent implements OnInit {

@Input() model: ResponseGameProcessGameView;
getCardRequest: RequestGetCardGameView = new RequestGetCardGameView();
getFirstDealRequest: RequestGetFirstDealGameView = new RequestGetFirstDealGameView();
getBotAndDealerLogicRequest: RequestBotLogicGameView = new RequestBotLogicGameView();
findWinner: RequestFindWinnerGameView = new RequestFindWinnerGameView();

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
 
  getBotAndDealerLogic(count: number){
    this.service.HttpGetBotAndDealerLogic(this.addBotAndDealerRequest(count)).subscribe((data: ResponseBotLogicGameView)=> this.getHand(count).PlayerRoundHand = data.Hand)
  }

  addFindWinnerRequest(){
    this.findWinner.DealerHand = this.model.Dealer.PlayerRoundHand;
    this.findWinner.PlayerHand = this.model.Player.PlayerRoundHand;
    return this.findWinner;
  }
  getWinner(){
    debugger;
    this.UseLogicOnBotAndDealer(); 
    debugger;
    this.service.HttpGetWinner(this.addFindWinnerRequest()).subscribe((data: ResponseFindWinnerGameView)=> this.model.Round = data.Round)
  }
   
  getHand(count){
      if(count< this.model.Bots.length){
      return this.model.Bots[count];
      }
      if (count == this.model.Bots.length) {
      return this.model.Dealer;
    }
  }

  UseLogicOnBotAndDealer() {
    for (var i = 0; i <= this.model.Bots.length; i++) {
        this.getBotAndDealerLogic(i);
    }
}

  addBotAndDealerRequest(count: number){
    var hand;
    if(count< this.model.Bots.length){
      hand = this.model.Bots[count].PlayerRoundHand;
    }
    if (count == this.model.Bots.length) {
      hand = this.model.Dealer.PlayerRoundHand;
  }
   this.getBotAndDealerLogicRequest.Round = this.model.Round;
   this.getBotAndDealerLogicRequest.Hand = hand;
    return this.getBotAndDealerLogicRequest;
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
