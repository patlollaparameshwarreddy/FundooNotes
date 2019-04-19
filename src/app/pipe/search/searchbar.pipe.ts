import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchbar'
})
export class SearchbarPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if(!value)  return null;
   if(!args) return value;

   return value.filter(Array => Array.title.toLowerCase().indexOf(args.toLowerCase()) !==-1 || Array.takeANote.toLowerCase().toLowerCase().indexOf(args.toLowerCase()) !==-1)
  }

}
