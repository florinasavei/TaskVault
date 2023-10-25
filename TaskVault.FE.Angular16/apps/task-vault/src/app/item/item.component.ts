import { Component, Input } from '@angular/core';
import { Item } from '../models/item';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss'],
})
export class ItemComponent {
  areDetailsLoading: boolean = false;

  constructor(private dataService: ItemsService) {}

  getDetails() {
    this.areDetailsLoading = true;
    this.dataService.summary(this.item.id).subscribe((data) => {
      this.item = data as Item;
      this.areDetailsLoading = false;
    });
  }

  delete() {
    this.dataService.delete(this.item.id)
  }


  @Input() item: Item = {
    id: 0,
    name: '',
    priority: '',
    progress: 0,
    details: '',
  };
}
