import {SailorRank} from './SailorRank';

export interface ISailorRankPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SailorRank[];
}

export class SailorRankPagination implements ISailorRankPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SailorRank[] = [];


}
