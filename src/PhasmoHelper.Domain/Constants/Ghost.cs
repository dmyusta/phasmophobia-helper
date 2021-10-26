using PhasmoHelper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhasmoHelper.Domain.Enums.Evidence;

namespace PhasmoHelper.Domain.Constants
{
    public static class Ghost
    {
        public static readonly IDictionary<GhostType, IEnumerable<Evidence>> Evidences =
            new Dictionary<GhostType, IEnumerable<Evidence>>
            {
                { GhostType.Banshee, new[] { DOTS, Fingerprints, Orbs } },
                { GhostType.Demon, new[] { Freezing, Fingerprints, Writing } },
                { GhostType.Goryo, new[] { EMF5, Fingerprints, DOTS } },
                { GhostType.Hantu, new[] { Orbs, Freezing, Fingerprints} },
                { GhostType.Jinn, new[] { EMF5, Freezing, Fingerprints } },
                { GhostType.Mare, new[] { Orbs, SpiritBox, Writing } },
                { GhostType.Myling, new[] { EMF5, Fingerprints, Writing } },
                { GhostType.Obake, new[] { EMF5, Orbs, Fingerprints } },
                { GhostType.Oni, new[] { EMF5, Freezing, DOTS } },
                { GhostType.Onryo, new[] { Orbs, SpiritBox, Freezing } },
                { GhostType.Phantom, new[] { SpiritBox, Fingerprints, DOTS } },
                { GhostType.Poltergeist, new[] { SpiritBox, Fingerprints, Writing } },
                { GhostType.Raiju, new[] { EMF5, Orbs, DOTS } },
                { GhostType.Revenant, new[] { Orbs, Freezing, Writing } },
                { GhostType.Shade, new[] { EMF5, Freezing, Writing } },
                { GhostType.Spirit, new[] { EMF5, SpiritBox, Writing } },
                { GhostType.TheTwins, new[] { EMF5, SpiritBox, Freezing } },
                { GhostType.Wraith, new[] { EMF5, SpiritBox, DOTS } },
                { GhostType.Yokai, new[] { Orbs, SpiritBox, DOTS } },
                { GhostType.Yurei, new[] { Orbs, Freezing, DOTS } },
            };

        public static readonly IDictionary<GhostType, IEnumerable<ImplicitEvidence>> ImplicitEvidences =
            new Dictionary<GhostType, IEnumerable<ImplicitEvidence>>
            {

            };
    }
}
