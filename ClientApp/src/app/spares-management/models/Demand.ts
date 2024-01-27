export interface Demand {
 demandId: number,
 authorityId: number,
 tradeId:number,
 itemDetailId: number,
 partNo:string,
 itemName:string;
 demandType:string;
 conditionOfItem:string;
 deno:string;
 occasionOfDemand:string;
 fiscalYear:string;
 authority:string;
 tread:string;
 itemCategory:string;
 demandStatus:string;
 manufacture:string;
 supplierId:number,
 manufactureId:number,
 denoId: number,
 fiscalYearId: number,
 itemCategoryId:number,
 itemTypeId: number,
 sparesCategoryId: number,
 occasionOfDemandId: number,
 demandAuthorityId: number,
 demandStatusId:number,
 demandTypeId: number,
 demandDocId: number,
 conditionOfItemId: number,
 departmentNameId: number,
 departmentName:string;
 demandCompleteStatusId: number,
 verificationCompletStatus: number,
 demandQty: string,
 demandLetterNo: string,
 specDoc:string;
 demandNo:string;
 demandDate: Date,
 letterOuterNo: string,
 refPrice: string,
 refPoNo: string,
 remarks: string,
 oldPrice: string,
 oldRefNo: string,
 manufactureAddress: string,
 status: number,
 menuPosition: number,
 isActive: boolean,

}