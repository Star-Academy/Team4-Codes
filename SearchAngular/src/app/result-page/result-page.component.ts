import { Component, OnInit } from '@angular/core';
import { ResultService } from 'src/app/services/result.service';
import { ActivatedRoute } from '@angular/router'; 

@Component({
  selector: 'app-result-page',
  templateUrl: './result-page.component.html',
  styleUrls: ['./result-page.component.scss']
})
export class ResultPageComponent implements OnInit {
  public results: string[];

  public words: string;

  constructor(private service: ResultService, private activatedRoute: ActivatedRoute) { }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.paramMap.subscribe(params => {
      this.words = params.get('words');
      if(this.words){
        this.searchWord(this.words);
      }
    });
  }

  public async searchWord(word: string) {
    this.results = await this.service.getResults(word);
  }
}
