using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.Connectors
{
    [TestClass]
    public class SalaryTransactionsConnectorTests : ConnectorTestsBase
    {
        readonly ISalaryTransactionsConnector _connector;

        public SalaryTransactionsConnectorTests()
        {
            _connector = new SalaryTransactionsConnector
            {
                AccessToken = AccessToken,
                ClientSecret = ClientSecret
            };
        }

        [TestMethod]
        public void TestConnection()
        {
            _connector.Find();

            CheckForError(_connector);
        }

        [TestMethod]
        public void CreateShouldCreateASalaryTransaction()
        {
            var employeeId = GetEmployeeId();

            var transaction = new SalaryTransaction
            {
                EmployeeId = employeeId,
                SalaryCode = "115",
                Date = "2018-10-16"
            };

            var result = _connector.Create(transaction);
            
            CheckForError(_connector);

            Assert.AreEqual(transaction.EmployeeId, result.EmployeeId);
            Assert.AreEqual(transaction.SalaryCode, result.SalaryCode);
            Assert.AreEqual(transaction.Date, result.Date);
            Assert.IsNotNull(result.SalaryRow);

            _connector.Delete(result.SalaryRow.Value);
        }

        [TestMethod]
        public void UpdateShouldUpdateASalaryTransaction()
        {
            //Arrange
            var employeeId = GetEmployeeId();

            var create = new SalaryTransaction
            {
                EmployeeId = employeeId,
                SalaryCode = "115",
                Date = "2018-10-16"
            };

            var createResult = _connector.Create(create);
            CheckForError(_connector);

            //Act
            var update = new SalaryTransaction
            {
                SalaryRow = createResult.SalaryRow,
                Amount = 50,
                Date = "2018-10-16"
            };

            var updateResult = _connector.Update(update);
            CheckForError(_connector);

            //Assert
            Assert.AreEqual(create.EmployeeId, updateResult.EmployeeId);
            Assert.AreEqual(create.SalaryCode, updateResult.SalaryCode);
            Assert.AreEqual(update.Amount, updateResult.Amount);
            Assert.IsNotNull(createResult.SalaryRow);

            //Cleanup
            _connector.Delete(createResult.SalaryRow.Value);
        }

        [TestMethod]
        public void GetShouldReturnResult()
        {
            var salaryTransactionId = GetSalaryTransactionId();

            var result = _connector.Get(salaryTransactionId);

            CheckForError(_connector);

            Assert.IsTrue(result.SalaryRow.HasValue);
            Assert.AreEqual(salaryTransactionId, result.SalaryRow.Value);
        }

        [TestMethod]
        public void DeleteShouldDeleteTransaction()
        {
            var salaryTransaction = CreateSalaryTransaction();

            // ReSharper disable once PossibleInvalidOperationException
            var salaryRowValue = salaryTransaction.SalaryRow.Value;
            _connector.Delete(salaryRowValue);

            CheckForError(_connector);

            _connector.Get(salaryRowValue);
            Assert.IsTrue(_connector.HasError);
            Assert.AreEqual("2000432", _connector.Error.Code);
        }

        [TestMethod]
        public void FindShouldReturnResults()
        {
            EnsureSomeSalaryTransactionExists();

            var result = _connector.Find();

            CheckForError(_connector);

            Assert.IsTrue(result.SalaryTransactionSubset.Any());
        }

        void EnsureSomeSalaryTransactionExists()
        {
            GetSalaryTransactionId();
        }

        static string GetEmployeeId()
        {
            var employeeConnector = new EmployeeConnector
            {
                AccessToken = AccessToken,
                ClientSecret = ClientSecret
            };

            var result = employeeConnector.Find();

            CheckForError(employeeConnector);

            if (result.EmployeeSubset.Any())
                return result.EmployeeSubset.First().EmployeeId;

            var employee = employeeConnector.Create(new Employee());

            CheckForError(employeeConnector);

            return employee.EmployeeId;
        }

        int GetSalaryTransactionId()
        {
            var findResult = _connector.Find();

            CheckForError(_connector);

            if (findResult.SalaryTransactionSubset.Any())
                return findResult.SalaryTransactionSubset.First().SalaryRow;

            var createResult = CreateSalaryTransaction();

            // ReSharper disable once PossibleInvalidOperationException
            return createResult.SalaryRow.Value;
        }

        SalaryTransaction CreateSalaryTransaction()
        {
            var employeeId = GetEmployeeId();

            var createResult = _connector.Create(new SalaryTransaction
            {
                EmployeeId = employeeId,
                SalaryCode = "115",
                Date = "2018-10-16"
            });

            CheckForError(_connector);
            return createResult;
        }
    }
}
