import {DailyAirworthinessFrom} from './DailyAirworthinessFrom';

export interface IDailyAirworthinessFromPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DailyAirworthinessFrom[];
}

export class DailyAirworthinessFromPagination implements IDailyAirworthinessFromPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DailyAirworthinessFrom[] = [];


}
