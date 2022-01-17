import { IVehicle } from "./IVehicle";
import { IDriver } from "./IDriver";

export interface IApplication {

  id: number;
  applicationDate: Date;
  applicationType: number;
  possibleDate1: Date;
  possibleDate2: Date;
  applicationStatus: string;
  driver: IDriver;
  vehicle: IVehicle;
}
