using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Service;
using System.Collections.Generic;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LenderStoreController : ControllerBase
    {
        private readonly ILenderStoreService _lenderStoreService;
        public LenderStoreController(ILenderStoreService lenderStoreService)
        {
            _lenderStoreService = lenderStoreService;
        }
        [HttpGet]
        [Route("GetAllLenderStore")]
       public List<Gplenderstore> GetAllLenderStore()
        {
           return _lenderStoreService.GetAllLenderStore();
        }
        [HttpGet]
        [Route("GetAllLenderUser")]
        public List<LenderUser> GetAllLenderUser()
        {
            return _lenderStoreService.GetAllLenderUser();
        }
        [HttpGet]
        [Route("GetAllLoanOffer")]
        public List<LoanOffer> GetAllLoanOffer(int lenderid, int loaneeid)
        {
            return _lenderStoreService.GetAllLoanOffer(lenderid, loaneeid);
        }
        [HttpGet]
        [Route("GetLenderStoreById/{id}")]
       public Gplenderstore GetLenderStoreById(int id)
        {
            return _lenderStoreService.GetLenderStoreById(id);
        }
        [HttpGet]
        [Route("LoaneesForLenders/{id}")]
        public List<LoaneesForLendercs> GetAllLoaneesForLendercs(int id)
        {
            return _lenderStoreService.GetAllLoaneesForLendercs(id);
        }
        [HttpPost]
        [Route("createLenderStore")]
       public void createLenderStore(Gplenderstore gplenderstore)
        {
            _lenderStoreService.createLenderStore(gplenderstore);
        }
        [HttpPut]
        [Route("UpdateLenderStore")]
        public void UpdateLenderStore(Gplenderstore gplenderstore)
        {
            _lenderStoreService.UpdateLenderStore(gplenderstore);
        }
        [HttpDelete]
        [Route("DeleteLenderStore/{id}")]
        public void DeleteLenderStore(int id)
        {
            _lenderStoreService.DeleteLenderStore(id);
        }
    }
}
