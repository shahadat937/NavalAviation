export interface MaintenanceSubCategory {
  maintenanceSubCategoryId: number;
  maintenanceCategoryId: number;
  maintenanceTypeId: number;
  totalDaysCount: number;
  subCategoryName: string;
  allowedExtension: string;
  departmentNameId: number;
  remarks: string;
  isActive: boolean;
}
