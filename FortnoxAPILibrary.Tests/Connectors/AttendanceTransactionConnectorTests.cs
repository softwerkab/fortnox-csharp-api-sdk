using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.SDK.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.Connectors
{
    [TestClass]
    public class AttendanceTransactionConnectorTests : ConnectorTestsBase
    {
        readonly IAttendanceTransactionConnector _connector;

        readonly IEmployeeConnector _employeeConnector;

        readonly ICostCenterConnector _costCenterConnector;

        static string NewAttendanceTransactionEmployeeId => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);

        static readonly DateTime NewAttendanceTransactionDate = new DateTime(2020, 10, 28);

        public AttendanceTransactionConnectorTests()
        {
            var authorization = new StandardAuth(AccessToken);
            
            _connector = new AttendanceTransactionConnector
            {
                Authorization = authorization
            };

            _employeeConnector = new EmployeeConnector
            {
                Authorization = authorization
            };

            _costCenterConnector = new CostCenterConnector
            {
                Authorization = authorization
            };
        }

        [TestMethod]
        public void TestConnection()
        {
            _connector.Find();

            CheckForError(_connector);
        }

        [TestMethod]
        public void CreateShouldCreateAnAttendanceTransaction()
        {
            var employee = CreateEmployee();
            var date = NewAttendanceTransactionDate.ToString("yyyy-MM-dd");
            var attendanceTransaction = new AttendanceTransaction
            {
                EmployeeId = employee.EmployeeId,
                Date = date,
                CauseCode = AttendanceCauseCode.ARB,
            };

            var result = _connector.Create(attendanceTransaction);

            CheckForError(_connector);

            Assert.IsNotNull(result.EmployeeId);
            Assert.IsNotNull(result.Date);
            Assert.IsNotNull(result.CauseCode);
            Assert.AreEqual(AttendanceCauseCode.ARB, result.CauseCode);
            Assert.AreEqual(date, result.Date);
        }

        [TestMethod]
        public void UpdateShouldUpdateAnAttendanceTransaction()
        {
            //Arrange
            var employee = CreateEmployee();
            var date = NewAttendanceTransactionDate.AddDays(1).ToString("yyyy-MM-dd");
            var create = new AttendanceTransaction
            {
                EmployeeId = employee.EmployeeId,
                Date = date,
                CauseCode = AttendanceCauseCode.ARB,
            };

            var createResult = _connector.Create(create);
            CheckForError(_connector);

            //Act
            var costCenter = GetExistingCostCenter();
            var update = new AttendanceTransaction
            {
                EmployeeId = employee.EmployeeId,
                Date = date,
                CauseCode = AttendanceCauseCode.ARB,
                CostCenter = costCenter.Code,
            };

            var updateResult = _connector.Update(update);
            CheckForError(_connector);

            //Assert
            Assert.AreEqual(update.CostCenter, updateResult.CostCenter);
        }

        [TestMethod]
        public void GetShouldReturnResult()
        {
            var attendanceTransaction = GetNewOrExistingAttendanceTransaction();
            var result = _connector.Get(attendanceTransaction.EmployeeId, attendanceTransaction.Date, attendanceTransaction.CauseCode);

            CheckForError(_connector);

            Assert.AreEqual(attendanceTransaction.EmployeeId, result.EmployeeId);
        }

        [TestMethod]
        public void FindShouldReturnResults()
        {
            GetNewOrExistingAttendanceTransaction();

            var result = _connector.Find();

            CheckForError(_connector);

            Assert.IsTrue(result.AttendanceTransactionSubset.Any());
        }

        AttendanceTransaction GetNewOrExistingAttendanceTransaction()
        {
            var result = _connector.Find();

            CheckForError(_connector);

            if (result.AttendanceTransactionSubset.Any())
                return result.AttendanceTransactionSubset.First();

            var employee = CreateEmployee();
            var date = NewAttendanceTransactionDate.ToString("yyyy-MM-dd");
            var attendanceTransactionToCreate = new AttendanceTransaction
            {
                EmployeeId = employee.EmployeeId,
                Date = date,
                CauseCode = AttendanceCauseCode.ARB,
            };
            var attendanceTransaction = _connector.Create(attendanceTransactionToCreate);
            CheckForError(_connector);

            return attendanceTransaction;
        }

        Employee CreateEmployee()
        {
            var employedTo = DateTime.UtcNow.AddYears(1).ToString("yyyy-MM-dd");
            var employee = new Employee
            {
                EmployeeId = NewAttendanceTransactionEmployeeId,
                EmployedTo = employedTo,
            };

            var result = _employeeConnector.Create(employee);
            CheckForError(_connector);
            _employeeConnector.Update(new Employee { EmployeeId = employee.EmployeeId, Inactive = true });

            return result;
        }

        CostCenterSubset GetExistingCostCenter()
        {
            var result = _costCenterConnector.Find();
            CheckForError(_connector);

            if (result.CostCenterSubset.Any())
                return result.CostCenterSubset.First();

            var costCenterToCreate = new CostCenter
            {
                Code = "101",
                Description = "101",
            };
            var costCenter = _costCenterConnector.Create(costCenterToCreate);
            CheckForError(_connector);

            return new CostCenterSubset
            {
                Code = costCenter.Code,
            };
        }
    }
}