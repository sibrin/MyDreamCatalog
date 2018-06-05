import { Component } from '@angular/core';
import { CatalogService } from './services/catalog.service';
import { Catalog } from './services/models/Catalog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  catalogs: Catalog[] = [];

  constructor(private catalogService: CatalogService) { }

  get(id: number) {
    if (id == null) {
      this.catalogService.getRoot().subscribe(items => this.catalogs = items);
    } else {
      this.catalogService.getChild(id).subscribe(items => this.catalogs = items);
    }
  }
}
