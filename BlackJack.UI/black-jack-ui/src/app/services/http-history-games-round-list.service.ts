import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpHistoryGamesRoundListService {
    private urlGetRounds = "http://localhost:50219/history/getrounds/";
    private urlGetRoundsDetail = "http://localhost:50219/history/GetRoundsDetail/";

    constructor(private http: HttpClient) { }

    httpGetRoundsWithId(id: number) {
        return this.http.get(this.urlGetRounds + id);
    }

    httpGetRoundsDetail(id: number) {
        return this.http.get(this.urlGetRoundsDetail + id);
    }
}
