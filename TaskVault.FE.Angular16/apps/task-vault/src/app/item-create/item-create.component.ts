import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.scss'],
})
export class ItemCreateComponent {
  // TODO: add Typescript interface here for all the fields
  name: string = '';
  isLoading: boolean = false;
  constructor(private dataService: ItemsService) {}

  ngOnInit() {
    this.dataService.onListUpdated().subscribe(() => {
      this.isLoading = false;
    });
  }

  onSubmit() {
    this.isLoading = true;
    const dataToSend = { name: this.name };
    this.dataService.create(dataToSend);
  }
}
