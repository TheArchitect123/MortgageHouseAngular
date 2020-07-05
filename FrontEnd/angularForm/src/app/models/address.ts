import { StreetType } from '../enums/streetType';

export class AddressDto {
  public StreetNumber: string;
  public StreetName: string;
  public StreetOption: StreetType;

  public Suburb: string;
  public Postcode: number;
}
