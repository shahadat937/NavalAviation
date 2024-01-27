import {Rank} from './rank';

export interface IRankPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Rank[];
}

export class RankPagination implements IRankPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Rank[] = [];


}
