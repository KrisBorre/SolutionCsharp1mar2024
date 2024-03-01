namespace LibraryPhysicalUnits13feb2024
{
    public static class EnergyCalculation
    {
        public static EnergyInJoule14feb2024 Add(IEnergy energy1, IEnergy energy2)
        {
            double accuracy = Math.Sqrt(Math.Pow(energy1.GetPrecisionInJoule(), 2) + Math.Pow(energy2.GetPrecisionInJoule(), 2));
            return new EnergyInJoule14feb2024(energy1.GetInJoule() + energy2.GetInJoule(), accuracy);
        }

    }
}
