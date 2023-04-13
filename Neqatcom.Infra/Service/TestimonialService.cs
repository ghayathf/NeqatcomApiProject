using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public class TestimonialService:ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            this.testimonialRepository = testimonialRepository;
        }
        public void CreateHomeTestimonial(Gptestimonial finalTestimonial)
        {
            testimonialRepository.CreateHomeTestimonial(finalTestimonial);
        }

        public void DeleteTestimonial(int id)
        {
            testimonialRepository.DeleteTestimonial(id);
        }

        public List<Gptestimonial> GetAllAcceptedTestimonial()
        {
            return testimonialRepository.GetAllAcceptedTestimonial();
        }

        public List<Gptestimonial> GetAllTestimonial()
        {
            return testimonialRepository.GetAllTestimonial();
        }

        public Gptestimonial GetTestimonialById(int id)
        {
            return testimonialRepository.GetTestimonialById(id);
        }

        public void UpdateTestimonial(Gptestimonial finalTestimonial)
        {
            testimonialRepository.UpdateTestimonial(finalTestimonial);
        }

    }
}
