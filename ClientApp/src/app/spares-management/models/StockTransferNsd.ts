export interface StockTransferNsd {
    stockTransferNsdId: number;
    departmentNameId: number;
    itemStorId: number;
    itemDetailId:number;
    toolsLocationId:number;
    issuedQty:number;
    nsdQty:number;
    availableQty:number;
    transferQty:number;
    demandAuthorityId:number;
    stockAdjustmentDate:Date;
    doc:string;
    completeStatus: number;
    verificationCompletStatus: number;
    status:number;
    remarks: string;
    isActive: boolean;
   
}