import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpHistoryGamesRoundListService {
    urlGetRounds = "http://localhost:50219/history/getrounds/";
    urlGetRoundsDetail = "http://localhost:50219/history/GetRoundsDetail/";

    constructor(private http: HttpClient) { }

    HttpGetRoundsWithId(id: number) {
        return this.http.get(this.urlGetRounds + id);
    }

    HttpGetRoundsDetail(id: number) {
        return this.http.get(this.urlGetRoundsDetail + id);
    }
}
