import {AcStatus} from './AcStatus';

export interface IAcStatusPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AcStatus[];
}

export class AcStatusPagination implements IAcStatusPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AcStatus[] = [];


}
