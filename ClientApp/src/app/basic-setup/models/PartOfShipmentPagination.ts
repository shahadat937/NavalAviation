import {PartOfShipment} from './PartOfShipment';

export interface IPartOfShipmentPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PartOfShipment[];
}

export class PartOfShipmentPagination implements IPartOfShipmentPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PartOfShipment[] = [];


}
