export interface ItemDetail {
    itemDetailId: number;
    departmentNameId:number;
    itemCategoryId:number;
    partNo: string;
    imcNumber: string;
    serialNo:string;
    model:string;
    brand:string;
    nameOfItem:string;
    itemCategoryTypeId: number;
    sparesCategoryId:string;
    equipmentNameId:number;
    equipmentOrSystemName:string,
    itemTypeId: number;
    alternatiovePrartNo:string;
    minimumStock:string;
    tradeId: number;
    maintananceState:number;
    calibrationState:number;
    verificationCompletStatus:number,
    remarks: string;
    menuPosition:string;
    isActive: boolean;
   
}