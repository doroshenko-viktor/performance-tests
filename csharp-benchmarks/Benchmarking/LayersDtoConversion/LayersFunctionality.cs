using System.Threading.Tasks;

namespace Benchmarking.LayersDtoConversion
{
    public class LayersFunctionality
    {
        public async Task JobWithLayering(Dto1 dto, int num)
        {
            var latest = dto;
            for (int i = 0; i < num; i++)
            {
                latest = dto.Copy();
            }
            await Job(latest);
        }
        public async Task JobWithDeepLayering(Dto1 dto, int num)
        {
            var latest = dto;
            for (int i = 0; i < num; i++)
            {
                latest = dto.DeepCopy();
            }
            await Job(latest);
        }

        private async Task Job(Dto1 dto)
        {
            await Task.Delay(10);
        }
    }
}