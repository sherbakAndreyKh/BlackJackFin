import { Component, OnInit, Input } from '@angular/core';
import { DetailRoundHistoryView } from 'src/app/models/details-round-history.model';

@Component({
    selector: 'app-history-round-details-modal',
    templateUrl: './history-round-details-modal.component.html',
    styleUrls: ['./history-round-details-modal.component.css']
})
export class HistoryRoundDetailsModalComponent implements OnInit {
    @Input() model: DetailRoundHistoryView;
    @Input() opened;
    constructor() { }

    ngOnInit() {
    }

    close() {
        this.opened = false
    }

}
