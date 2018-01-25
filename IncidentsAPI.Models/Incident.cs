using System;

namespace IncidentsAPI.Models
{
    public class Incident
    {
        public string _id { get; set; }
        public Kinds kind { get; set; }
        public string locationId { get; set; }
        public DateTime happenedAt { get; set; }
        public bool isArchived { get; set; }
    }
}
