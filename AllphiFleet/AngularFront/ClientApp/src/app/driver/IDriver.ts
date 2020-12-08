import { IAdres } from "./IAdres";
import { ITankkaart } from "./ITankkaart";

export interface IDriver {

  id: number;
  naam: string;
  voornaam: number;
  geboorteDatum: Date;
  rijksRegisterNummer: number;
  typeRijbewijs: number;
  actief: boolean;
  adres: IAdres;
  tankkaart: ITankkaart;
  /*
  id: number;
  name: string;
  firstName: number;
  dateOfBirth: Date;
  SocialSecurityNumber: number;
  DriverLicenceType: number;
  Active: boolean;
  AddressId: number;
  GasCardId: number;
  */
}
