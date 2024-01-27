export interface MaintenanceSubCategory {
  maintenanceSubCategoryId: number;
  maintenanceCategoryId: number;
  maintenanceTypeId: string;
  totalDaysCount: number;
  subCategoryName: string;
  allowedExtension: string;
  departmentNameId: number;
  remarks: string;
  isActive: boolean;
}
