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

  async ngOnInit(): Promise<void> {
  }

  public async searchWord(word: string) {
    this.results = await this.service.getResults(word);
  }
}
