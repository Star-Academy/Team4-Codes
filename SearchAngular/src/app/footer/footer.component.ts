import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { HelpComponent } from 'src/app/help/help.component';
import { MatDialogRef } from "@angular/material/dialog";
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  private dialogRef: MatDialogRef<HelpComponent>;

  ngOnInit(): void {
  }
  openDialog() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    this.dialog.open(HelpComponent, dialogConfig);
  }

  close() {
    this.dialogRef.close();
  }


}
