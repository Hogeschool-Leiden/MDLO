using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class CompetentieMatrix
    {
        public CompetentieMatrix(List<string> architectuurLaagNamen,
            List<string> activiteitNamen,
            IEnumerable<EindCompetentie> eindCompetenties)
        {
            ArchitectuurLaagNamen = architectuurLaagNamen;
            ActiviteitNamen = activiteitNamen;
            Matrix = new Cell[architectuurLaagNamen.Count][];
            MakeMatrix2D(activiteitNamen.Count);
            ConvertEindCompetentiesToMatrix(eindCompetenties);
        }

        public List<string> ArchitectuurLaagNamen { get; }

        public List<string> ActiviteitNamen { get; }

        public Cell[][] Matrix { get; }

        private void MakeMatrix2D(int depth)
        {
            for (var index = 0; index < Matrix.Length; index++)
            {
                Matrix[index] = new Cell[depth];
            }
        }

        private void ConvertEindCompetentiesToMatrix(IEnumerable<EindCompetentie> eindCompetenties)
        {
            foreach (var eindCompetentie in eindCompetenties)
            {
                var index0 = ArchitectuurLaagNamen.IndexOf(eindCompetentie.ArchitectuurLaagNaam);
                var index1 = ActiviteitNamen.IndexOf(eindCompetentie.ActiviteitNaam);
                Matrix[index0][index1] = new Cell(eindCompetentie.Niveau, eindCompetentie.Modules);
            }
        }

        public class Cell
        {
            public Cell(int niveau, IEnumerable<Module> modules)
            {
                Niveau = niveau;
                Modules = modules;
            }

            public int Niveau { get; }
            public IEnumerable<Module> Modules { get; }
        }
    }
}