using Fortnox.SDK.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Fortnox.SDK.Entities;

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

    ///<summary> Project number. </summary>
    [JsonProperty]
    public string Project { get; set; }

    ///<summary> City </summary>
    [JsonProperty]
    public string City { get; set; }
    
    ///<summary> Cost center </summary>
    [JsonProperty]
    public string CostCenter { get; set; }

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
    public EmploymentForm? EmploymentForm { get; set; }

    ///<summary> Type of salary form. Validates against allowed values specified below. </summary>
    [JsonProperty]
    public SalaryForm? SalaryForm { get; set; }

    ///<summary> Job title </summary>
    [JsonProperty]
    public string JobTitle { get; set; }

    ///<summary> Personnel type. Validates against allowed values specified below. </summary>
    [JsonProperty]
    public PersonelType PersonelType { get; set; }

    ///<summary> True if employee is inactive </summary>
    [JsonProperty]
    public bool? Inactive { get; set; }

    ///<summary> Schedule ID for scheduletimes </summary>
    [JsonProperty]
    public string ScheduleId { get; set; }

    ///<summary> Assigned fora type. Validates against allowed values specified below. </summary>
    [JsonProperty]
    public ForaType? ForaType { get; set; }

    ///<summary> Monthly salary </summary>
    [JsonProperty]
    public decimal? MonthlySalary { get; set; }

    ///<summary> Hourly pay </summary>
    [JsonProperty]
    public decimal? HourlyPay { get; set; }

    ///<summary> Tax allowance. Validates against allowed values specified below. </summary>
    [JsonProperty]
    public TaxAllowance? TaxAllowance { get; set; }

    ///<summary> Tax table </summary>
    [JsonProperty]
    public decimal? TaxTable { get; set; }

    ///<summary> Tax column </summary>
    [JsonProperty]
    public long? TaxColumn { get; set; }

    ///<summary> Non-recurring tax % </summary>
    [JsonProperty]
    public decimal? NonRecurringTax { get; set; }

    ///<summary> Clearing number </summary>
    [JsonProperty]
    public string ClearingNo { get; set; }

    ///<summary> Bankaccount number </summary>
    [JsonProperty]
    public string BankAccountNo { get; set; }

    ///<summary> Average weekly hours </summary>
    [JsonProperty]
    public decimal? AverageWeeklyHours { get; set; }

    ///<summary> Average hourly wage </summary>
    [JsonProperty]
    public decimal? AverageHourlyWage { get; set; }

    [JsonProperty]
    public DateTime? EmployedTo { get; set; }

    [JsonProperty]
    public IList<EmployeeChild> EmployeeChildren { get; set; }

    [JsonProperty]
    public bool? AutoNonRecurringTax { get; set; }

    ///<summary> List of dated wages </summary>
    [JsonProperty]
    public IList<DatedWage> DatedWages { get; set; }

    ///<summary> List of dated schedules </summary>
    [JsonProperty]
    public IList<DatedSchedule> DatedSchedules { get; set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingPaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingPrepaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingSaved { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingSavedYear1 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingSavedYear2 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingSavedYear3 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingSavedYear4 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingSavedYear5 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingSavedYear6Plus { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPendingUnpaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysPrepaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredPaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredPrepaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredSaved { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredSavedYear1 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredSavedYear2 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredSavedYear3 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredSavedYear4 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredSavedYear5 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredSavedYear6Plus { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysRegisteredUnpaid { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSaved { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedEmploymentRateYear1 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedEmploymentRateYear2 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedEmploymentRateYear3 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedEmploymentRateYear4 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedEmploymentRateYear5 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedEmploymentRateYear6Plus { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedYear1 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedYear2 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedYear3 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedYear4 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedYear5 { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysSavedYear6Plus { get; private set; }

    [ReadOnly]
    [JsonProperty]
    public decimal? VacationDaysUnpaid { get; private set; }
}