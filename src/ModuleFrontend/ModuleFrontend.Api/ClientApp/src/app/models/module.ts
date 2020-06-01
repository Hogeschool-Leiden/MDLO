import { Moduleleider } from "./module-leider";
import { Studiefase } from "./studiefase";
import { Specialisatie } from "./specialisatie";

export interface Module {
    Id: number
    ModuleNaam: string
    ModuleCode: string
    AantalEc: number
    Studiejaar: string
    Moduleleider: Moduleleider
    Studiefase: Studiefase
    VerplichtVoor: Specialisatie[]
    AanbevolenVoor: Specialisatie[]
    BeschrijvingLeerdoelen: string
    InhoudelijkeBeschrijving: string
    Eindeisen: string
    ContacturenWerkvormen: string
    Toetsvorm: string
    VoorwaardenVoldoende: string
    LetOp: string
    Summatief: boolean
    Formatief: boolean
    Kwalitatief: boolean
    Kwantitatief: boolean
    Examinatoren: string
}
