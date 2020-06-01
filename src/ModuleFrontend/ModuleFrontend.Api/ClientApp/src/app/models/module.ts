import { Moduleleider } from "./module-leider";
import { Studiefase } from "./studiefase";
import { Specialisatie } from "./specialisatie";

export interface Module {
    Id: number
    moduleNaam: string
    moduleCode: string
    aantalEc: number
    studiejaar: string
    moduleleider: Moduleleider
    studiefase: Studiefase
    verplichtVoor: Specialisatie[]
    aanbevolenVoor: Specialisatie[]
    beschrijvingLeerdoelen: string
    inhoudelijkeBeschrijving: string
    eindeisen: string
    contacturenWerkvormen: string
    toetsvorm: string
    voorwaardenVoldoende: string
    letOp: string
    summatief: boolean
    formatief: boolean
    kwalitatief: boolean
    kwantitatief: boolean
    examinatoren: string
}
