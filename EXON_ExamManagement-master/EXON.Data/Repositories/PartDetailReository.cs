using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IPartDetailRepository : IRepository<PARTS_DETAILS>
    {
    }
    public class PartDetailRepository : RepositoryBase<PARTS_DETAILS>, IPartDetailRepository
    {
        public PartDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
