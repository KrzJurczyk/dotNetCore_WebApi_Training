using HotelRooms_REST_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HotelRooms_WbApi.Test.UnitTests
{
    public class RoomController
    {
        [Fact]
        public async Task CanBeCancelledBy_Admin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Room();
            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            // Assert

            // 3 spososby zapisywania w NUnit
            // Assert.IsTrue(result);
            // Assert.That(result == true);
            Assert.That(result, Is.True);
        }
    }
}
