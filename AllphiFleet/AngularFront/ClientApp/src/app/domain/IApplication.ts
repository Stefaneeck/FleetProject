import { IVehicle } from "./IVehicle";
import { IDriver } from "./IDriver";

export interface IApplication {

  id: number;
  applicationDate: Date;
  applicationType: number;
  possibleDates: string;
  applicationStatus: string;
  vehicle: IVehicle;
  driver: IDriver;
}
