using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace DictionariesForms.DTO
{
    public class PhaseDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ContourId { get; set; }
        public string? ContourName { get; set; }
        public int? CompatibilityId { get; set; }
        public string? CompatibilityName { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? IsRequiredProcessPhase { get; set; }
        public string? PhaseOrder { get; set; }
        public string? IsActive { get; set; }
        public int? PhaseSequenceId { get; set; }
        public string? PhaseSequenceName { get; set; }
        public int? PhaseStageId { get; set; }
        public string? PhaseStageName { get; set; }
        public int? VersionNumber { get; set; }
    }
}
