import {Component, HostListener, OnInit, ViewChild, Inject} from '@angular/core';
import {CompetenceMatrixComponent} from "../competencies/competence-matrix/competence-matrix.component";
import {MatTableDataSource, MatTableModule} from "@angular/material/table";
import {MatSort} from "@angular/material/sort";
import {HttpClient} from "@angular/common/http";
// @ts-ignore
import moduleMock from "./../../assets/mock-data/modules-mock.json"
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from "@angular/material/dialog";
import {ModulePopupComponent} from "./module-popup/module-popup.component";


@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss']
})
export class ModulesComponent implements OnInit {
  displayedColumns = ['module', 'specialisation', 'period', 'matrix', 'endRequirements'];
  dataSource: MatTableDataSource<any>;
  pageWidthInPixels;
  columnRemoveName: string = 'endRequirements';
  fullColumnSize: number = 5;
  showEndRequirementsUnderMatrix: boolean = true;
  moduleData;
  MODULE_DATA: ModuleModel[] = [];
  dbUrl: string = '/api/modules';

  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private http: HttpClient, public dialog: MatDialog) {
  }

  ngOnInit() {
    this.clearModuleData();
    this.getDataFromDB();
    this.onPageResize();
    this.setDataSource();
  }

  clearModuleData() {
    this.MODULE_DATA.length = 0;

  }

  getDataFromDB() {
    this.http.get(this.dbUrl).toPromise().then(data => {
      this.moduleData = data;
      this.injectDataInTable();
    }).catch(error => console.log(error));

    // this.moduleData = moduleMock;  // this is mockdata
    // this.injectDataInTable();
  }

  injectDataInTable() {
    for (let i = 0; i < this.moduleData.length; i++) {
      this.MODULE_DATA.push(
        {
          specialisation: this.moduleData[i].specialisaties,
          module: this.moduleData[i].moduleCode,
          period: this.moduleData[i].perioden,
          matrix: this.moduleData[i].matrix,
          endRequirements: this.moduleData[i].eindeisen,
          auditLog: this.moduleData[i].auditLogObject
        }
      );
    }
  }

  @HostListener('window:resize', ['$event'])
  onPageResize() {
    this.pageWidthInPixels = window.innerWidth;
    this.resizeTableToFitScreen();
  }

  resizeTableToFitScreen() {
    if (this.isScreenTooSmallToFitTable()) {
      this.removeColumn();
      this.displayEndRequirementsUnderMatrix();
    } else {
      this.addColumn();
      this.removeEndRequirementsUnderMatrix();
    }
  }

  isScreenTooSmallToFitTable() {
    return this.pageWidthInPixels < 1155;
  }

  private removeColumn() {
    if (this.displayedColumns.length >= this.fullColumnSize) {
      this.displayedColumns.splice(this.displayedColumns.length - 1);
    }
  }

  private displayEndRequirementsUnderMatrix() {
    this.showEndRequirementsUnderMatrix = true;
  }

  private addColumn() {
    if (this.displayedColumns.length ! < this.fullColumnSize) {
      this.displayedColumns.push(this.columnRemoveName);
    }
  }

  private removeEndRequirementsUnderMatrix() {
    this.showEndRequirementsUnderMatrix = false;
  }

  setDataSource() {
    this.dataSource = new MatTableDataSource(this.MODULE_DATA);
    this.dataSource.sort = this.sort;
  }

  applyFilter(event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.specifyWhatColumnsToFilter();
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  specifyWhatColumnsToFilter() {
    this.dataSource.filterPredicate = function (data, filter: string): boolean {
      return data.specialisation.includes(filter) || data.module.toLowerCase().includes(filter) ||
        data.period.toString().includes(filter);
    }
  }

  openPopup(moduleRowData) {
    this.dialog.open(ModulePopupComponent, {
      data: {moduleData: moduleRowData}
    });
  }
}

export interface ModuleModel {
  specialisation: string[];
  module: string;
  period: number[];
  matrix: any;
  endRequirements: string[];
  auditLog: auditModel[];
}

export interface auditModel {
  timeStamp: string;
  information: string;
}
