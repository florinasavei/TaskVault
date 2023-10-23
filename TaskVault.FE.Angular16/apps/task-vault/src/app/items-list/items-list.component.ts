import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';
import { Item } from '../models/item';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.scss']
})
export class ItemsListComponent {

  // TODO: add Typescript interface here
  items: Item[] = [];

  constructor(private dataService: ItemsService) { }

  ngOnInit() {
    this.refreshList();
    this.dataService.onListUpdated().subscribe(() => {
      this.refreshList();
    });
  }

  refreshList() {
    this.dataService.list().subscribe((data) => {
      this.items = data as Item[];
    });
  }

}
