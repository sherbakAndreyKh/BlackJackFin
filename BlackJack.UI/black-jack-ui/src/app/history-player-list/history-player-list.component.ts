import { Component, OnInit } from '@angular/core';
import { HttpHistoryPlayerListService }  from '../services/http-history-player-list.service';
import { IndexHistoryView } from '../models/index-history.model';
import { HttpClient } from 'selenium-webdriver/http';


@Component({
  selector: 'app-history-player-list',
  templateUrl: './history-player-list.component.html',
  styleUrls: ['./history-player-list.component.css'],
  providers: [HttpHistoryPlayerListService]
})
export class HistoryPlayerListComponent implements OnInit {

  model: IndexHistoryView;

  constructor(private service: HttpHistoryPlayerListService) { }

  ngOnInit() {   
    this.service.HttpGetPlayerList().subscribe((data: IndexHistoryView)=> this.model = data);
  }

  buttonClick(id:number) {
    debugger;
  
  }
  
}
