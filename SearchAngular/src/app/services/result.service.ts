import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable()
export class ResultService {
    constructor(private http: HttpClient) {

    }
    public async getResults(searchKey: string): Promise<string[]> {
        return new Promise<string[]>((resolve) => {
            this.http.post('https://localhost:5001/search', { words: searchKey }).subscribe((result: string[]) => {
                resolve(result);
            });
        });
    }
}