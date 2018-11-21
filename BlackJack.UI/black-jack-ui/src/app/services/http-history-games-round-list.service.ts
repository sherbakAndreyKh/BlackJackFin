import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpHistoryGamesRoundListService {
    private urlGetRounds = "/history/getrounds/";
    private urlGetRoundsDetail = "/history/GetRoundsDetail/";

    constructor(private http: HttpClient) { }

    httpGetRoundsWithId(id: number) {
        return this.http.get(this.urlGetRounds + id);
    }

    httpGetRoundsDetail(id: number) {
        return this.http.get(this.urlGetRoundsDetail + id);
    }
}
