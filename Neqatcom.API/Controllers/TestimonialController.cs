using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.Service;
using System.Collections.Generic;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService _testimonialService)
        {
            this._testimonialService = _testimonialService;
        }
        
        [HttpGet]
        [Route("GetTestimonialById/{id}")]
        public Gptestimonial GetTestimonialById(int id)
        {
            return _testimonialService.GetTestimonialById(id);
        }
        [HttpPost]
        [Route("CreateTestimonial")]
        public void CreateHomeTestimonial(Gptestimonial finalTestimonial)
        {
            _testimonialService.CreateHomeTestimonial(finalTestimonial);
        }
        [HttpPut]
        [Route("UpdateTestimonial")]
        public void UpdateTestimonial(Gptestimonial finalTestimonial)
        {
            _testimonialService.UpdateTestimonial(finalTestimonial);
        }
        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public void DeleteTestimonial(int id)
        {
            _testimonialService.DeleteTestimonial(id);
        }

        [HttpGet]
        [Route("GetAllTestimonials")]
        public List<Gptestimonial> GetAllTestimonial()
        {
            return _testimonialService.GetAllTestimonial();
        }
    }
}
