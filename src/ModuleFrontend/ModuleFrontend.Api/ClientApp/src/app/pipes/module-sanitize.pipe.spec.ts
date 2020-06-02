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
      examinatoren: "Studenten"
    }

    let result = pipe.transform(jsonValue);
    expect(result.aanbevolenVoor).toEqual([{code: "FICT", id: undefined, naam: "Forensische IT"}])
    expect(result.verplichtVoor).toEqual([{code: "SE", id: undefined, naam: "Software Engineering"}])
    expect(result.moduleNaam).toBe("correcteNaam");
    expect(result.moduleCode).toBe("correcteCode");
    expect(result.aantalEc).toBe(3);
    expect(result.studiejaar).toBe("correctJaar");
    expect(result.moduleleider).toEqual({id: undefined, naam: "correcteNaam", email: "correctEmail", telefoonnummer: "correctTelefoonnummer"});
    expect(result.studiefase).toEqual({id: undefined, fase: "correcteFase", periode: {id: undefined, periodeNummer: 4}});
    expect(result.beschrijvingLeerdoelen).toBe("correcteBeschrijving");
    expect(result.inhoudelijkeBeschrijving).toBe("correcteBeschrijving");
    expect(result.eindeisen).toBe("correcteEindeisen");
    expect(result.contacturenWerkvormen).toBe("correcteContacturen");
    expect(result.toetsvorm).toBe("correcteToetsvorm");
    expect(result.voorwaardenVoldoende).toBe("correcteVoorwaarde");
    expect(result.letOp).toBe("correcteLetop");
    expect(result.summatief).toBe(false);
    expect(result.formatief).toBe(true);
    expect(result.kwalitatief).toBe(false);
    expect(result.kwantitatief).toBe(true);
    expect(result.examinatoren).toBe("Studenten");

    

  });
});
