import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {
  @Input() style: 'dark' | 'light' = 'dark';
  @Output()
  public searched = new EventEmitter<string>();
  searchIcon = faSearch;
  public value = '';

  constructor(
    private router: Router) { }

  ngOnInit(): void {
  }

  public onSubmit(): void {
    if (this.style === 'light')
      this.searched.emit(this.value);
    else{
      this.router.navigate(['/result']);
    }
  }

}

