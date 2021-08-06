using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CedTruck;
using CedTruck.Controllers;
using CedTruck.Models;
using CedTruck.Services.Interfaces;
using CedTruck.Validators;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace XUnit.CedTruck.Tests
{
    public class TruckServiceUnitTest
    {
        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }


        [Fact]
        public void TruckControllerIndexNoTrucks()
        {
            // Arrange
            //var mockTrucksDataContext = new Mock<DataContext>();
            //mockTrucksDataContext.Setup(x => x.Trucks).Returns(GetQueryableMockDbSet<Truck>(new List<Truck>()));

            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetAll()).Returns(new List<Truck>());

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockTrucksService.Verify(x => x.GetAll(), Times.Once());
        }

    }
}
