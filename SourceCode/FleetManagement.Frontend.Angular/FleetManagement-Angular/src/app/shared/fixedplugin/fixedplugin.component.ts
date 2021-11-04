import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'fm-fixedplugin',
  templateUrl: './fixedplugin.component.html',
  styleUrls: ['./fixedplugin.component.css']
})
export class FixedpluginComponent implements OnInit {
  public sidebarColor: string = "white";
  public sidebarActiveColor: string = "danger";
  public state: boolean = true;

  changeSidebarColor(color: string){
    var sidebar = <HTMLElement>document.querySelector('.sidebar');

    this.sidebarColor = color;
    if(sidebar != undefined){
        sidebar.setAttribute('data-color',color);
    }
  }
  changeSidebarActiveColor(color: string){
    var sidebar = <HTMLElement>document.querySelector('.sidebar');
    this.sidebarActiveColor = color;
    if(sidebar != undefined){
        sidebar.setAttribute('data-active-color',color);
    }
  }
  ngOnInit(){
  }
}
