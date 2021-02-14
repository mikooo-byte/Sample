using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
//Crystal Report References
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

using FinalProject.Reports;

namespace FinalProject.Reports
{
    public class Report
    {
        private ReportClass concrete_rpt;
        private ODBCConfiguration   odbc_config = null;
        private ODBCAccount odbc_account = null;

        public class ContentAndType {
            public byte[] array { get; set; }
            public string contenttype { get; set; }

        }

        public Report(ReportClass rpt) {
            concrete_rpt = rpt;
        }
        private void SetCrystalDatabaseLogOn(ODBCAccount odbc_account) {
            concrete_rpt.SetDatabaseLogon(
                odbc_account.UserName,
                odbc_account.Password,
                odbc_account.ODBCName,
                odbc_account.DatabaseName);
        }

        private void UpdateCrystalODBC(ODBCConfiguration odbc_config,ODBCAccount odbc_account) {
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo = odbc_config.UpdateConnectionInfo(odbc_account);
            for (int i = 0; i < concrete_rpt.Database.Tables.Count; i++) {

                concrete_rpt.Database.Tables[i].ApplyLogOnInfo(tableLogOnInfo);
            }
        }
        public ReportClass CrystalReportConnection() {
            odbc_config = new ODBCConfiguration();
            odbc_account = odbc_config.Get();
            SetCrystalDatabaseLogOn(odbc_account);
            UpdateCrystalODBC(odbc_config,odbc_account);
            return concrete_rpt;
        }

        

        public ContentAndType ConvertCrystalToFormat(string format) {

            MemoryStream oStream = null;
            byte[] arr;
            ContentAndType pdfArr = null;
            try
            {
                oStream = (MemoryStream)concrete_rpt.ExportToStream(ReportFormatFactory.CreateByFormat(format));
                arr = oStream.ToArray();
                pdfArr = new ContentAndType();
                pdfArr.array = arr;
                pdfArr.contenttype = ContentTypeFactory.CreateByFormat(format);
            }
            catch (Exception ex)
            {
                try
                {
                    pdfArr = new ContentAndType();
                    var stream = concrete_rpt.ExportToStream(ReportFormatFactory.CreateByFormat(format));
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        pdfArr.array = br.ReadBytes((int)stream.Length);
                    }
                    pdfArr.contenttype = ContentTypeFactory.CreateByFormat(format);
                }
                catch (Exception exc)
                {

                    throw new Exception(exc.Message);
                }
            }
            finally {
                concrete_rpt.Close();
                concrete_rpt.Dispose();
                if (oStream != null) {
                    oStream.Close();
                    oStream.Dispose();
                }

            }
            return pdfArr;

        }
    }
}