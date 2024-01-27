import {SourceOfSupply} from './SourceOfSupply';

export interface ISourceOfSupplyPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SourceOfSupply[];
}

export class SourceOfSupplyPagination implements ISourceOfSupplyPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SourceOfSupply[] = [];


}
