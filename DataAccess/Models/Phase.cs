using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Models
{
    public class Phase
    {
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public bool? IsRequiredProcessPhase { get; set; }

        public int? PhaseOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? Last_IsActive_ChangeDate { get; set; }

        public int? VersionNumber { get; set; }
    }
}
