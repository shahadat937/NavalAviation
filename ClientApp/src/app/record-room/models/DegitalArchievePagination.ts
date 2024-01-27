import {DegitalArchieve} from './DegitalArchieve';

export interface IDegitalArchievePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DegitalArchieve[];
}

export class DegitalArchievePagination implements IDegitalArchievePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DegitalArchieve[] = [];


}
