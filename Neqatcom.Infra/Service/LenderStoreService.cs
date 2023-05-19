using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public class LenderStoreService : ILenderStoreService
    {
        private readonly ILenderStoreRepository _lenderStoreRepository;

        public LenderStoreService(ILenderStoreRepository lenderStoreRepository)
        {
            this._lenderStoreRepository = lenderStoreRepository;
        }
        public void createLenderStore(Gplenderstore gplenderstore)
        {
            _lenderStoreRepository.createLenderStore(gplenderstore);
        }
        public List<LoaneesForLendercs> GetAllLoaneesForLendercs(int id)
        {
            return _lenderStoreRepository.GetAllLoaneesForLendercs(id);
        }
        public LenderInfo GetLenderInfo(int id)
        {
            return _lenderStoreRepository.GetLenderInfo(id);
        }
        public void giveComplaintForLoanee(Gpcomplaint gpcomplaint)
        {
            _lenderStoreRepository.giveComplaintForLoanee(gpcomplaint);
        }
        public List<LoanOffer> GetAllLoanOffer(int lenderid, int loaneeid)
        {
            return _lenderStoreRepository.GetAllLoanOffer(lenderid, loaneeid);
        }
        public void DeleteLenderStore(int id)
        {
            _lenderStoreRepository.DeleteLenderStore(id);
        }

        public List<Gplenderstore> GetAllLenderStore()
        {
            return _lenderStoreRepository.GetAllLenderStore();
        }

        public List<LenderUser> GetAllLenderUser()
        {
            return _lenderStoreRepository.GetAllLenderUser();

        }

        public Gplenderstore GetLenderStoreById(int id)
        {
            return _lenderStoreRepository.GetLenderStoreById(id);
        }

        public void UpdateLenderStore(Gplenderstore gplenderstore)
        {
            _lenderStoreRepository.UpdateLenderStore(gplenderstore);
        }

        public List<LenderPayment> GetLenderPayments(int lenderid)
        {
            return _lenderStoreRepository.GetLenderPayments(lenderid);
        }
        public List<Lengths> GetLenderCounters(int lenderid)
        {
            return _lenderStoreRepository.GetLenderCounters(lenderid);
        }
    }
}
