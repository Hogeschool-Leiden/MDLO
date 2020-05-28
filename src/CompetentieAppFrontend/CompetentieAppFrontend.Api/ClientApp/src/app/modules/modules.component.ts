import {Component, OnInit} from '@angular/core';
import {CompetenceMatrixComponent} from "../competencies/competence-matrix/competence-matrix.component";
import {MatTableModule} from "@angular/material/table";


@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss']
})
export class ModulesComponent {
  displayedColumns = ['module', 'specialisation', 'period', 'matrix', 'endRequirements'];
  dataSource = MODULE_DATA;


  constructor() {
  }
}

export interface ModuleModel {
  specialisation: string[];
  module: string;
  period: number;
  matrix: string;//TODO: use matrix
  endRequirements: string[];
}


const MODULE_DATA: ModuleModel[] = [
  {
    specialisation: ['SE', 'BDAM'],
    module: 'ISCIRPT',
    period: 1,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['Interactie Tech', 'forensisch IT'],
    module: 'IARCH',
    period: 3,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['Software Engineering', 'BDAM', 'Interactie Tech', 'forensisch IT'],
    module: 'INET',
    period: 4,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['SE'],
    module: 'IPSENH',
    period: 2,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['Software Engineering', 'BDAM', 'Interactie Tech', 'forensisch IT'],
    module: 'IRDB',
    period: 6,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['BDAM'],
    module: 'IPROV',
    period: 5,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['Interactie Tech', 'forensisch IT'],
    module: 'IARCH',
    period: 3,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['Software Engineering', 'BDAM', 'Interactie Tech', 'forensisch IT'],
    module: 'INET',
    period: 4,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['SE'],
    module: 'IPSENH',
    period: 2,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  }, {
    specialisation: ['Software Engineering', 'BDAM', 'Interactie Tech', 'forensisch IT'],
    module: 'IRDB',
    period: 6,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },
  {
    specialisation: ['BDAM'],
    module: 'IPROV',
    period: 5,
    matrix: 'test',
    endRequirements: ['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.']
  },

];
