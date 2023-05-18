using SophieTravelManagement.Application.DTO;
using SophieTravelManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static TravelerCheckListDto AsDto(this TravelerCheckListReadModel readModel)
        {
            return new TravelerCheckListDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Destination = new DestinationDto
                {
                    City = readModel.Destination?.City,
                    Country = readModel.Destination?.Country,
                },
                Items = readModel.Items?.Select(s => new TravelerItemDto
                {
                    Name = s.Name,
                    Qunatity = s.Quantity,
                    IsTaken = s.IsTaken,
                })
            };
        }
    }
}
