using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FortnoxAPILibrary.Connectors
{

    /// <remarks/>
    public class Selection
    {
        /// <remarks/>
        public string VoucherSeries { get; set; }
        /// <remarks/>
        public string FromVoucherNumber { get; set; }
        /// <remarks/>
        public string ToVoucherNumber { get; set; }
    }

    /// <remarks/>
    public class ImportOptions
    {
        /// <remarks/>
        public bool AllAccounts;
        /// <remarks/>
        public bool AllCostCenters;
        /// <remarks/>
        public bool AllProjects;
        /// <remarks/>
        public bool UseCostCenterDescription;
        /// <remarks/>
        public bool UseProjectDescription;
        /// <remarks/>
        public bool UseSRU;
        /// <remarks/>
        public bool UseIncomingBalance;
        /// <remarks/>
        public bool UseBudget;
        /// <remarks/>
        public List<Selection> Selection;
    }

    /// <remarks/>
    public class ExportOptions
    {
        /// <remarks/>
        public bool ExportAll;
        /// <remarks/>
        public List<Selection> Selection;
        /// <remarks/>
        public string FromDate;
        /// <remarks/>
        public string ToDate;
    }


    public interface ISIEConnector : IFinancialYearBasedEntityConnector<SieSummary, SieSummary, Sort.By.Sie>
    {
        /// <remarks/>
        ImportOptions ImportOptions { get; set; }

        /// <remarks/>
        ExportOptions ExportOptions { get; set; }

        /// <summary>
        /// Export SIE to a string
        /// </summary>
        /// <param name="sieType">The type of SIE to export</param>
        /// <returns>SIE</returns>
        byte[] ExportSIE(SIEConnector.SIEType sieType);

        /// <summary>
        /// Export SIE to a file
        /// </summary>
        /// <param name="sieType">The type of SIE to export</param>
        /// <param name="localPath">Path to sie-file</param>
        void ExportSIE(SIEConnector.SIEType sieType, string localPath);

        /// <summary>
        /// Imports a SIE file
        /// </summary>
        /// <param name="pathToFile">The local path to the file to import</param>
        /// <param name="preview">Set to true to perform a preview of the import. Nothing will be imported.</param>
        /// <returns>A summary of what is beeing imported. </returns>
        SieSummary ImportSIE(string pathToFile, bool preview = false);
    }

    /// <remarks/>
    public class SIEConnector : FinancialYearBasedEntityConnector<SieSummary, SieSummary, Sort.By.Sie>, ISIEConnector
    {
        /// <remarks/>
        public enum SIEType
        {
            /// <remarks/>
            SIE1 = 1,
            /// <remarks/>
            SIE2 = 2,
            /// <remarks/>
            SIE3 = 3,
            /// <remarks/>
            SIE4 = 4
        }

        /// <remarks/>
        public ImportOptions ImportOptions { get; set; }
        /// <remarks/>
        public ExportOptions ExportOptions { get; set; }

        /// <remarks/>
        public SIEConnector()
        {
            base.Resource = "sie";
            ImportOptions = new ImportOptions();
            ExportOptions = new ExportOptions();
        }

        /// <summary>
        /// Export SIE to a string
        /// </summary>
        /// <param name="sieType">The type of SIE to export</param>
        /// <returns>SIE</returns>
        public byte[] ExportSIE(SIEType sieType)
        {
            return Export(sieType);
        }

        /// <summary>
        /// Export SIE to a file
        /// </summary>
        /// <param name="sieType">The type of SIE to export</param>
        /// <param name="localPath">Path to sie-file</param>
        public void ExportSIE(SIEType sieType, string localPath)
        {
            Export(sieType, localPath);
        }

        private byte[] Export(SIEType sieType, string localPath = "")
        {
            base.Resource = "sie/" + (int)sieType;
            string requestString = base.GetUrl();

            this.Parameters = new Dictionary<string, string>();

            AddCustomParameters();

            AddExportOptions();

            requestString = base.AddParameters(requestString);

            HttpWebRequest wr = base.SetupRequest(requestString, "GET");

            List<byte> data = new List<byte>();

            try
            {
                using (WebResponse response = wr.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        int b;

                        if (localPath != "")
                        {
                            using (var writer = new FileStream(localPath, FileMode.Create))
                            {
                                while ((b = responseStream.ReadByte()) != -1)
                                {
                                    writer.WriteByte((byte)b);
                                }
                            }
                        }
                        else
                        {
                            while ((b = responseStream.ReadByte()) != -1)
                            {
                                data.Add((byte)b);
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                Error = base.HandleException(we);
            }

            return data.ToArray();
        }

        /// <summary>
        /// Imports a SIE file
        /// </summary>
        /// <param name="pathToFile">The local path to the file to import</param>
        /// <param name="preview">Set to true to perform a preview of the import. Nothing will be imported.</param>
        /// <returns>A summary of what is beeing imported. </returns>
        public SieSummary ImportSIE(string pathToFile, bool preview = false)
        {
            if (string.IsNullOrEmpty(pathToFile))
            {
                throw new Exception("A file to import must be selected");
            }

            if (preview)
            {
                base.Resource = "sie/preview";
            }
            else
            {
                base.Resource = "sie";
            }
            List<string> parameters = new List<string>();
            AddImportOptions(parameters);

            return base.BaseUploadFile(pathToFile);
        }

        private void AddExportOptions()
        {
            if (this.ExportOptions.Selection != null && this.ExportOptions.Selection.Count > 0)
            {
                string sel = "";

                foreach (Selection selection in this.ExportOptions.Selection)
                {
                    if (!string.IsNullOrEmpty(selection.VoucherSeries))
                    {
                        if (sel != "")
                        {
                            sel += ";";
                        }

                        sel += selection.VoucherSeries;

                        if (!string.IsNullOrEmpty(selection.FromVoucherNumber) && !string.IsNullOrEmpty(selection.ToVoucherNumber))
                        {
                            sel += "," + selection.FromVoucherNumber + "," + selection.ToVoucherNumber;
                        }
                    }
                }

                this.Parameters.Add("selection", sel);
            }

            if (ExportOptions.ExportAll)
            {
                this.Parameters.Add("exportall", "true");
            }

            if (!string.IsNullOrEmpty(this.ExportOptions.FromDate))
            {
                this.Parameters.Add("fromdate", this.ExportOptions.FromDate);
            }

            if (!string.IsNullOrEmpty(ExportOptions.ToDate))
            {
                this.Parameters.Add("todate", this.ExportOptions.ToDate);
            }
        }

        private void AddImportOptions(List<string> parameters)
        {
            if (ImportOptions.Selection != null && ImportOptions.Selection.Count > 0)
            {
                string selection = "selection=";

                foreach (Selection currentSelection in ImportOptions.Selection)
                {
                    if (!string.IsNullOrEmpty(currentSelection.VoucherSeries))
                    {

                        if (selection != "selection=")
                        {
                            selection += ";";
                        }
                        selection += currentSelection.VoucherSeries;

                        if (!string.IsNullOrEmpty(currentSelection.FromVoucherNumber) && !string.IsNullOrEmpty(currentSelection.ToVoucherNumber))
                        {
                            selection += "," + currentSelection.FromVoucherNumber + "," + currentSelection.ToVoucherNumber;
                        }
                    }
                }
                parameters.Add(selection);
            }

            if (ImportOptions.AllAccounts)
            {
                parameters.Add("allaccounts=true");
            }

            if (ImportOptions.AllCostCenters)
            {
                parameters.Add("allcostcenters=true");
            }

            if (ImportOptions.AllProjects)
            {
                parameters.Add("allprojects=true");
            }

            if (ImportOptions.UseBudget)
            {
                parameters.Add("usebudget=true");
            }

            if (ImportOptions.UseCostCenterDescription)
            {
                parameters.Add("usecostcenterdescription=true");
            }

            if (ImportOptions.UseIncomingBalance)
            {
                parameters.Add("useincomingbalance=true");
            }

            if (ImportOptions.UseProjectDescription)
            {
                parameters.Add("useprojectdescription=true");
            }

            if (ImportOptions.UseSRU)
            {
                parameters.Add("usesru=true");
            }
        }
    }
}
