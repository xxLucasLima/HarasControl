
export interface AnimalDto {
  id: string;
  name: string;
  breed: string;
  color: string;
  dimensions?: {
    weight: number;
    height: number;
  }; 
  harasId: string;
  ownerId: string;
  dateOfBirth: string;
  sex: 'Male' | 'Female';
  microchipId?: string;
  registrationNumber?: string;
  temperament?: string;
  medicalHistory?: string;
}
