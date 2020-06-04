import {Component, HostListener, OnInit, ViewChild} from '@angular/core';
import {CompetenceMatrixComponent} from "../competencies/competence-matrix/competence-matrix.component";
import {MatTableDataSource, MatTableModule} from "@angular/material/table";
// @ts-ignore
import moduleMock from "./../../assets/mock-data/modules-mock.json"
import {MatSort} from "@angular/material/sort";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss']
})
export class ModulesComponent implements OnInit {
  displayedColumns = ['module', 'specialisation', 'period', 'matrix', 'endRequirements'];
  dataSource = new MatTableDataSource(MODULE_DATA);
  pageWidthInPixels;
  columnRemoveName: string = 'endRequirements';
  fullColumnSize: number = 5;
  showListUnderMatrix: boolean = true;
  moduleData;
  dbUrl: string = '/api/modules';

  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.clearModuleData();
    this.getDataFromDB();
    this.onPageResize();
    this.dataSource.sort = this.sort;
  }

  @HostListener('window:resize', ['$event'])
  onPageResize() {
    this.pageWidthInPixels = window.innerWidth;
    this.resizeTableToFitScreen();
  }

  resizeTableToFitScreen() {
    if (this.isScreenToSmallToFitTable()) {
      this.removeColumn();
      this.addListUnderMatrix();
    } else {
      this.addColumn();
      this.removeListUnderMatrix();
    }
  }

  private removeColumn() {
    if (this.displayedColumns.length >= this.fullColumnSize) {
      this.displayedColumns.splice(this.displayedColumns.length - 1);
    }
  }

  private addColumn() {
    if (this.displayedColumns.length ! < this.fullColumnSize) {
      this.displayedColumns.push(this.columnRemoveName);
    }
  }

  private addListUnderMatrix() {
    this.showListUnderMatrix = true;
  }

  private removeListUnderMatrix() {
    this.showListUnderMatrix = false;
  }

  isScreenToSmallToFitTable() {
    return this.pageWidthInPixels < 1155;
  }

  applyFilter($event: KeyboardEvent) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.setColumnsToFilter();
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  setColumnsToFilter() {
    //specifies what column the filter looks at.
    this.dataSource.filterPredicate = function (data, filter: string): boolean {
      return data.specialisation.includes(filter) || data.module.toLowerCase().includes(filter) ||
        data.period.toString().includes(filter);
    }
  }

  getDataFromDB() {
    //DBdata
    this.http.get(this.dbUrl).toPromise().then(data =>{
      this.moduleData = data;
      this.injectDataInTable();
    });

    // //mockdata
    // this.moduleData = moduleMock;
    // this.injectDataInTable();
  }

  injectDataInTable() {
    for (let i = 0; i < this.moduleData.length; i++) {
      MODULE_DATA.push(
        {
          specialisation: this.moduleData[i].specialisaties,
          module: this.moduleData[i].moduleCode,
          period: this.moduleData[i].perioden,
          matrix: this.moduleData[i].matrix,
          endRequirements: this.moduleData[i].eindeisen
        }
      );
    }
  }

  clearModuleData() {
    MODULE_DATA.length = 0;
  }
}

export interface ModuleModel {
  specialisation: string[];
  module: string;
  period: number[];
  matrix: any;//TODO: use matrix
  endRequirements: string[];
}

let MODULE_DATA: ModuleModel[] = [];
