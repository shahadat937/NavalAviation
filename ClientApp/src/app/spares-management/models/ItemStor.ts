export interface ItemStor {
    itemStorId: number;
    acceptanceId: number;
    procurementId: number;
    demandId:number;
    denoId: number;
    departmentNameId: number;
    departmentName:string;
    partNo:string;
    nameOfItem:string;
    deno:string;
    sparesCategory:string;
    condition:string;
    toolsLocation:string;
    lifeLimitItem:string;
    itemCategoryId:number;
    sparesCategoryId:number;
    conditionOfItemId:number;
    lifeLimitItemId:number;
    toolsLocationId:number;
    serviceLifeTypeId:number;
    endLifeTypeId: number;
    acctStoreId: number;
    overhaulingTypeId:number;
    retirementTypeId: number;
    itemDetailId:number;
    itemSerNo:string;
    icmNo:string;
    shelfLife:string;
    endShalfLife:string;
    warrantyStartDate:Date;
    warrantyEndDate:Date;
    itemReceivedDate:Date;
    totalReceivedQty:number;
    availableQty:number;
    issuedQty:number;
    oldPrice:string;
    //nsdQty:number;
    demandQty:string;
    demandDate:Date;
    manufacturingDate:Date;
    letterOuterNo:string;
    refPoNo:string;
    tenderNumber:string;
    dateOfTenderFloat:Date;
    tenderopeningDate:Date;
    tenderPublishDate:Date;
    tenderNotice:string;
    location:string;
    serviceLife:string;
    endLifeTime:string;
    accessories:string;
    stockRegisterPageNo:string;
    retirmentLife:string;
    remarks:string;
    arcDoc:string;
    cofcDoc:string;
    otherDoc:string;
    permanentQty:number;
    tyQty:number,
    repairQty:number,
    surveyQty:number,
    verificationCompletStatus: number;
    maintenanceQty:number,
    aircraftFittedQty:number,
    oemDoc:string;
    status:string;
    isActive: boolean;
    issueQty:string;
    isRefundable: boolean;
    calibrationQty:number;
    model:string,
    brand:string,
}