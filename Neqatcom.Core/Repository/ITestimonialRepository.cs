using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
    public interface ITestimonialRepository
    {
        List<TestimonalUser> GetAllTestimonial();
        List<TestimonalUser> GetTestimonialHome();
        Gptestimonial GetTestimonialById(int id);
        void CreateHomeTestimonial(Gptestimonial finalTestimonial);
        void UpdateTestimonial(Gptestimonial finalTestimonial);
        void DeleteTestimonial(int id);
    }
}
