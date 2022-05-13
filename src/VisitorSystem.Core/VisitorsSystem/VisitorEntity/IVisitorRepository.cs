using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.VisitorEntity;

namespace VisitorSystem.VisitorsSystem.VisitorEntity
{
    public interface IVisitorRepository:IRepository<Visitor>
    {
    }
    public interface IVisitorUserRepository : IRepository<SinevaUser>
    {
    }
    public interface IVisitorRecordRepository : IRepository<VisitorRecord>
    {
    }
}
