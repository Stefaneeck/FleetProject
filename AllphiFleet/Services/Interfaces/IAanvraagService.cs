﻿using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAanvraagService
    {
        public IEnumerable<AanvraagDTO> GetAanvragen(DriverFilter filter);
        public AanvraagDTO GetAanvraag(long id);
    }
}