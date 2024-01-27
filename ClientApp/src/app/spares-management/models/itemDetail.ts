export interface ItemDetail {
    itemDetailId: number;
    partNo: string;
    imcNumber: string;
    serialNo:string;
    model:string;
    brand:string;
    nameOfItem:string;
    departmentNameId:number;
    equipmentNameId:number;
    equipmentOrSystemName:string;
    departmentName:string;
    itemCategoryId:number;
    itemCategoryTypeId: number;
    sparesCategoryId:string;
    itemTypeId: number;
    alternatiovePrartNo:string;
    minimumStock:string;
    tradeId: number;
    remarks: string;
    menuPosition:string;
    maintananceState:number;
    calibrationState:number;
    verificationCompletStatus:number;
    isActive: boolean;
   
}