using System.ComponentModel;

namespace Api.Models
{
    public enum ContactType
    {
        [Description("Mãe")]
        Mother = 0,
        [Description("Pai")]
        Father = 1,
        [Description("Irmão")]
        Brother = 2,
        [Description("Other")]
        Other = 3
    }
}
