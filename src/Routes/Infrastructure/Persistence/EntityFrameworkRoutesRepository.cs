using Microsoft.EntityFrameworkCore;
using Rusell.Routes.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Routes.Infrastructure.Persistence;

public class EntityFrameworkRoutesRepository : Repository<Route, RouteId>, IRoutesRepository
{
    public EntityFrameworkRoutesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Route?> Find(RouteId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Route>().AsNoTracking() : Context.Set<Route>().AsTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == key);
    }
}