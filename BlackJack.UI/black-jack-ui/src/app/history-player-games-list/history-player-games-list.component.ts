import { Component, OnInit, Input } from '@angular/core';
import { GameListHistoryView } from '../models/game-list-history.model';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-history-player-games-list',
  templateUrl: './history-player-games-list.component.html',
  styleUrls: ['./history-player-games-list.component.css']
})
export class HistoryPlayerGamesListComponent implements OnInit {
  model: GameListHistoryView
  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private location: Location
  ) { }

  ngOnInit() {
    this.getPlayerGames();
  }
getPlayerGames(){
  const id= +this.route.snapshot.paramMap.get('id');
  this.http.get("http://localhost:50219/history/getgames/" + id).subscribe((data: GameListHistoryView)=> this.model = data);
}
  
}
