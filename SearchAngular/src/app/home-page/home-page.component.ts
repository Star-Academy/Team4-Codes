import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  constructor() { }

  @Output() searchEvent = new EventEmitter<string>();

  ngOnInit(): void {
  }

  public async searchWord(word: string) {
    this.searchEvent.toString;
  }

}
