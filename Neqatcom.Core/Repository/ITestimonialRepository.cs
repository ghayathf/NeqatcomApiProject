using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
    public interface ITestimonialRepository
    {
        List<Gptestimonial> GetAllTestimonial();
        List<Gptestimonial> GetAllAcceptedTestimonial();
        Gptestimonial GetTestimonialById(int id);
        void CreateHomeTestimonial(Gptestimonial finalTestimonial);
        void UpdateTestimonial(Gptestimonial finalTestimonial);
        void DeleteTestimonial(int id);
    }
}
