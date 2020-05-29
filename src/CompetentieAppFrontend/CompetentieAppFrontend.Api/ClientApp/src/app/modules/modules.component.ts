import {Component, OnInit} from '@angular/core';
import {CompetenceMatrixComponent} from "../competencies/competence-matrix/competence-matrix.component";
import {MatTableDataSource, MatTableModule} from "@angular/material/table";
// @ts-ignore
import mockJson from './../../assets/mock-data/eindcompetentie-mock.json';

@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss']
})
export class ModulesComponent {
  displayedColumns = ['module', 'specialisation', 'period', 'matrix', 'endRequirements'];
  dataSource = new MatTableDataSource(MODULE_DATA);

  constructor() {
  }

  applyFilter($event: KeyboardEvent) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}

export interface ModuleModel {
  specialisation: string[];
  module: string;
  period: number;
  matrix:any;//TODO: use matrix
  endRequirements: string[];
}

const MODULE_DATA: ModuleModel[] = [
  {
    specialisation: ['se', 'bdam'],
    module: 'ISCIRPT',
    period: 1,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['medt', 'fict'],
    module: 'IARCH',
    period: 3,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['se', 'bdam', 'medt', 'fict'],
    module: 'INET',
    period: 4,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['se'],
    module: 'IPSENH',
    period: 2,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['se', 'bdam', 'medt', 'fict'],
    module: 'IRDB',
    period: 6,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['bdam'],
    module: 'IPROV',
    period: 5,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['medt', 'fict'],
    module: 'IARCH',
    period: 3,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['se', 'bdam', 'medt', 'fict'],
    module: 'INET',
    period: 4,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['se'],
    module: 'IPSENH',
    period: 2,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['se', 'bdam', 'medt', 'fict'],
    module: 'IRDB',
    period: 6,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['bdam'],
    module: 'IPROV',
    period: 5,
    matrix: mockJson,
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },

];
