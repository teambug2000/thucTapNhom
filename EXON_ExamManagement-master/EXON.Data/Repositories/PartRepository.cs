using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IPartRepository : IRepository<PART>
    {
    }
    public class PartRepository : RepositoryBase<PART>, IPartRepository
    {
        public PartRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}