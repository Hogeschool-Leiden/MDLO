import { Moduleleider } from "./moduleleider";
import { Studiefase } from "./studiefase";
import { Studierichting } from "./studierichting";
import { Leerdoelen } from "./leerdoelen";
import { Voorkennis } from "./voorkennis";
import { Middelen } from "./middelen";
import { Weektaak } from "./weektaak";

export interface Modulewijzer {
    moduleNaam: string
    moduleCode: string
    studiepunten: number
    studiejaar: string
    modulehandleiding: string
    moduleleider: Moduleleider
    studiefase: Studiefase
    verplichtVoor: Studierichting[]
    aanbevolenVoor: Studierichting[]
    leerdoelen: Leerdoelen
    voorkennis: Voorkennis
    beschrijvingLeerdoelen: string
    inhoudelijkeBeschrijving: string
    eindeisen: string
    contacturenEnWerkvormen: string
    middelen: Middelen
    leerstofPlanning: Weektaak[]
}
