import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpHistoryPlayerGamesListService {
    private urlGetPlayerGames = "/history/getgames/";

    constructor(private http: HttpClient) { }

    httpGetPlayerGames(id: number) {
        return this.http.get(this.urlGetPlayerGames + id);
    }
}
