using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentsAPI.Models.Interfaces
{
    public interface IIncidentService : IService<Incident>
    {
        bool Archived(string incidentId);
    }
}
