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
  displayeMatrix: any[][] = [
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
      this.resetMatrix();
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
      this.displayeMatrix[i + 1][0] = this.competenceMatrix.architectuurLaagNamen[i];
    }
  }

  private setArchitectureHeaders() {
    for (let i = 0; i < this.displayeMatrix[0].length - 1; i++) {
      this.displayeMatrix[0][i + 1] = this.competenceMatrix.activiteitNamen[i];
    }
  }

  private setBody() {
    for (let y = 0; y < this.competenceMatrix.matrix.length; y++) {
      for (let x = 0; x < this.competenceMatrix.matrix[y].length; x++) {
        if (this.competenceMatrix.matrix[y][x] != null) {
          console.log(this.competenceMatrix.matrix[y][x])
          this.setCellInfo(this.competenceMatrix.matrix[y][x], y, x);
        }
      }
    }
  }

  private setCellInfo(matrixElement, y, x) {
    y += this.displayMatrixOffset;
    x += this.displayMatrixOffset;
    this.displayeMatrix[y][x] = matrixElement.niveau;
  }

  private resetMatrix(){
    for (let i = 0; i < this.displayeMatrix.length;i++){
      for (let j = 0; j < this.displayeMatrix[i].length;j++){
        this.displayeMatrix[i][j] = null;
      }
    }
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
