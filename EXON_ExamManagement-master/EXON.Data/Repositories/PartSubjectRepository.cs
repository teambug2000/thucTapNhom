using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.Data.Infrastructures;
using EXON.Model.Models;


namespace EXON.Data.Repositories
{
    public interface IPartSubjectRepository : IRepository<PARTS_SUBJECT>
    {
    }
    public class PartSubjectRepository : RepositoryBase<PARTS_SUBJECT>, IPartSubjectRepository
    {
        public PartSubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

