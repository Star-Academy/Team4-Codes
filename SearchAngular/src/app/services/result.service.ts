import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable()
export class ResultService {
    constructor(private http: HttpClient) {

    }
    public getResults(searchKey: string): string[] {
        this.http.post('http://localhost:5000/search', { words: searchKey }).subscribe((result: string[]) =>
            console.log(result)
        );
        return [];
    }
}