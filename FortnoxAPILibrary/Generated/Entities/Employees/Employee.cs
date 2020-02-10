using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Employee", PluralName = "Employees")]
    public class Employee
    {

        ///<summary> Unique employee-id. Can never be changed once an employee has been created </summary>
        [JsonProperty]
        public string EmployeeId { get; set; }

        ///<summary> Personal identity number </summary>
        [JsonProperty]
        public string PersonalIdentityNumber { get; set; }

        ///<summary> First name </summary>
        [JsonProperty]
        public string FirstName { get; set; }

        ///<summary> Last name </summary>
        [JsonProperty]
        public string LastName { get; set; }

        ///<summary> Full name </summary>
        [ReadOnly]
        [JsonProperty]
        public string FullName { get; private set; }

        ///<summary> Address </summary>
        [JsonProperty]
        public string Address1 { get; set; }

        ///<summary> Address </summary>
        [JsonProperty]
        public string Address2 { get; set; }

        ///<summary> Post code </summary>
        [JsonProperty]
        public string PostCode { get; set; }

        ///<summary> City </summary>
        [JsonProperty]
        public string City { get; set; }

        ///<summary> Country </summary>
        [JsonProperty]
        public string Country { get; set; }

        ///<summary> Phone number </summary>
        [JsonProperty]
        public string Phone1 { get; set; }

        ///<summary> Phone number 2 </summary>
        [JsonProperty]
        public string Phone2 { get; set; }

        ///<summary> Email address </summary>
        [JsonProperty]
        public string Email { get; set; }

        ///<summary> Startdate of employment </summary>
        [JsonProperty]
        public DateTime? EmploymentDate { get; set; }

        ///<summary> Type of employment. Validates against allowed values specified below. </summary>
        [JsonProperty]
        public string EmploymentForm { get; set; }

        ///<summary> Type of salary form. Validates against allowed values specified below. </summary>
        [JsonProperty]
        public string SalaryForm { get; set; }

        ///<summary> Job title </summary>
        [JsonProperty]
        public string JobTitle { get; set; }

        ///<summary> Personel type. Validates against allowed values specified below. </summary>
        [JsonProperty]
        public string PersonelType { get; set; }

        ///<summary> True if employee is inactive </summary>
        [JsonProperty]
        public bool? Inactive { get; set; }

        ///<summary> Schedule ID for scheduletimes </summary>
        [JsonProperty]
        public string ScheduleId { get; set; }

        ///<summary> Assigned fora type. Validates against allowed values specified below. </summary>
        [JsonProperty]
        public string ForaType { get; set; }

        ///<summary> Monthly salary </summary>
        [JsonProperty]
        public double? MonthlySalary { get; set; }

        ///<summary> Hourly pay </summary>
        [JsonProperty]
        public double? HourlyPay { get; set; }

        ///<summary> Tax allowance. Validates against allowed values specified below. </summary>
        [JsonProperty]
        public string TaxAllowance { get; set; }

        ///<summary> Tax table </summary>
        [JsonProperty]
        public double? TaxTable { get; set; }

        ///<summary> Tax column </summary>
        [JsonProperty]
        public int? TaxColumn { get; set; }

        ///<summary> Non-recurring tax % </summary>
        [JsonProperty]
        public double? NonRecurringTax { get; set; }

        ///<summary> Clearing number </summary>
        [JsonProperty]
        public string ClearingNo { get; set; }

        ///<summary> Bankaccount number </summary>
        [JsonProperty]
        public string BankAccountNo { get; set; }

        ///<summary> Average weekly hours </summary>
        [JsonProperty]
        public double? AverageWeeklyHours { get; set; }

        ///<summary> Average hourly wage </summary>
        [JsonProperty]
        public double? AverageHourlyWage { get; set; }
    }
}