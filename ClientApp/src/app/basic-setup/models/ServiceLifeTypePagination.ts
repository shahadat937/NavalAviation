import {ServiceLifeType} from './ServiceLifeType';

export interface IServiceLifeTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ServiceLifeType[];
}

export class ServiceLifeTypePagination implements IServiceLifeTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ServiceLifeType[] = [];
}
