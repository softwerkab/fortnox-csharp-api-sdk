using System.Xml.Serialization;

namespace FortnoxAPILibrary.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "Employee")]
    public class Employee
    {
        /// <summary>
        /// Unique employee-id. Can never be changed once an employee has been created.
        /// Max-length 15.
        /// </summary>
        [XmlElement(ElementName = "EmployeeId")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// Personal identity number
        /// </summary>
        [XmlElement(ElementName = "PersonalIdentityNumber")]
        public string PersonalIdentityNumber { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Full name. Read-only
        /// </summary>
        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [XmlElement(ElementName = "Address1")]
        public string Address1 { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [XmlElement(ElementName = "Address2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Post code
        /// </summary>
        [XmlElement(ElementName = "PostCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [XmlElement(ElementName = "City")]
        public string City { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [XmlElement(ElementName = "Phone1")]
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone number 2
        /// </summary>
        [XmlElement(ElementName = "Phone2")]
        public string Phone2 { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Startdate of employment
        /// </summary>
        [XmlElement(ElementName = "EmploymentDate")]
        public string EmploymentDate { get; set; }

        /// <summary>
        /// Type of employment
        /// </summary>
        [XmlElement(ElementName = "EmploymentForm")]
        public EmployeeEmploymentForm EmploymentForm { get; set; }

        /// <summary>
        /// Type of salary form. Required.
        /// </summary>
        [XmlElement(ElementName = "SalaryForm")]
        public EmployeeSalaryForm SalaryForm { get; set; }

        /// <summary>
        /// Job title
        /// </summary>
        [XmlElement(ElementName = "JobTitle")]
        public string JobTitle { get; set; }

        /// <summary>
        /// Personel type
        /// </summary>
        [XmlElement(ElementName = "PersonelType")]
        public EmployeePersonelType PersonelType { get; set; }

        /// <summary>
        /// Schedule ID for scheduletimes. Max-length 10
        /// </summary>
        [XmlElement(ElementName = "ScheduleId")]
        public string ScheduleId { get; set; }

        /// <summary>
        /// Assigned fora type
        /// </summary>
        [XmlElement(ElementName = "ForaType")]
        public EmployeeForaType ForaType { get; set; }

        /// <summary>
        /// Monthly salary
        /// </summary>
        [XmlElement(ElementName = "MonthlySalary")]
        public double? MonthlySalary { get; set; }

        /// <summary>
        /// Hourly pay
        /// </summary>
        [XmlElement(ElementName = "HourlyPay")]
        public double? HourlyPay { get; set; }

        /// <summary>
        /// Tax allowance
        /// </summary>
        [XmlElement(ElementName = "TaxAllowance")]
        public EmployeeTaxAllowance TaxAllowance { get; set; }

        /// <summary>
        /// Tax table
        /// </summary>
        [XmlElement(ElementName = "TaxTable")]
        public double? TaxTable { get; set; }

        /// <summary>
        /// Tax column
        /// </summary>
        [XmlElement(ElementName = "TaxColumn")]
        public int? TaxColumn { get; set; }

        /// <summary>
        /// Non-recurring tax %
        /// </summary>
        [XmlElement(ElementName = "NonRecurringTax")]
        public double? NonRecurringTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Inactive")]
        public bool Inactive { get; set; }

        /// <summary>
        /// Clearing number
        /// </summary>
        [XmlElement(ElementName = "ClearingNo")]
        public string ClearingNo { get; set; }

        /// <summary>
        /// Bankaccount number
        /// </summary>
        [XmlElement(ElementName = "BankAccountNo")]
        public virtual string BankAccountNo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EmployeeEmploymentForm
    {
        /// <summary>
        /// Post with conditional tenure
        /// </summary>
        [XmlEnum("TV")]
        ConditionalTenure,
        /// <summary>
        /// Probationary appointment
        /// </summary>
        [XmlEnum("PRO")]
        ProbationaryAppointment,
        /// <summary>
        /// Temporary employment
        /// </summary>
        [XmlEnum("TID")]
        TemporaryEmployment,
        /// <summary>
        /// Cover staff
        /// </summary>
        [XmlEnum("VIK")]
        CoverStaff,
        /// <summary>
        /// Project employment
        /// </summary>
        [XmlEnum("PRJ")]
        ProjectEmployment,
        /// <summary>
        /// Work experience
        /// </summary>
        [XmlEnum("PRA")]
        WorkExperience,
        /// <summary>
        /// Holiday work
        /// </summary>
        [XmlEnum("FER")]
        HolidayWork,
        /// <summary>
        /// Seasonal employment
        /// </summary>
        [XmlEnum("SES")]
        SeasonalEmployment,
        /// <summary>
        /// Not employed
        /// </summary>
        [XmlEnum("NEJ")]
        NotEmployed
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EmployeeSalaryForm
    {
        /// <summary>
        /// Monthly salary
        /// </summary>
        [XmlEnum("MAN")]
        MonthlySalary,
        /// <summary>
        /// Hourly pay
        /// </summary>
        [XmlEnum("TIM")]
        HourlyPay
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EmployeePersonelType
    {
        /// <summary>
        /// Salaried employee
        /// </summary>
        [XmlEnum("TJM")]
        SalariedEmployee,
        /// <summary>
        /// Worker
        /// </summary>
        [XmlEnum("ARB")]
        Worker
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EmployeeForaType
    {
        /// <summary>
        /// Not signed
        /// </summary>
        [XmlEnum("-")]
        NotSigned,
        /// <summary>
        /// Worker
        /// </summary>
        [XmlEnum("A")]
        Worker,
        /// <summary>
        /// Workers, Painters
        /// </summary>
        [XmlEnum("A3")]
        WorkersPainters,
        /// <summary>
        /// Worker, Electrician – Installation plant contract
        /// </summary>
        [XmlEnum("A91")]
        WorkerElectricianInstallationPlantContract,
        /// <summary>
        /// Worker, Electrician – Power plant contract
        /// </summary>
        [XmlEnum("A92")]
        WorkerElectricianPowerPlantContract,
        /// <summary>
        /// Worker, Electrician – Elektroskandia contract
        /// </summary>
        [XmlEnum("A93")]
        WorkerElectricianElektroskandiaContract,
        /// <summary>
        /// Worker, Technology Agreement IF Metall
        /// </summary>
        [XmlEnum("A51")]
        WorkerTechnologyAgreementIfMetall,
        /// <summary>
        /// Worker, TEKO Agreement
        /// </summary>
        [XmlEnum("A52")]
        WorkerTekoAgreement,
        /// <summary>
        /// Worker, Food Production Agreement
        /// </summary>
        [XmlEnum("A53")]
        WorkerFoodProductionAgreement,
        /// <summary>
        /// Worker, Tobacco Industry
        /// </summary>
        [XmlEnum("A54")]
        WorkerTobaccoIndustry,
        /// <summary>
        /// Worker, Company Agreement for V&S Vin & Sprit AB
        /// </summary>
        [XmlEnum("A55")]
        WorkerCompanyAgreementForVAndSVinAndSpritAb,
        /// <summary>
        /// Worker, Coffee Roasters and Spice Factories
        /// </summary>
        [XmlEnum("A56")]
        WorkerCoffeeRoastersAndSpiceFactories,
        /// <summary>
        /// Worker, Construction Materials Industry
        /// </summary>
        [XmlEnum("A57")]
        WorkerConstructionMaterialsIndustry,
        /// <summary>
        /// Worker, Bottle Glass Industry
        /// </summary>
        [XmlEnum("A58")]
        WorkerBottleGlassIndustry,
        /// <summary>
        /// Worker, Motor Industry Agreement
        /// </summary>
        [XmlEnum("A59")]
        WorkerMotorIndustryAgreement,
        /// <summary>
        /// Worker, Industry Agreement
        /// </summary>
        [XmlEnum("A60")]
        WorkerIndustryAgreement,
        /// <summary>
        /// Worker, Leather & Sporting Goods
        /// </summary>
        [XmlEnum("A61")]
        WorkerLeatherAndSportingGoods,
        /// <summary>
        /// Worker, Chemical Factories
        /// </summary>
        [XmlEnum("A62")]
        WorkerChemicalFactories,
        /// <summary>
        /// Worker, Glass Industry
        /// </summary>
        [XmlEnum("A63")]
        WorkerGlassIndustry,
        /// <summary>
        /// Worker, Common Metals
        /// </summary>
        [XmlEnum("A64")]
        WorkerCommonMetals,
        /// <summary>
        /// Worker, Explosive Materials Industry
        /// </summary>
        [XmlEnum("A65")]
        WorkerExplosiveMaterialsIndustry,
        /// <summary>
        /// Worker, Allochemical Industry
        /// </summary>
        [XmlEnum("A66")]
        WorkerAllochemicalIndustry,
        /// <summary>
        /// Worker, Recycling Company
        /// </summary>
        [XmlEnum("A67")]
        WorkerRecyclingCompany,
        /// <summary>
        /// Worker, Laundy Industry
        /// </summary>
        [XmlEnum("A68")]
        WorkerLaundyIndustry,
        /// <summary>
        /// Worker, Quarrying Industry
        /// </summary>
        [XmlEnum("A69")]
        WorkerQuarryingIndustry,
        /// <summary>
        /// Worker, Oil Refineries
        /// </summary>
        [XmlEnum("A70")]
        WorkerOilRefineries,
        /// <summary>
        /// Worker, Sugar Industry (Nordic Sugar AB)
        /// </summary>
        [XmlEnum("A71")]
        WorkerSugarIndustryNordicSugarAb,
        /// <summary>
        /// Worker, IMG Agreement
        /// </summary>
        [XmlEnum("A72")]
        WorkerImgAgreement,
        /// <summary>
        /// Worker, Sawmill Agreement
        /// </summary>
        [XmlEnum("A73")]
        WorkerSawmillAgreement,
        /// <summary>
        /// Worker, Forestry Agreement
        /// </summary>
        [XmlEnum("A74")]
        WorkerForestryAgreement,
        /// <summary>
        /// Worker, Scaling of timber
        /// </summary>
        [XmlEnum("A75")]
        WorkerScalingOfTimber,
        /// <summary>
        /// Worker, Upholstery Industry
        /// </summary>
        [XmlEnum("A76")]
        WorkerUpholsteryIndustry,
        /// <summary>
        /// Worker, Wood Industry
        /// </summary>
        [XmlEnum("A77")]
        WorkerWoodIndustry,
        /// <summary>
        /// Salaried employee
        /// </summary>
        [XmlEnum("T")]
        SalariedEmployee,
        /// <summary>
        /// Salaried employee, Employed CEO
        /// </summary>
        [XmlEnum("T6")]
        SalariedEmployeeEmployedCeo
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EmployeeTaxAllowance
    {
        /// <summary>
        /// Main employer
        /// </summary>
        [XmlEnum("HUV")]
        MainEmployer,
        /// <summary>
        /// Extra income or short-time work
        /// </summary>
        [XmlEnum("EXT")]
        ExtraIncomeOrShortTimeWork,
        /// <summary>
        /// Short-time work less than one week
        /// </summary>
        [XmlEnum("TMP")]
        ShortTimeWorkLessThanOneWeek,
        /// <summary>
        /// Student without tax deduction
        /// </summary>
        [XmlEnum("STU")]
        StudentWithoutTaxDeduction,
        /// <summary>
        /// Not tax allowance
        /// </summary>
        [XmlEnum("EJ")]
        NotTaxAllowance,
        /// <summary>
        /// Unknown tax circumstances
        /// </summary>
        [XmlEnum("???")]
        UnknownTaxCircumstances
    }
}
