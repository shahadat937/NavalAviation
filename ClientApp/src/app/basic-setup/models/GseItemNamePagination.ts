import {GseItemName} from './GseItemName';

export interface IGseItemNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseItemName[];
}

export class GseItemNamePagination implements IGseItemNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: GseItemName[] = [];


}
