export interface IClaim {

  nbf: number;
  exp: number;
  iss: string;
  aud: string;
  client_id: string;
  sub: string;
  auth_time: number;
  idp: string;
  name: string;
  given_name: string;
  family_name: string;
  website: string;
  role: string;
  preferred_username: string;
  email: string;
  email_verified: boolean;
  jti: string;
  sid: string;
  iat: number;
  scope: string;
  amr: string; 
}
