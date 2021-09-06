using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System;
using EXON.Common;
using System.Linq;
namespace EXON.Data.Services
{
    public interface IRegisterService
    {
        REGISTER Add(REGISTER REGISTER);

        void Update(REGISTER REGISTER);

        void Delete(int id,int stt);

        IEnumerable<REGISTER> GetAll();

        IEnumerable<REGISTER> GetAllByName(int ContestID, string Name);

        IEnumerable<REGISTER> GetAllNotDelete(int ContestID);

        List<REGISTER> GetRandomList(List<REGISTER> listQuestion, int numQuestion);

        REGISTER GetById(int id);
        IEnumerable<REGISTER> GetAllNotDeleteAndNotContestant(int ContestID);
        IEnumerable<REGISTER> GetByIdentityCard(string id, int contestid);
        bool RemoveByContestantID(int id);
        void Save();
    }

    public class RegisterService : IRegisterService
    {
        private IRegisterRepository _RegisterRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public RegisterService()
        {
            dbFactory = new DbFactory();
            this._RegisterRepository = new RegisterRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public REGISTER Add(REGISTER REGISTER)
        {
            return _RegisterRepository.Add(REGISTER);
        }

        public void Delete(int id,int stt) //delete stt=0
        {
            REGISTER rg = GetById(id);
            if (rg != null)
            {
                rg.Status = stt;
                _RegisterRepository.Update(rg);
            }
        }
        public bool RemoveByContestantID(int id)
        {
            ContestantService consv = new ContestantService();
            CONTESTANT con = new CONTESTANT();
            con = consv.GetById(id);
            REGISTER rg = GetById(con.RegisterID);
            ReceiptService receiptsv = new ReceiptService();
            RegisterSubjectService rgsubsv = new RegisterSubjectService();
            
            if (rg != null)
            {
                List<RECEIPT> lstreceipt = rg.RECEIPTS.ToList();
                foreach (var recitem in lstreceipt)
                {
                    receiptsv.Delete(recitem.ReceiptID);   
                }
                receiptsv.Save();
                List < REGISTERS_SUBJECTS > lstregsub = rg.REGISTERS_SUBJECTS.ToList();
                foreach (var rgsub in lstregsub)
                {
                    rgsubsv.Delete(rgsub.RegisterSubjectID);
                }
                rgsubsv.Save();
                List<CONTESTANT> lstcon = rg.CONTESTANTS.ToList();
                foreach(var conitem in lstcon)
                {
                    consv.Delete(conitem.ContestantID);
                }
                consv.Save();
                rg = GetById(con.RegisterID);
                _RegisterRepository.Delete(rg);
                Save();
                return true;
            }
            return false;
        }
        public REGISTER GetById(int id)
        {
            return _RegisterRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(REGISTER REGISTER)
        {
            _RegisterRepository.Update(REGISTER);
        }

        public IEnumerable<REGISTER> GetAll()
        {
            return _RegisterRepository.GetAll();
        }

        public List<REGISTER> GetRandomList(List<REGISTER> listQuestion, int numQuestion)
        {
            return _RegisterRepository.GetRandomList(listQuestion, numQuestion);
        }

        public IEnumerable<REGISTER> GetAllNotDelete(int ContestID)
        {
            return _RegisterRepository.GetMulti(x => x.Status != (int)Register.Deleted  && x.ContestID == ContestID);
        }
        public IEnumerable<REGISTER> GetAllNotDeleteAndNotContestant(int ContestID)
        {
            return _RegisterRepository.GetMulti(x => x.Status != (int)Register.Deleted && x.Status < (int)Register.Iscontestant && x.ContestID == ContestID);
        }
        public IEnumerable<REGISTER> GetAllByName(int ContestID, string Name)
        {
            return _RegisterRepository.GetMulti(x => x.Status != (int)Register.Deleted
            && x.ContestID == ContestID
            && x.FullName.Contains(Name));
        }

        public IEnumerable<REGISTER> GetByIdentityCard(string id, int contestid)
        {
            return _RegisterRepository.GetMulti(x => x.IdentityCardNumber == id && x.ContestID == contestid);
        }
    }
}