import {OverhaulingType} from './OverhaulingType';

export interface IOverhaulingTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: OverhaulingType[];
}

export class OverhaulingTypePagination implements IOverhaulingTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: OverhaulingType[] = [];


}
