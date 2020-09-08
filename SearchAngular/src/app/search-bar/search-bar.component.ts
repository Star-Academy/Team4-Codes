import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {
  @Input() style : 'dark' | 'light' = 'dark';
  @Output()
  public searched = new EventEmitter<string>();
  searchIcon = faSearch;
  public value;

  constructor() { }

  ngOnInit(): void {
  }

  public onSubmit() : void{
    this.searched.emit(this.value);
  }

}

