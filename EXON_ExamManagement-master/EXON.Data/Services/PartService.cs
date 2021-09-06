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
    public interface IPartService
    {
        PART Add(PART PART);

        void Update(PART PART);

        PART Delete(int id);

        IEnumerable<PART> GetAll();

        IEnumerable<PART> GetAll(int SubQuestionId);

        IEnumerable<PART> GetAll(string keyword, int SubQuestionId);

        List<PART> GetRandomList(List<PART> listQuestion, int numQuestion);

        PART GetById(int id);

        void Save();
    }

    public class PartService : IPartService, IDisposable
    {
        private IPartRepository _PartRepository;
        private IPartDetailRepository _PartDetailRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public PartService()
        {
            dbFactory = new DbFactory();
            this._PartRepository = new PartRepository(dbFactory);
            this._PartDetailRepository = new PartDetailRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public PART Add(PART PART)
        {
            return _PartRepository.Add(PART);
        }

        public PART Delete(int id)
        {
            return _PartRepository.Delete(id);
        }

        public IEnumerable<PART> GetAll(int SubQuestionId)
        {
            return _PartRepository.GetAll();
            //return _PARTRepository.GetMulti(x => x.SubQuestionID == SubQuestionId);
        }

        public IEnumerable<PART> GetAll(string keyword, int SubQuestionId)
        {
            return _PartRepository.GetAll();

            //if (!string.IsNullOrEmpty(keyword))
            //    return _PARTRepository.GetMulti(x => x.PARTContent.Contains(keyword) && x.SubQuestionID == SubQuestionId);
            //else
            //    return _PARTRepository.GetMulti(x => x.SubQuestionID == SubQuestionId);
        }

        public PART GetById(int id)
        {
            return _PartRepository.GetSingleById(id);
        }
    
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PART PART)
        {
            _PartRepository.Update(PART);
        }

        public IEnumerable<PART> GetAll()
        {
            return _PartRepository.GetAll();
        }
        public IEnumerable<PART> GetByScheduleId(int ScheduleId)
        {
            var listPart = _PartRepository.GetMulti(x => x.ScheduleID == ScheduleId);
            if (listPart != null)
            {
                return listPart;

            }
            else return null;
        }

        public PART GetByTopicId(int TopicId)
        {
            var partDetail = _PartDetailRepository.GetSingleByCondition(x => x.TopicID == TopicId);
            if (partDetail != null)
            {
                return _PartRepository.GetSingleById(partDetail.PartID.Value);

            }
            else return null;
        }
        public List<PART> GetRandomList(List<PART> listQuestion, int numQuestion)
        {
            return _PartRepository.GetRandomList(listQuestion, numQuestion);
        }

        public void Dispose()
        {
            _PartRepository = null;
            _unitOfWork = null;
            dbFactory = null;
        }
    }
}
