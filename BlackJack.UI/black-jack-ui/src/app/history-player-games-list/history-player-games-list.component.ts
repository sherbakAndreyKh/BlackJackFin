import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';

import { GameListHistoryView } from 'src/app/models/game-list-history.model';
import { HttpHistoryPlayerGamesListService } from 'src/app/services/http-history-player-games-list.service';

@Component({
    selector: 'app-history-player-games-list',
    templateUrl: './history-player-games-list.component.html',
    styleUrls: ['./history-player-games-list.component.css'],
    providers: [HttpHistoryPlayerGamesListService]
})
export class HistoryPlayerGamesListComponent implements OnInit {
    model: GameListHistoryView
    constructor(
        private route: ActivatedRoute,
        private http: HttpClient,
        private location: Location,
        private service: HttpHistoryPlayerGamesListService
    ) { }

    ngOnInit() {
        this.getPlayerGames();
    }
    getPlayerGames() {
        const id = +this.route.snapshot.paramMap.get('id');
        this.service.httpGetPlayerGames(id).subscribe((data: GameListHistoryView) => this.model = data, error => console.log(error));
    }
}


