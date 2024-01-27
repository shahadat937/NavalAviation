import {ConditionOfItem} from './ConditionOfItem';

export interface IConditionOfItemPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ConditionOfItem[];
}

export class ConditionOfItemPagination implements IConditionOfItemPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ConditionOfItem[] = [];


}
