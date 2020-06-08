import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
// @ts-ignore
import auditMock from "./../../../assets/mock-data/audit-log-mock.json"
import {HttpClient} from "@angular/common/http";
import {MatSort, MatSortable} from "@angular/material/sort";
import {ModulePopupComponent} from "../../modules/module-popup/module-popup.component";
import {MatDialog} from "@angular/material/dialog";
import {AuditPopupComponent} from "./audit-popup/audit-popup.component";

@Component({
  selector: 'app-audit-log',
  templateUrl: './audit-log.component.html',
  styleUrls: ['./audit-log.component.scss']
})
export class AuditLogComponent implements OnInit {

  displayedColumns = ['timeStamp', 'infoString'];
  dataSource: MatTableDataSource<any>;
  dbUrl: string = '/api/audit-log';
  auditData: any;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private http: HttpClient, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getDataFromDB();
  }

  getDataFromDB() {
    // this.http.get(this.dbUrl).toPromise().then(data => {
    //   this.auditData = data;
    //   this.injectDataInTable();
    // }).catch(error => console.log(error));


    this.auditData = auditMock;  // this is mockdata
    this.setDataSource();
  }

  setDataSource() {
    this.dataSource = new MatTableDataSource(this.auditData);
    this.sort.sort(({id: 'timeStamp', start: 'desc'}) as MatSortable);
    this.dataSource.sort = this.sort;
  }

  openPopup(auditRowData) {
    this.dialog.open(AuditPopupComponent, {
      data: {auditData: auditRowData}
    });

  }
}
