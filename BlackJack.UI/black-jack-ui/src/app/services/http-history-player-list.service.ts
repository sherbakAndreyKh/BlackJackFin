import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpHistoryPlayerListService {
    private urlGet = 'history/index';

    constructor(private http: HttpClient) { }

    httpGetPlayerList() {
        return this.http.get(this.urlGet);
    }
}







