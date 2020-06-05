import { Moduleleider } from "./module-leider";
import { Studiefase } from "./studiefase";
import { Specialisatie } from "./specialisatie";
import { Matrix } from "./matrix";

export interface Module {
    id: number
    moduleNaam: string
    moduleCode: string
    aantalEc: number
    studiejaar: string
    moduleleider: Moduleleider
    studiefase: Studiefase
    verplichtVoor: Specialisatie[]
    aanbevolenVoor: Specialisatie[]
    competenties: Matrix
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
