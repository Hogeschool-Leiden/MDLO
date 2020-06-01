import { ModuleSanitizePipe } from './module-sanitize.pipe';
import { assert } from 'console';
import { Specialisatie } from "../models/specialisatie";
describe('ModuleSanitizePipe', () => {
  it('create an instance', () => {
    const pipe = new ModuleSanitizePipe();
    expect(pipe).toBeTruthy();
  });

  it('Generates a valid Module from a json form value', () => {
    const pipe = new ModuleSanitizePipe();
    let jsonValue = {
      moduleNaam: "correcteNaam",
      moduleCode: "correcteCode",
      aantalEc: "3",
      studiejaar: "correctJaar",
      moduleleider: {
        naam: "correcteNaam",
        email: "correctEmail",
        telefoonnummer: "correctTelefoonnummer"
      },
      studiefase: {
        fase: "correcteFase",
        periode: "4"
      },
      verplichtVoor: {
        SE: true,
        FICT: "",
        BDAM: "",
        IAT: ""
      },
      aanbevolenVoor: {
        SE: "",
        FICT: true,
        BDAM: "",
        IAT: false
      },
      beschrijvingLeerdoelen: "correcteBeschrijving",
      inhoudelijkeBeschrijving: "correcteBeschrijving",
      eindeisen: "correcteEindeisen",
      contacturenWerkvormen: "correcteContacturen",
      toetsvorm: "correcteToetsvorm",
      voorwaardenVoldoende: "correcteVoorwaarde",
      letOp: "correcteLetop",
      summatief: "",
      formatief: true,
      kwalitatief: "",
      kwantitatief: true,
      examinatoren: ""
    }

    let result = pipe.transform(jsonValue);
    expect(result.aanbevolenVoor).toBe([{Code: "SE", Id: undefined, Naam: "Software Engineering"}])
    expect(result.verplichtVoor).toBe([{Code: "SE", Id: undefined, Naam: "Software Engineering"}])
    expect()
  });
});
