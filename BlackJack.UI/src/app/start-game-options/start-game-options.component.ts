import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseGameStartOptionsGameView } from '../../models/responseModels/response-game-start-options-game.model';

@Component({
  selector: 'app-start-game-options',
  templateUrl: './start-game-options.component.html',
  styleUrls: ['./start-game-options.component.css']
})
export class StartGameOptionsComponent implements OnInit {
  model: ResponseGameStartOptionsGameView;
  
  constructor(private http: HttpClient) {
   }

  ngOnInit() {
      this.http.get('http://localhost:50219/Game/GameStartOptions').subscribe((data: ResponseGameStartOptionsGameView) =>  this.model = data);
              
  }
}
