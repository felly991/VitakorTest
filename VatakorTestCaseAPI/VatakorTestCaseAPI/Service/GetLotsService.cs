using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Interface;
using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Service
{
    public class GetLotsService : IGetAllLots
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetLotsService(DataContext context,
                        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        /// <summary>
        /// Получение всех лотов, которые были созданые за последние 20 минут
        /// </summary>
        /// <returns></returns>
        public async Task<List<LotDTO>> GetAllLots()
        {
            try
            {
                var result = await _context.Lots
                .Where(x => DateTime.UtcNow <= x.DateCreated.Value.AddMinutes(20))
                .ToListAsync();
                var lots = result.Select(lot => _mapper.Map<LotDTO>(lot))
                    .ToList();

                return lots;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new List<LotDTO>();
            }
        }
    }
}
