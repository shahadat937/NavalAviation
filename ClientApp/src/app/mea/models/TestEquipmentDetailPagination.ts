import {TestEquipmentDetail} from './TestEquipmentDetail';

export interface ITestEquipmentDetailPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: TestEquipmentDetail[];
}

export class TestEquipmentDetailPagination implements ITestEquipmentDetailPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: TestEquipmentDetail[] = [];


}
