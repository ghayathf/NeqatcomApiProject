using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface ITestimonialService
    {
        List<TestimonialDTO> GetAllTestimonial();
        List<TestimonialDTO> GetAllAcceptedTestimonial();
        Gptestimonial GetTestimonialById(int id);
        void CreateHomeTestimonial(Gptestimonial finalTestimonial);
        void UpdateTestimonial(Gptestimonial finalTestimonial);
        void DeleteTestimonial(int id);
    }
}
