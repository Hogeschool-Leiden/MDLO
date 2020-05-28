import { Functie } from "./functie";

export interface Beoordeling {
    toetsvorm: string
    voorwaardeVoorVoldoende: string
    functie: Functie
    examinatoren: string
    medebeoordeling: Beoordeling
    extraInfo: string
    herkansing: string
}
