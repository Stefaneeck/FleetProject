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
  
  /*
   *
  id: number;
  naam: string;
  voornaam: number;
  geboorteDatum: Date;
  rijksRegisterNummer: number;
  typeRijbewijs: number;
  actief: boolean;
  adres: IAddress;
  tankkaart: ITankkaart;

  */
}
