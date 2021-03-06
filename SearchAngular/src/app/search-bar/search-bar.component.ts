import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {
  @Input() style: 'homePageStyle' | 'resultPageStyle' = 'homePageStyle';

  @Input() value;

  @Output()
  public searched = new EventEmitter<string>();
  searchIcon = faSearch;

  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }


  async ngOnInit(): Promise<void> {
  }

  public onSubmit(): void {

      this.searched.emit(this.value);

      this.router.navigate(['/result', this.value]);
    
  }

}

