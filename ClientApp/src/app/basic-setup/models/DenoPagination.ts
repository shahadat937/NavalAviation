import {Deno} from './Deno';

export interface IDenoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Deno[];
}

export class DenoPagination implements IDenoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Deno[] = [];


}
