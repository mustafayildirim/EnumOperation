using System.ComponentModel;

namespace EnumOperation
{
    public enum RomanNumerals
    {
        [Description("I")]
        One,
        [Description("V")]
        Five,
        [Description("X")]
        Ten,
        [Description("L")]
        Fifty,
        [Description("C")]
        Hundred,
        [Description("D")]
        FiveHundred,
        [Description("M")]
        Thousand
    }
}
