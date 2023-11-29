using CarZone.Data;
using CarZone.Models;
using Microsoft.EntityFrameworkCore;

namespace CarZone.Services
{
    public class RelatorioVendaService
    {
        private readonly BancoContext _context;

        public RelatorioVendaService(BancoContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.VendasDB select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataVenda >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataVenda <= maxDate.Value);
            }

            return await result
                .Include(x => x.Cliente)
                .Include(x => x.Pagamento)
                .Include(x => x.Marca)
                .Include(x => x.Modelo) 
                .ToListAsync();
        }
    }
}
