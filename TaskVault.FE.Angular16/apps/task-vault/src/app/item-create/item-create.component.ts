import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.scss']
})
export class ItemCreateComponent {

  constructor(private dataService: ItemsService) { }

  // TODO: add Typescript interface here
  items: string = "";

  name: string = '';

  onSubmit() {

    const dataToSend = { name: this.name};

    this.dataService.create(dataToSend).subscribe(
      response => {
        console.log('POST request successful:', response);
        this.items = JSON.stringify(response)
      },
      error => {
        console.error('Error in POST request:', error);
        // Handle errors
      }
    );

  }

}
