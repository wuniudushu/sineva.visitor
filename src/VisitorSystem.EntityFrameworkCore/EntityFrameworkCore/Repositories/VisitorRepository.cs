using Abp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.VisitorsSystem.VisitorEntity;

namespace VisitorSystem.EntityFrameworkCore.Repositories
{
    public class VisitorRepository: VisitorSystemRepositoryBase<VisitorSystemDbContext,VisitorEntity.Visitor>, IVisitorRepository
    {
        public VisitorRepository(IDbContextProvider<VisitorSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    public class VisitorUserRepository : VisitorSystemRepositoryBase<VisitorSystemDbContext,SinevaUser>, IVisitorUserRepository
    {
        public VisitorUserRepository(IDbContextProvider<VisitorSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    public class VisitorRecordRepository : VisitorSystemRepositoryBase<VisitorSystemDbContext, VisitorRecord>, IVisitorRecordRepository
    {
        public VisitorRecordRepository(IDbContextProvider<VisitorSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
