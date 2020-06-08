import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
// @ts-ignore
import auditMock from "./../../../assets/mock-data/audit-log-mock.json"
import {HttpClient} from "@angular/common/http";
import {MatSort, MatSortable} from "@angular/material/sort";

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

  constructor(private http: HttpClient) {
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
    this.sort.sort(({ id: 'timeStamp', start: 'desc'}) as MatSortable);
    this.dataSource.sort = this.sort;
  }

}
