namespace Benchmarking.LayersDtoConversion
{
    public class Dto1
    {
        public Dto1(string s1, int i1, float f1, double d1, InternalDto @internal)
        {
            S1 = s1;
            I1 = i1;
            F1 = f1;
            D1 = d1;
            Internal = @internal;
        }

        public string S1 { get; }
        public int I1 { get; }
        public float F1 { get; }
        public double D1 { get; }
        public InternalDto Internal { get; }

        public Dto1 Copy()
        {
            return new Dto1(S1, I1, F1, D1, Internal);
        }
        public Dto1 DeepCopy()
        {
            return new Dto1(S1, I1, F1, D1, Internal.Copy());
        }
    }

    public class InternalDto
    {
        public InternalDto(string s1)
        {
            S1 = s1;
        }

        public string S1 { get; }

        public InternalDto Copy()
        {
            return new InternalDto(S1);
        }
    }
}