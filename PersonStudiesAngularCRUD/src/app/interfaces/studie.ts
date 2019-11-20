import { Person } from './person';

export interface Studie {
    id: string;
    name: LevelStudy;
    dateStart: string;
    dateEnd: string;
    personId: number;
    person: Person;
}

export enum LevelStudy {
    Primaria = 1,
    Bachillerato = 2,
    Pregrado = 3,
    Postgrado = 4,
    Ninguno = 5
}
