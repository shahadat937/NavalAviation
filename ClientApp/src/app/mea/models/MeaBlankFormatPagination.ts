import {MeaBlankFormat} from './MeaBlankFormat';

export interface IMeaBlankFormatPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MeaBlankFormat[];
}

export class MeaBlankFormatPagination implements IMeaBlankFormatPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MeaBlankFormat[] = [];


}
