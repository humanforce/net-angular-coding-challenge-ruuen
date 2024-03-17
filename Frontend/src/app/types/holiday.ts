import { Country } from './country';

export interface Holiday {
  name: string;
  startDate: string;
  endDate: string;
  location: Country;
}
