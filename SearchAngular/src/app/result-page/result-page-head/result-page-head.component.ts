import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {ResultPageComponent} from '../result-page.component';

@Component({
  selector: 'app-result-page-head',
  templateUrl: './result-page-head.component.html',
  styleUrls: ['./result-page-head.component.scss']
})
export class ResultPageHeadComponent implements OnInit {

  @Output() searchEvent = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
  }
  searchWord(word:string): void {
    this.searchEvent.next(word);
  }
}