using PhasmoHelper.Domain.Constants;
using PhasmoHelper.Domain.Enums;
using PhasmoHelper.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using static PhasmoHelper.Domain.Enums.Evidence;

namespace PhasmoHelper.Domain
{
    public class Journal
    {
        public IDictionary<GhostType, bool> Ghosts { get; private set; }
        public IDictionary<Evidence, bool?> CurrentEvidences { get; private set; }
        public IDictionary<ImplicitEvidence, bool?> CurrentImplicitEvidences { get; private set; }

        public Journal()
        {
            Ghosts = new Dictionary<GhostType, bool>();
            ResetEvidences();
            UpdateGhosts();
        }

        public void ConfirmEvidence(Evidence evidence)
        {
            if (CurrentEvidences.Where(x => x.Value.HasValue && x.Value.Value).Count() == 3)
                throw new EvidenceLimitException();

            CurrentEvidences[evidence] = true;
            UpdateGhosts();
        }

        public void RuleOutEvidence(Evidence evidence)
        {
            if (CurrentEvidences.Where(x => x.Value.HasValue && !x.Value.Value).Count() == 3)
                throw new EvidenceLimitException();

            CurrentEvidences[evidence] = false;
            UpdateGhosts();
        }

        public void UncheckEvidence(Evidence evidence)
        {
            CurrentEvidences[evidence] = null;
            UpdateGhosts();
        }

        private void ResetEvidences()
        {
            CurrentEvidences = new Dictionary<Evidence, bool?>
            {
                { DOTS, null },
                { EMF5, null },
                { Fingerprints, null },
                { Freezing, null },
                { Orbs, null },
                { SpiritBox, null },
                { Writing, null }
            };
        }

        private void UpdateGhosts()
        {            
            GhostType[] allGhosts = Enum.GetValues<GhostType>();

            foreach (var ghost in allGhosts)
            {
                IEnumerable<Evidence> currentEvidences = CurrentEvidences.Where(x => x.Value.HasValue && x.Value.Value).Select(x => x.Key);
                IEnumerable<Evidence> ruledOutEvidences = CurrentEvidences.Where(x => x.Value.HasValue && !x.Value.Value).Select(x => x.Key);
                Ghosts[ghost] = Ghost.Evidences[ghost].Any(evidence => currentEvidences.Contains(evidence) || !ruledOutEvidences.Contains(evidence));
            }
        }
    }
}
