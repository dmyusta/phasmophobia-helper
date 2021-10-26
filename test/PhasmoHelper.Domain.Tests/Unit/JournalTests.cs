using FluentAssertions;
using PhasmoHelper.Domain.Constants;
using PhasmoHelper.Domain.Enums;
using PhasmoHelper.Infrastructure.Exceptions;
using System;
using System.Linq;
using Xunit;

namespace PhasmoHelper.Domain.Tests
{
    public class JournalTests
    {
        [Fact]
        public void ConfirmEvidence_once_updates_ghosts_successfully()
        {
            // Arrange
            var journal = new Journal();
            var orbs = Evidence.Orbs;
            var expectedGhostTypes = Ghost.Evidences.Where(x => x.Value.Contains(orbs)).Select(x => x.Key);

            // Act
            journal.ConfirmEvidence(orbs);

            // Assert
            journal.Ghosts.Should().BeEquivalentTo(expectedGhostTypes);
        }

        [Fact]
        public void ConfirmEvidence_twice_updates_ghosts_successfully()
        {
            // Arrange
            var journal = new Journal();
            var orbs = Evidence.Orbs;
            var fingerprints = Evidence.Fingerprints;
            var expectedGhostTypes = Ghost.Evidences.Where(x => x.Value.Contains(orbs) && x.Value.Contains(fingerprints)).Select(x => x.Key);

            // Act
            journal.ConfirmEvidence(orbs);
            journal.ConfirmEvidence(fingerprints);

            // Assert
            journal.Ghosts.Should().BeEquivalentTo(expectedGhostTypes);
        }

        [Fact]
        public void ConfirmEvidence_three_times_finds_ghost()
        {
            // Arrange
            var journal = new Journal();

            // Act
            journal.ConfirmEvidence(Evidence.Orbs);
            journal.ConfirmEvidence(Evidence.Fingerprints);
            journal.ConfirmEvidence(Evidence.DOTS);

            // Assert
            var ghostType = journal.Ghosts.SingleOrDefault(x => x.Value);
            ghostType.Should().NotBeNull();
            ghostType.Should().Be(GhostType.Banshee);
        }

        [Fact]
        public void ConfirmEvidence_three_times_for_impossible_combination_does_not_find_any_ghost()
        {
            // Arrange
            var journal = new Journal();

            // Act
            journal.ConfirmEvidence(Evidence.Orbs);
            journal.ConfirmEvidence(Evidence.SpiritBox);
            journal.ConfirmEvidence(Evidence.EMF5);

            // Assert
            var ghosts = journal.Ghosts.Where(x => x.Value);
            ghosts.Should().HaveCount(0);
        }

        [Fact]
        public void ConfirmEvidence_more_than_three_times_throws_exception()
        {
            // Arrange
            var journal = new Journal();

            // Act
            journal.ConfirmEvidence(Evidence.Orbs);
            journal.ConfirmEvidence(Evidence.Fingerprints);
            journal.ConfirmEvidence(Evidence.DOTS);
            Action action = () => journal.ConfirmEvidence(Evidence.SpiritBox);

            // Assert
            action.Should().Throw<EvidenceLimitException>();
        }

        [Fact]
        public void RuleOutEvidence_once_updates_ghosts_successfully()
        {

        }

        [Fact]
        public void RuleOutEvidence_twice_updates_ghosts_succesfully()
        {

        }

        [Fact]
        public void RuleOutEvidence_three_times_finds_ghost()
        {

        }

        [Fact]
        public void RuleOutEvidence_three_times_for_impossible_combination_does_not_find_any_ghost()
        {

        }

        [Fact]
        public void RuleOutEvidence_more_than_three_times_throws_exception()
        {

        }
    }
}
