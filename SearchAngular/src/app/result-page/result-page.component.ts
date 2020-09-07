import { Component, OnInit } from '@angular/core';
import { ResultService } from 'src/app/services/result.service';

@Component({
  selector: 'app-result-page',
  templateUrl: './result-page.component.html',
  styleUrls: ['./result-page.component.scss']
})
export class ResultPageComponent implements OnInit {
  public results: string[];
  constructor(private service: ResultService) { }

  ngOnInit(): void {
    // this.results = this.service.getResults('hello');
  }

}
