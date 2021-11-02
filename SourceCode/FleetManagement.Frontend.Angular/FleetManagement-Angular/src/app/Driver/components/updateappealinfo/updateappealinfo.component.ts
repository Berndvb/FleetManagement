import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'fm-updateappealinfo',
  templateUrl: './updateappealinfo.component.html',
  styleUrls: ['./updateappealinfo.component.css']
})
export class UpdateappealinfoComponent implements OnInit {

  formControl = new FormControl('');

  constructor() { }

  ngOnInit(): void {
  }

  submitted = false;

  onSubmit() { this.submitted = true; }
}
