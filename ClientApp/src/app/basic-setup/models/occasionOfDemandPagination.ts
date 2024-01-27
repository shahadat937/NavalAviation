import {OccasionOfDemand} from './occasionOfDemand';

export interface IOccasionOfDemandPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: OccasionOfDemand[];
}

export class OccasionOfDemandPagination implements IOccasionOfDemandPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: OccasionOfDemand[] = [];


}
