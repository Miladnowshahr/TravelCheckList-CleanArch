using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF.Models
{
    public class TravelerCheckListReadModel
    {
        public Guid Id { get; set; }    
        public string Name { get;set; }
        public Destination? Destination { get; set; }
    }
}
