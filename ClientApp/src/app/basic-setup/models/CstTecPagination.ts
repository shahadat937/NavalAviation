import {CstTec} from './CstTec';

export interface ICstTecPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CstTec[];
}

export class CstTecPagination implements ICstTecPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CstTec[] = [];


}
