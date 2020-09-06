import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { FooterComponent } from './footer/footer.component';
import { ResultPageComponent } from './result-page/result-page.component';
import { HomePageHeadComponent } from './home-page/home-page-head/home-page-head.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { SearchResultsComponent } from './result-page/search-results/search-results.component';
import { ResultPageHeadComponent } from './result-page/result-page-head/result-page-head.component';
import { ResultPageLogoComponent } from './result-page/result-page-head/result-page-logo/result-page-logo.component';
import { HelpComponent } from './help/help.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    FooterComponent,
    ResultPageComponent,
    HomePageHeadComponent,
    SearchBarComponent,
    SearchResultsComponent,
    ResultPageHeadComponent,
    ResultPageLogoComponent,
    HelpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
    constructor() {
      library.add(faSearch);
    }
}
