import {DailyAirworthinessFromCategory} from './DailyAirworthinessFromCategory';

export interface IDailyAirworthinessFromCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DailyAirworthinessFromCategory[];
}

export class DailyAirworthinessFromCategoryPagination implements IDailyAirworthinessFromCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DailyAirworthinessFromCategory[] = [];


}
