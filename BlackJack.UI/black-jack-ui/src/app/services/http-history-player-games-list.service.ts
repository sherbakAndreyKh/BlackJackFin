import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpHistoryPlayerGamesListService {
    urlGetPlayerGames = "http://localhost:50219/history/getgames/";

    constructor(private http: HttpClient) { }

    HttpGetPlayerGames(id: number) {
        return this.http.get(this.urlGetPlayerGames + id);
    }
}
