import { Component, OnInit, } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { RoundListHistoryView } from 'src/app/models/round-list-history.model';
import { DetailRoundHistoryView } from "src/app/models/details-round-history.model";
import { HttpHistoryGamesRoundListService } from "src/app/services/http-history-games-round-list.service";

@Component({
    selector: 'app-history-games-round-list',
    templateUrl: './history-games-round-list.component.html',
    styleUrls: ['./history-games-round-list.component.css'],
    providers: [HttpHistoryGamesRoundListService]
})

export class HistoryGamesRoundListComponent implements OnInit {
    model: RoundListHistoryView
    modalModel: DetailRoundHistoryView;
    opened = false;

    constructor(
        private route: ActivatedRoute,
        private service: HttpHistoryGamesRoundListService
    ) { }

    ngOnInit() {
        this.getRoundGames();
    }
    getRoundGames() {
        const id = +this.route.snapshot.paramMap.get('id');
        this.service.httpGetRoundsWithId(id).subscribe((data: RoundListHistoryView) => this.model = data);
    }

    getModal(id: number) {
        if (this.opened) {
            this.opened = false;
        }
        else {
            this.opened = true;
            this.service.httpGetRoundsDetail(id).subscribe((data: DetailRoundHistoryView) => this.modalModel = data);
        }
    }
}
