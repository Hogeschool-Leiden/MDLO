import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';


@Component({
  selector: 'app-competence-matrix',
  templateUrl: './competence-matrix.component.html',
  styleUrls: ['./competence-matrix.component.css']
})
export class CompetenceMatrixComponent implements OnInit, OnChanges {

  @Input() year: number;
  @Input() period: number;
  @Input() specialisation: string;
  @Input() competenceMatrix;

  displayMatrixOffset: number = 1;
  showMatrix: boolean = false;
  displayeMatrix: string[][] = [
    [null, null, null, null, null, null],
    [null, null, null, null, null, null],
    [null, null, null, null, null, null],
    [null, null, null, null, null, null],
    [null, null, null, null, null, null],
    [null, null, null, null, null, null]
  ];

  constructor() {
  }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    this.setDisplayMatrix();
  }

  private setDisplayMatrix() {
    if (this.competenceMatrix !== undefined) {
      this.showMatrix = true;
      this.setHeaders();
      this.setBody();
    }
  }

  private setHeaders() {
    this.setActivityHeaders();
    this.setArchitectureHeaders();
  }

  private setActivityHeaders() {
    for (let i = 0; i < this.displayeMatrix.length - 1; i++) {
      this.displayeMatrix[i + 1][0] = this.competenceMatrix.ArchitectuurLaagNamen[i];
    }
  }

  private setArchitectureHeaders() {
    for (let i = 0; i < this.displayeMatrix[0].length - 1; i++) {
      this.displayeMatrix[0][i + 1] = this.competenceMatrix.ActiviteitNamen[i];
    }
  }

  private setBody() {
    for (let y = 0; y < this.competenceMatrix.Matrix.length; y++) {
      for (let x = 0; x < this.competenceMatrix.Matrix[y].length; x++) {
        if (this.competenceMatrix.Matrix[y][x] != null) {
          this.setCellInfo(this.competenceMatrix.Matrix[y][x], y, x);
        }
      }
    }
  }

  private setCellInfo(matrixElement, y, x) {
    y += this.displayMatrixOffset;
    x += this.displayMatrixOffset;
    this.displayeMatrix[y][x] = this.getBiggestCompetencePoint(matrixElement).toString();
  }

  private getBiggestCompetencePoint(matrixElement) {
    let biggestCompetencePoint = 0;
    for (let i = 0; i < matrixElement.Modules.length; i++) {
      if (biggestCompetencePoint < matrixElement.Modules[i].Competenties) {
        biggestCompetencePoint = matrixElement.Modules[i].Competenties;
      }
    }
    return biggestCompetencePoint;
  }

  getCellColor(stringValue: string) {
    let value = Number(stringValue);

    switch (value) {
      case 1:
        return '#88BFFF'
      case 2:
        return '#2648FF'
      case 3:
        return '#0000CA'
      case 0:
        return '#FFF'
    }
  }
}
