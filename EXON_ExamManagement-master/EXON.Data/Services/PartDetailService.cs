using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;

namespace EXON.Data.Services
{
    public interface IPartDetailService
    {
        PARTS_DETAILS Add(PARTS_DETAILS PARTS_DETAILS);

        void Update(PARTS_DETAILS PARTS_DETAILS);

        PARTS_DETAILS Delete(int id);

        IEnumerable<PARTS_DETAILS> GetAll();

        IEnumerable<PARTS_DETAILS> GetAll(int SubjectID);

        IEnumerable<PARTS_DETAILS> GetAll(string keyword, int SubjectID);

        List<PARTS_DETAILS> GetRandomList(List<PARTS_DETAILS> listQuestion, int numQuestion);

        PARTS_DETAILS GetById(int id);

        void Save();
    }
    public class PartDetailService : IPartDetailService, IDisposable
    {
        private PartDetailRepository _PartDetailRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public PartDetailService()
        {
            dbFactory = new DbFactory();
            this._PartDetailRepository = new PartDetailRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public PARTS_DETAILS Add(PARTS_DETAILS PARTS_DETAILS)
        {
            return _PartDetailRepository.Add(PARTS_DETAILS);
        }

        public PARTS_DETAILS Delete(int id)
        {
            return _PartDetailRepository.Delete(id);
        }

        public IEnumerable<PARTS_DETAILS> GetAll(int SubQuestionId)
        {

            return _PartDetailRepository.GetAll();
            // return _PartDetailRepository.GetMulti(x => x.SubQuestionID == SubQuestionId);

        }
        public IEnumerable<PARTS_DETAILS> GetAllByPartID(int PartID)
        {
            return _PartDetailRepository.GetMulti(x => x.PartID == PartID);
        }

        public IEnumerable<PARTS_DETAILS> GetAll(string keyword, int SubQuestionId)
        {
            //if (!string.IsNullOrEmpty(keyword))
            //    return _PartDetailRepository.GetMulti(x => x.PARTS_DETAILSContent.Contains(keyword) && x.SubQuestionID == SubQuestionId);
            //else
            //    return _PartDetailRepository.GetMulti(x => x.SubQuestionID == SubQuestionId);
            return _PartDetailRepository.GetAll();
        }

        public PARTS_DETAILS GetById(int id)
        {
            return _PartDetailRepository.GetSingleById(id);
        }


        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PARTS_DETAILS PARTS_DETAILS)
        {
            _PartDetailRepository.Update(PARTS_DETAILS);
        }

        public IEnumerable<PARTS_DETAILS> GetAll()
        {
            return _PartDetailRepository.GetAll();
        }
        public PARTS_DETAILS GetByTopicId(int TopicId)
        {

            return _PartDetailRepository.GetSingleByCondition(x => x.TopicID == TopicId);
        }
        public List<PARTS_DETAILS> GetRandomList(List<PARTS_DETAILS> listQuestion, int numQuestion)
        {
            return _PartDetailRepository.GetRandomList(listQuestion, numQuestion);
        }

        public void Dispose()
        {
            _PartDetailRepository = null;
            _unitOfWork = null;
            dbFactory = null;
        }
    }
}
