//todo
//nested adres en tankkaart object
export interface IDriver {

  id: number;
  naam: string;
  voornaam: number;
  geboorteDatum: Date;
  rijksregisterNummer: number;
  typeRijbewijs: number;
  Actief: boolean;
  AdresId: number;
  TankkaartId: number;
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
