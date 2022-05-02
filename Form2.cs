using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YLWService;

namespace YLWEDITransLina
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ReadFiles();
        }

        public void ReadFiles()
        {
            string inpath = YLWServiceModule.GetInPath();
            YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
            security.serviceId = "Metro.Package.AdjSL.BisAdjSLEDITransLina";
            security.methodId = "in";

            DataSet ds = new DataSet("ROOT");
            DataTable dt = ds.Tables.Add("DataBlock1");

            dt.Columns.Add("companyseq");
            dt.Columns.Add("send_type");
            dt.Columns.Add("success_fg");
            dt.Columns.Add("cust_code");
            dt.Columns.Add("trans_dtm");
            dt.Columns.Add("edi_text");
            dt.Columns.Add("remain");

            try
            {
                if (!Directory.Exists(inpath)) Directory.CreateDirectory(inpath);
                var files = Directory.GetFiles(inpath, "*.dat");
                foreach (var file in files)
                {
                    string editext = "";
                    using (StreamReader str = new StreamReader(file, Encoding.Default))
                    {
                        editext = str.ReadToEnd();
                    }

                    dt.Clear();
                    DataRow dr = dt.Rows.Add();

                    dr["companyseq"] = security.companySeq;
                    dr["send_type"] = 0;
                    dr["success_fg"] = 0;
                    dr["cust_code"] = "CAI";
                    dr["edi_text"] = editext;

                    DataSet yds = MTRServiceModule.CallMTRServiceCallPost(security, ds);
                    //DataSet yds = YLWDBService.CallYlwServiceCallPost(security, ds);   //시뮬레이션용
                    if (yds != null)
                    {
                        DataTable dataBlock1 = yds.Tables["DataBlock1"];
                        if (dataBlock1 != null && dataBlock1.Rows.Count > 0)
                        {
                            if (dataBlock1.Rows[0]["success_fg"] + "" == "1")
                            {
                                File.Delete(file);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                YLWService.LogWriter.WriteLog(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int rtn = 1;
            while (rtn > 0)
            {
                rtn = WriteFiles();
            }
        }

        public int WriteFiles()
        {
            string outpath = YLWServiceModule.GetOutPath();
            YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
            security.serviceId = "Metro.Package.AdjSL.BisAdjSLEDITransLina";
            security.methodId = "out";

            DataSet ds = new DataSet("ROOT");
            DataTable dt = ds.Tables.Add("DataBlock1");

            dt.Columns.Add("companyseq");
            dt.Columns.Add("send_type");
            dt.Columns.Add("success_fg");
            dt.Columns.Add("cust_code");
            dt.Columns.Add("edi_id");

            dt.Clear();
            DataRow dr = dt.Rows.Add();

            dr["companyseq"] = security.companySeq;
            dr["send_type"] = 1;
            dr["success_fg"] = 0;
            dr["cust_code"] = "CAI";

            DataSet yds = MTRServiceModule.CallMTRServiceCallPost(security, ds);
            if (yds != null && yds.Tables.Count > 0)
            {
                if (yds.Tables.Contains("ErrorMessage")) throw new Exception(yds.Tables["ErrorMessage"].Rows[0]["Message"].ToString());
                DataTable dataBlock1 = yds.Tables["DataBlock1"];
                if (dataBlock1 != null && dataBlock1.Rows.Count > 0)
                {
                    try
                    {
                        if (!Directory.Exists(outpath)) Directory.CreateDirectory(outpath);
                        string fileName = "tolina_" + dataBlock1.Rows[0]["edi_trans_dtm"] + "_" + dataBlock1.Rows[0]["tr_cs_code"] + "_0";
                        string file = outpath + "/" + fileName;
                        if (File.Exists(file)) File.Delete(file);
                        FileStream fs = new FileStream(file, FileMode.CreateNew, FileAccess.Write);
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("euc-kr")))
                        {
                            sw.Write(dataBlock1.Rows[0]["edi_text"]);
                            sw.Close();
                        }
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        YLWService.LogWriter.WriteLog(ex.Message);
                        return 0;
                    }
                    dr["edi_id"] = dataBlock1.Rows[0]["edi_id"];

                    security.methodId = "commit";
                    yds = MTRServiceModule.CallMTRServiceCallPost(security, ds);
                    if (yds != null && yds.Tables.Count > 0)
                    {
                        if (yds.Tables.Contains("ErrorMessage")) throw new Exception(yds.Tables["ErrorMessage"].Rows[0]["Message"].ToString());
                        DataTable inBlock1 = yds.Tables["DataBlock1"];
                        if (inBlock1 != null) return Convert.ToInt32(inBlock1.Rows[0]["remain"]);
                        return 0;
                    }
                }
            }
            return 0;
        }

        private void btnResponse_Click(object sender, EventArgs e)
        {
            string inpath = YLWServiceModule.GetResposePath();
            YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
            security.serviceId = "Metro.Package.AdjSL.BisAdjSLEDITransLina";
            security.methodId = "response";

            DataSet ds = new DataSet("ROOT");
            DataTable dt = ds.Tables.Add("DataBlock1");

            dt.Columns.Add("companyseq");
            dt.Columns.Add("send_type");
            dt.Columns.Add("success_fg");
            dt.Columns.Add("cust_code");
            dt.Columns.Add("trans_dtm");
            dt.Columns.Add("edi_text");
            dt.Columns.Add("remain");

            try
            {
                if (!Directory.Exists(inpath)) Directory.CreateDirectory(inpath);
                var files = Directory.GetFiles(inpath, "*.dat");
                foreach (var file in files)
                {
                    string editext = "";
                    using (StreamReader str = new StreamReader(file, Encoding.Default))
                    {
                        editext = str.ReadToEnd();
                    }

                    dt.Clear();
                    DataRow dr = dt.Rows.Add();

                    dr["companyseq"] = security.companySeq;
                    dr["send_type"] = 0;
                    dr["success_fg"] = 0;
                    dr["cust_code"] = "CAI";
                    dr["edi_text"] = editext;

                    DataSet yds = MTRServiceModule.CallMTRServiceCallPost(security, ds);
                    //DataSet yds = YLWDBService.CallYlwServiceCallPost(security, ds);   //시뮬레이션용
                    if (yds != null)
                    {
                        DataTable dataBlock1 = yds.Tables["DataBlock1"];
                        if (dataBlock1 != null && dataBlock1.Rows.Count > 0)
                        {
                            if (dataBlock1.Rows[0]["success_fg"] + "" == "1")
                            {
                                File.Delete(file);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                YLWService.LogWriter.WriteLog(ex.Message);
            }
        }
    }
}
