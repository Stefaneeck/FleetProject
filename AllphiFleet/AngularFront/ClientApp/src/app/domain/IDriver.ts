import { IAddress } from "./IAddress";
import { IFuelcard } from "./IFuelcard";


export interface IDriver {

  id: number;
  name: string;
  firstName: number;
  birthDate: Date;
  socSecNr: number;
  driverLicenseType: number;
  active: boolean;
  address: IAddress;
  fuelCard: IFuelcard;
  email: string;
}
