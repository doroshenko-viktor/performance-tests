using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmarking.LayersDtoConversion
{
    [MemoryDiagnoser]
    public class LayersFunctionalityBenchmark
    {
        private readonly LayersFunctionality _func = new LayersFunctionality();

        [Benchmark(Baseline = true)]
        public async Task WithNoCopy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithLayering(dto, 0);
        }

        [Benchmark()]
        public async Task With3Copy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithLayering(dto, 3);
        }

        [Benchmark()]
        public async Task With30Copy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithLayering(dto, 30);
        }

        [Benchmark()]
        public async Task With300Copy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithLayering(dto, 300);
        }

        [Benchmark()]
        public async Task DeepWithNoCopy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithDeepLayering(dto, 0);
        }

        [Benchmark()]
        public async Task DeepWith3Copy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithDeepLayering(dto, 3);
        }

        [Benchmark()]
        public async Task DeepWith30Copy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithDeepLayering(dto, 30);
        }

        [Benchmark()]
        public async Task DeepWith300Copy()
        {
            var dto = new Dto1("string", 1, 1.0f, 34.3, new InternalDto("string internal"));
            await _func.JobWithDeepLayering(dto, 300);
        }
    }
}