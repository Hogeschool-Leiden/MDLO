import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';

@Component({
  selector: 'app-competence-matrix',
  templateUrl: './competence-matrix.component.html',
  styleUrls: ['./competence-matrix.component.scss']
})
export class CompetenceMatrixComponent implements OnInit, OnChanges {

  @Input() specialisation: string;
  @Input() competenceMatrix;

  displayMatrixOffset: number = 1;
  showMatrix: boolean = false;
  displayMatrix: any[][] = [
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
    this.setupDisplayMatrix();
  }

  setupDisplayMatrix() {
    if (this.competenceMatrix !== undefined) {
      this.resetMatrix();
      this.showMatrixOnScreen();
      this.setHeaders();
      this.setBody();
    }
  }

  resetMatrix() {
    for (let i = 0; i < this.displayMatrix.length; i++) {
      for (let j = 0; j < this.displayMatrix[i].length; j++) {
        this.displayMatrix[i][j] = null;
      }
    }
  }

  private showMatrixOnScreen(){
    this.showMatrix = true;

  }

  private setHeaders() {
    this.setActivityHeaders();
    this.setArchitectureHeaders();
  }

  private setActivityHeaders() {
    for (let i = 0; i < this.displayMatrix.length - 1; i++) {
      this.displayMatrix[i + 1][0] = this.competenceMatrix.xHeaders[i];
    }
  }

  private setArchitectureHeaders() {
    for (let i = 0; i < this.displayMatrix[0].length - 1; i++) {
      this.displayMatrix[0][i + 1] = this.competenceMatrix.yHeaders[i];
    }
  }

  private setBody() {
    for (let y = 0; y < this.competenceMatrix.cells.length; y++) {
      for (let x = 0; x < this.competenceMatrix.cells[y].length; x++) {
        if (this.competenceMatrix.cells[y][x] != null) {
          this.setCellInfo(this.competenceMatrix.cells[y][x], y, x);
        }
      }
    }
  }

  private setCellInfo(matrixElement, y, x) {
    y += this.displayMatrixOffset;
    x += this.displayMatrixOffset;
    this.displayMatrix[y][x] = CompetenceMatrixComponent.getCorrectCompetenceValue(matrixElement);
  }

  private static getCorrectCompetenceValue(matrixElement) {
    if (matrixElement.value.niveau === undefined) {
      return matrixElement.value;
    }
    return matrixElement.value.niveau;
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
