import { Component } from '@angular/core';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.scss']
})
export class ItemsListComponent {

  // TODO: add Typescript interface here
  items: string = "";

  constructor(private dataService: ItemsService) { }

  ngOnInit(): void {
    // Initialization logic goes here
    this.dataService.list().subscribe(
      response => {
        this.items = JSON.stringify(response)
      },
      error => {
        console.error('Error in POST request:', error);
        // Handle errors
      }
    );
  }

}
