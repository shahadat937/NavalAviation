import {EquipmentName} from './EquipmentName';

export interface IEquipmentNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: EquipmentName[];
}

export class EquipmentNamePagination implements IEquipmentNamePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: EquipmentName[] = [];


}
