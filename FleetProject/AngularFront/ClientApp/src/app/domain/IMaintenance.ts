export interface IMaintenance {

  id: number;
  maintenanceDate: Date;
  price: number;
  dealerName: string;
  //invoiceId: number;
  invoiceDocumentPath: string;
  vehicleId: number;

}
