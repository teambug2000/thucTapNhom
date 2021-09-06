using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IPartSubjectDetailRepository : IRepository<PARTS_SUBJECT_DETAILS>
    {
    }
    public class PartSubjectDetailRepository : RepositoryBase<PARTS_SUBJECT_DETAILS>, IPartSubjectDetailRepository
    {
        public PartSubjectDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
