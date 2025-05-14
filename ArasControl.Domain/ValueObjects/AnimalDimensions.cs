namespace ArasControl.Domain.ValueObjects
{
    public class AnimalDimensions
    {
        public double WeightKg { get; private set; }
        public double HeightCm { get; private set; }

        public AnimalDimensions(double weightKg, double heightCm)
        {
            if (weightKg <= 0)
                throw new ArgumentException("WeightKg must be positive.", nameof(weightKg));
            if (heightCm <= 0)
                throw new ArgumentException("HeightCm must be positive.", nameof(heightCm));

            WeightKg = weightKg;
            HeightCm = heightCm;
        }
    }
}
