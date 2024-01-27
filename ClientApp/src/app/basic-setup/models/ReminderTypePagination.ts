import {ReminderType} from './ReminderType';

export interface IReminderTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ReminderType[];
}

export class ReminderTypePagination implements IReminderTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ReminderType[] = [];


}
