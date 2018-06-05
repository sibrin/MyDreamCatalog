import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientInMemoryWebApiModule, InMemoryWebApiModule } from 'angular-in-memory-web-api';


import { AppComponent } from './app.component';
import { environment } from '../environments/environment.mock';
import { MemoryDb } from './mocks/memorydb';
import { CatalogService } from './services/catalog.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    environment.name === 'mock' ? HttpClientInMemoryWebApiModule.forRoot(MemoryDb) : []
  ],
  providers: [CatalogService],
  bootstrap: [AppComponent]
})
export class AppModule { }
