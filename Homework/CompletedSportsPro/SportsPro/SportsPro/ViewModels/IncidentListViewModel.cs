using SportsPro.Models;

namespace SportsPro.ViewModels
{
    public class IncidentListViewModel
    {
        public string Filter { get; set; }
        public IEnumerable<Incident> Incidents { get; set; }
    }
}
