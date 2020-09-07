import { Component, OnInit } from '@angular/core';
import {  MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-help',
  templateUrl: './help.component.html',
  styleUrls: ['./help.component.scss']
})
export class HelpComponent implements OnInit {
  constructor(private dialogRef: MatDialogRef<HelpComponent>) { }

  ngOnInit(): void {
  }

  clickClose() {
    this.dialogRef.close();
  }

}
