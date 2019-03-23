import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-iconlist',
  templateUrl: './iconlist.component.html',
  styleUrls: ['./iconlist.component.scss']
})
export class IconlistComponent implements OnInit {

  model: any;
  flag = false;
  display=false;
  allcards:any;

  colorArray = [[{ 'color': '#FFFFFF', 'name': 'White' },
  { 'color': '#E57373', 'name': 'Red' },
  { 'color': '#FF9100', 'name': 'Orange' },
  { 'color': '#FFEB3B', 'name': 'Yellow' }],

  [{ 'color': '#CCFF90', 'name': 'Green' },
  { 'color': '#84FFFF', 'name': 'Teal' },
  { 'color': '#B3E5FC', 'name': 'Blue' },
  { 'color': '#82B1FF', 'name': 'Darkblue' }],

  [{ 'color': '#B388FF', 'name': 'Purple' },
  { 'color': '#E1BEE7', 'name': 'Pink' },
  { 'color': '#A1887F', 'name': 'Brown' },
  { 'color': '#F5F5F5', 'name': 'Gray' }

  ]]

  constructor() { }

  ngOnInit() {
  }

}
