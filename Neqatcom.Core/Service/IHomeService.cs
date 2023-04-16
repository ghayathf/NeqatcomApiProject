﻿using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface IHomeService
    {
        List<Gphomepage> GetAllHomeInformation();
        Gphomepage GetHomeInformationById(int id);
        void CreateHomeInformation(Gphomepage finalHomepage);
        void UpdateHomeInformation(Gphomepage finalHomepage);

        void DeleteHomeInformation(int id);

    }
}