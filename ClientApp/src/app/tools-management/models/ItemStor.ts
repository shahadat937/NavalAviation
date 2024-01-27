export interface ItemStor {
    itemStorId: number;
    acceptanceId: number;
    toolsTypeId:number;
    toolsType:string;
    toolsLocation:string;
    toolsBoxName:string;
    toolsLocationId:number;
    toolsBoxNameId:number;
    calibrationDate:Date;
    nextCalibrationDate:Date;
    procurementId: number;
    demandId:number;
    denoId: number;
    departmentNameId: number;
    itemCategoryId:number;
    sparesCategoryId:number;
    conditionOfItemId:number;
    lifeLimitItemId:number;
    serviceLifeTypeId:number;
    endLifeTypeId: number;
    departmentName:string;
    partNo:string;
    nameOfItem:string;
    deno:string;
    sparesCategory:string;
    condition:string;
    lifeLimitItem:string;
    acctStoreId: number;
    overhaulingTypeId:number;
    retirementTypeId: number;
    itemDetailId:number;
    itemSerNo:string;
    icmNo:string;
    oldPrice:string;
    shelfLife:string;
    endShalfLife:string;
    warrantyStartDate:Date;
    warrantyEndDate:Date;
    itemReceivedDate:Date;
    totalReceivedQty:number;
    availableQty:number;
    issuedQty:number;
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
    verificationCompletStatus:number;
    retirmentLife:string;
    remarks:string;
    arcDoc:string;
    cofcDoc:string;
    otherDoc:string;
    oemDoc:string;
    status:string;
    isActive: boolean;
    issueQty:string;
    permanentQty:number;
    tyQty:number,
    repairQty:number,
    surveyQty:number,
    maintenanceQty:number,
    aircraftFittedQty:number,
    calibrationQty:number,
    isRefundable: boolean;
    model:string,
    brand:string,
}