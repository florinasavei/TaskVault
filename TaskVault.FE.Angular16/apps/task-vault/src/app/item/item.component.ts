import { Component, Input } from '@angular/core';
import { Item } from '../models/item';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent {

  @Input() item: Item = {
    id: 0,
    name: "",
    priority: "",
    progress: 0,
    details: ""
  };


}
