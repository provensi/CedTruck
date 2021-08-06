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
    public class TruckControllerUnitTest
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

        [Fact]
        public void TruckControllerIndexHaveTrucks()
        {
            // Arrange
            var currentYear = DateTime.Now.Year;
            var mockTrucks = new List<Truck>()
            {
                new Truck() { Id = 1, ModelId = 1, YearFabrication = currentYear, YearModel = currentYear }
            };

            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetAll()).Returns(mockTrucks);

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockTrucksService.Verify(x => x.GetAll(), Times.Once());
        }

        [Fact]
        public void TruckControllerDetailsNoTruck()
        {
            // Arrange
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetById(1)).Returns<Truck>(null);

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void TruckControllerDetailsHasTruck()
        {
            // Arrange
            var currentYear = DateTime.Now.Year;
            var mockTruck = new Truck() { Id = 1, ModelId = 1, YearFabrication = currentYear, YearModel = currentYear };
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetById(1)).Returns(mockTruck);

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockTrucksService.Verify(x => x.GetById(1), Times.Once());
        }

        [Fact]
        public void TruckControllerEditNoTruck()
        {
            // Arrange
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetById(1)).Returns<Truck>(null);

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void TruckControllerEditHasTruck()
        {
            // Arrange
            var currentYear = DateTime.Now.Year;
            var mockTruck = new Truck() { Id = 1, ModelId = 1, YearFabrication = currentYear, YearModel = currentYear };
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetById(1)).Returns(mockTruck);

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockTrucksService.Verify(x => x.GetById(1), Times.Once());
        }

        [Fact]
        public void TruckControllerDeleteNoTruck()
        {
            // Arrange
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetById(1)).Returns<Truck>(null);

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void TruckControllerDeleteHasTruck()
        {
            // Arrange
            var currentYear = DateTime.Now.Year;
            var mockTruck = new Truck() { Id = 1, ModelId = 1, YearFabrication = currentYear, YearModel = currentYear };
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetById(1)).Returns(mockTruck);

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
            mockTrucksService.Verify(x => x.GetById(1), Times.Once());
        }

        [Fact]
        public void TruckControllerCreateTruck()
        {
            // Arrange
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.GetAllTruckModels()).Returns(new List<TruckModel>());

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public void TruckControllerDeleteConfirmed()
        {
            // Arrange
            var mockTrucksService = new Mock<ITrucksService>();
            mockTrucksService.Setup(x => x.DeleteById(1)).Verifiable();

            var controller = new TrucksController(null, mockTrucksService.Object);

            // Act
            var result = controller.DeleteConfirmed(1);

            // Assert
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            mockTrucksService.Verify(x => x.DeleteById(1), Times.Once());
        }
    }
}
