import { Component, OnInit, } from '@angular/core';
import { RoundListHistoryView } from '../models/round-list-history.model';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient } from "@angular/common/http";
import { DetailRoundHistoryView } from "../models/details-round-history.model";

@Component({
  selector: 'app-history-games-round-list',
  templateUrl: './history-games-round-list.component.html',
  styleUrls: ['./history-games-round-list.component.css']
})

export class HistoryGamesRoundListComponent implements OnInit {
model: RoundListHistoryView
modalModel: DetailRoundHistoryView;
opened = false;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private location: Location
  ) { }

  ngOnInit() {
    this.getRoundGames();
  }
  getRoundGames(){
    const id = +this.route.snapshot.paramMap.get('id');
    this.http.get("http://localhost:50219/history/getrounds/" +id).subscribe((data: RoundListHistoryView)=> this.model = data);
  }
  
  getModal(id: number){
    if(this.opened){
      this.opened = false;
    }
    else{
    this.opened = true;
    this.http.get("http://localhost:50219/history/GetRoundsDetail/" +id).subscribe((data: DetailRoundHistoryView)=> this.modalModel = data);
    }
  }
}
