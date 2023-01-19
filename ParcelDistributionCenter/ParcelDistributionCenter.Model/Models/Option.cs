namespace ParcelDistributionCenter.Model.Enums
{
    public class Option
    {
        public Option(OptionsEnum optionType, string statement)
        {
            OptionType = optionType;
            Statement = statement;
        }

        public OptionsEnum OptionType { get; }
        public string Statement { get; }
    }
}