import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.scss'],
})
export class ItemCreateComponent {
  // TODO: add Typescript interface here
  name: string = '';
  constructor(private dataService: ItemsService) {}

  onSubmit() {
    const dataToSend = { name: this.name };

    this.dataService.create(dataToSend);
  }
}
