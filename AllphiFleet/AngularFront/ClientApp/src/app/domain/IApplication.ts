import { IVehicle } from "./IVehicle";
import { IDriver } from "./IDriver";

export interface IApplication {

  Id: number;
  applicationDate: Date;
  applicationType: number;
  possibleDates: string;
  applicationStatus: string;
  vehicle: IVehicle;
  driver: IDriver;
}
