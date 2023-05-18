using Shouldly;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Events;
using SophieTravelManagement.Domain.Exceptions;
using SophieTravelManagement.Domain.Factories;
using SophieTravelManagement.Domain.Policies;
using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.UnitTests.Domain
{
    public class TravelerCheckListTests
    {
        [Fact]
        public void AddItem_Throws_TravelerItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
        {
            //Arrange
            var travelerCheckList = GetTravelerCheckList();
            travelerCheckList.AddItem(new TravelerItem("Item 1", 1));

            //Act
            var exception = Record.Exception(() => travelerCheckList.AddItem(new TravelerItem("Item 1", 1)));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<TravelerItemAlreadyExistsException>();
        }

        public void AddItem_Adds_TravelerItemAdded_Domain_Event_On_Success()
        {
            var travelerCheckList = GetTravelerCheckList();
            var exception = Record.Exception(() => travelerCheckList.AddItem(new TravelerItem("Item 1", 1)));
            exception.ShouldNotBeNull();
            travelerCheckList.Events.Count().ShouldBe(1);
            var @event = travelerCheckList.Events.FirstOrDefault() as TravelerItemAdded;
            @event.ShouldNotBeNull();
            @event.TravelerItem.Name.ShouldBe("Item 1");
        }


        #region ARRANG

        private TravelerCheckList GetTravelerCheckList()
        {
            var travelerCheckList = _factory.Create(Guid.NewGuid(),"MyList",Destination.Create("Shiraz, Iran"));
            travelerCheckList.ClearEvents();
            return travelerCheckList;
        }

        private readonly ITravelerCheckListFactory _factory;

        public TravelerCheckListTests()
        {
            _factory = new TravelerCheckListFactory(Enumerable.Empty<ITravelerItemsPolicy>());
        }

        #endregion
    }


}
