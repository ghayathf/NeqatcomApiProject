﻿using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public class HomeService :IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public void CalculateCreditScores()
        {
            _homeRepository.CalculateCreditScores();
        }
        

        public void CreateHomeInformation(Gphomepage finalHomepage)
        {
            _homeRepository.CreateHomeInformation(finalHomepage);
        }

        public List<bool> CreditScoreStatus(int loaneeid)
        {
            return _homeRepository.CreditScoreStatus(loaneeid);
        }

        public void DeleteHomeInformation(int id)
        {
            _homeRepository.DeleteHomeInformation(id);
        }

        public List<Gphomepage> GetAllHomeInformation()
        {
            return _homeRepository.GetAllHomeInformation();
        }

        public Gphomepage GetHomeInformationById(int id)
        {
            return _homeRepository.GetHomeInformationById(id);
        }

        public List<LoaneeReminder> GetLoaneesInPayDaytoRemind()
        {
            return _homeRepository.GetLoaneesInPayDaytoRemind();

        }

        public List<LoaneeReminder> GetLoaneeslatePayDaytoRemind()
        {
            return _homeRepository.GetLoaneeslatePayDaytoRemind();
        }

        public List<LoaneeReminder> GetLoaneestoRemind()
        {
            return _homeRepository.GetLoaneestoRemind();
        }

        public List<Lengths> getTableLength()
        {
            return _homeRepository.getTableLength();
        }

        public void UpdateBeforeReminder()
        {
            _homeRepository.UpdateBeforeReminder();
        }

        public void UpdateHomeInformation(Gphomepage finalHomepage)
        {
            _homeRepository.UpdateHomeInformation(finalHomepage);
        }

        public void UpdateInPayDateReminder()
        {
            _homeRepository.UpdateInPayDateReminder();
        }

        public void UpdateLatePayDateReminder()
        {
            _homeRepository.UpdateLatePayDateReminder();
        }
    }
}
