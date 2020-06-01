import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'moduleSanitize'
})
export class ModuleSanitizePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
