using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class CompetentieMatrixService : ICompetentieMatrixService
    {
        private readonly ILogger<CompetentieMatrixService> _logger;
        private readonly IArchitectuurLaagRepository _architectuurLaagRepository;
        private readonly IActiviteitRepository _activiteitRepository;

        public CompetentieMatrixService(ILogger<CompetentieMatrixService> logger,
            IArchitectuurLaagRepository architectuurLaagRepository, IActiviteitRepository activiteitRepository)
        {
            _logger = logger;
            _architectuurLaagRepository = architectuurLaagRepository;
            _activiteitRepository = activiteitRepository;
        }

        public CompetentieMatrix CreateCompetentieMatrix(Module module)
        {
            var architectuurLaagNamen = _architectuurLaagRepository.GetAllArchitectuurLaagNamen().ToList();
            var activiteitNamen = _activiteitRepository.GetAllActiviteitNamen().ToList();
            var matrix = new CompetentieMatrix.Cell[architectuurLaagNamen.Count][];
            MakeMatrix2D(matrix, activiteitNamen.Count);
            ConvertEindCompetentiesToMatrix(module.Competenties, architectuurLaagNamen, activiteitNamen, matrix);
            return new CompetentieMatrix
            {
                ArchitectuurLaagNamen = architectuurLaagNamen,
                ActiviteitNamen = activiteitNamen,
                Matrix = matrix
            };
        }

        private static void MakeMatrix2D(IList<CompetentieMatrix.Cell[]> matrix, int depth)
        {
            for (var index = 0; index < matrix.Count; index++)
            {
                matrix[index] = new CompetentieMatrix.Cell[depth];
            }
        }

        private static void ConvertEindCompetentiesToMatrix(IEnumerable<Competentie> competenties,
            IList<string> architectuurLaagNamen, IList<string> activiteitNamen, CompetentieMatrix.Cell[][] matrix)
        {
            foreach (var competentie in competenties)
            {
                var index0 =
                    architectuurLaagNamen.IndexOf(competentie.BeheersingsNiveau.ArchitectuurLaag.ArchitectuurLaagNaam);
                var index1 = activiteitNamen.IndexOf(competentie.BeheersingsNiveau.Activiteit.ActiviteitNaam);
                matrix[index0][index1] = new CompetentieMatrix.Cell {Niveau = competentie.BeheersingsNiveau.Niveau};
            }
        }
    }
}