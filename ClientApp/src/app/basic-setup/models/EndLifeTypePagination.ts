import {EndLifeType} from './EndLifeType';

export interface IEndLifeTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: EndLifeType[];
}

export class EndLifeTypePagination implements IEndLifeTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: EndLifeType[] = [];
}
