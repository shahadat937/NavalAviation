import {Acceptance} from './Acceptance';

export interface IAcceptancePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Acceptance[];
}

export class AcceptancePagination implements IAcceptancePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Acceptance[] = [];


}
