import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpHistoryPlayerListService {
    private urlGet = 'http://localhost:50219/history/index';

    constructor(private http: HttpClient) { }

    httpGetPlayerList() {
        return this.http.get(this.urlGet);
    }
}







