using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class CompetentieMatrix
    {
        public CompetentieMatrix()
        {
        }

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

        public List<string> ArchitectuurLaagNamen { get; set; }

        public List<string> ActiviteitNamen { get; set; }

        public Cell[][] Matrix { get; set; }

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
                Matrix[index0][index1] = new Cell {Niveau = eindCompetentie.Niveau, Modules = eindCompetentie.Modules};
            }
        }

        public class Cell
        {
            public int Niveau { get; set; }
            public IEnumerable<Module> Modules { get; set; }
        }
    }
}