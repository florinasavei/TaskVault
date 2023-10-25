import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';
import { Item } from '../models/item';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.scss'],
})
export class ItemsListComponent {
  items: Item[] | undefined = undefined;
  isLoadingData: boolean = true;

  pageSize: number = 5;
  itemsLength: number = 0;
  get numberOfPages(): number {
    return Math.ceil(this.itemsLength / this.pageSize);
  }
  constructor(private dataService: ItemsService) {}

  ngOnInit() {
    this.loadData(0, 1);
    this.dataService.onListUpdated().subscribe(() => {
      this.loadData(0, 1);
    });
  }

  loadData(first: number, pageSize: number) {
    this.isLoadingData = true;
    const index = first;
    //TODO: find a smarter way to not count every time
    this.dataService.count().subscribe((count: any) => {
      const itemsLength = count as number;
      this.itemsLength = itemsLength;
      const safePageSize = itemsLength < pageSize ? itemsLength : this.pageSize;
      this.dataService.list(index, safePageSize).subscribe((items: any) => {
        this.items = items as Item[];
        this.isLoadingData = false;
      });
    });
  }
}
