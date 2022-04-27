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
    public partial class frmTransLina : Form
    {
        string getFilePath = "";
        string getFileTempPath = "";

        string attachPath = "";
        string attachTempPath = "";
        string fileDownPath = "";

        public frmTransLina()
        {
            InitializeComponent();

            this.Load += FrmTransLina_Load;
            this.Shown += FrmTransLina_Shown;

            this.tmrUp.Tick += TmrUp_Tick;
            this.tmrDown.Tick += TmrDown_Tick;
            this.tmrResponse.Tick += TmrResponse_Tick;
            this.tmrUpAttach.Tick += TmrUpAttach_Tick;

            this.chkUpStop.Click += ChkUpStop_Click;
            this.chkDownStop.Click += ChkDownStop_Click;
            this.chkResponseStop.Click += ChkResponseStop_Click;
            this.chkUpAttachStop.Click += ChkUpAttachStop_Click;
        }

        private void FrmTransLina_Shown(object sender, EventArgs e)
        {
            this.tmrUp.Enabled = true;
            this.tmrDown.Enabled = true;
            this.tmrResponse.Enabled = true;
            this.tmrUpAttach.Enabled = true;
        }

        private void FrmTransLina_Load(object sender, EventArgs e)
        {
            getFilePath = YLWServiceModule.GetGetfilePath();
            getFileTempPath = Path.Combine(getFilePath, "Temp");

            attachPath = YLWServiceModule.GetSendfilePath();
            attachTempPath = Path.Combine(attachPath, "Temp");
            fileDownPath = Path.Combine(attachTempPath, "file_down");
        }

        private void ChkUpStop_Click(object sender, EventArgs e)
        {
            tmrUp.Enabled = !chkUpStop.Checked;
        }

        private void ChkDownStop_Click(object sender, EventArgs e)
        {
            tmrDown.Enabled = !chkDownStop.Checked;
        }

        private void ChkResponseStop_Click(object sender, EventArgs e)
        {
            tmrResponse.Enabled = !chkResponseStop.Checked;
        }

        private void ChkUpAttachStop_Click(object sender, EventArgs e)
        {
            tmrUpAttach.Enabled = !chkUpAttachStop.Checked;
        }

        static int upTime = 0;
        private void TmrUp_Tick(object sender, EventArgs e)
        {
            try
            {
                upTime -= 1;
                if (upTime < 1)
                {
                    txtUpMsg.Text = "";
                    tmrUp.Enabled = false;
                    ReadFiles();
                    upTime = 60;
                    tmrUp.Enabled = true;
                }
                txtUp.Text = upTime.ToString();
            }
            catch (Exception ex)
            {
                tmrUp.Enabled = true;
                //MessageBox.Show(ex.Message);
                YLWService.LogWriter.WriteLog(ex.Message);
                txtUpMsg.Text = ex.Message;
            }
        }

        static int downTime = 0;
        private void TmrDown_Tick(object sender, EventArgs e)
        {
            try
            {
                downTime -= 1;
                if (downTime < 1)
                {
                    txtDownMsg.Text = "";
                    tmrDown.Enabled = false;
                    int rtn = 1;
                    while (rtn > 0)
                    {
                        rtn = WriteFiles();
                        Application.DoEvents();
                        Application.DoEvents();
                    }
                    downTime = 60;
                    tmrDown.Enabled = true;
                }
                txtDown.Text = downTime.ToString();
            }
            catch (Exception ex)
            {
                tmrDown.Enabled = true;
                //MessageBox.Show(ex.Message);
                YLWService.LogWriter.WriteLog(ex.Message);
                txtDownMsg.Text = ex.Message;
            }
        }

        static int responseTime = 0;
        private void TmrResponse_Tick(object sender, EventArgs e)
        {
            try
            {
                responseTime -= 1;
                if (responseTime < 1)
                {
                    txtResponseMsg.Text = "";
                    tmrResponse.Enabled = false;
                    ResponseFile();
                    responseTime = 60;
                    tmrResponse.Enabled = true;
                }
                txtResponse.Text = responseTime.ToString();
            }
            catch (Exception ex)
            {
                tmrResponse.Enabled = true;
                //MessageBox.Show(ex.Message);
                YLWService.LogWriter.WriteLog(ex.Message);
                txtResponseMsg.Text = ex.Message;
            }
        }

        static int attachTime = 0;
        private void TmrUpAttach_Tick(object sender, EventArgs e)
        {
            try
            {
                attachTime -= 1;
                if (attachTime < 1)
                {
                    txtUpAttachMsg.Text = "";
                    tmrUpAttach.Enabled = false;
                    UpAttachFile();
                    attachTime = 60;
                    tmrUpAttach.Enabled = true;
                }
                txtUpAttach.Text = attachTime.ToString();
            }
            catch (Exception ex)
            {
                tmrUpAttach.Enabled = true;
                //MessageBox.Show(ex.Message);
                YLWService.LogWriter.WriteLog(ex.Message);
                txtUpAttachMsg.Text = ex.Message;
            }
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

            if (!Directory.Exists(inpath)) Directory.CreateDirectory(inpath);
            var files = Directory.GetFiles(inpath, "*.dat");
            foreach (var file in files)
            {
                try
                {
                    txtUpMsg.Text = "Read File : " + Path.GetFileName(file) + " (" + DateTime.Now + ")";
                    Application.DoEvents();

                    string editext = "";
                    using (StreamReader str = new StreamReader(file, Encoding.Default))
                    {
                        editext = str.ReadToEnd();
                        editext = editext.Replace("\r", "").Replace("\n", "\r\n");
                    }

                    dt.Clear();
                    DataRow dr = dt.Rows.Add();

                    dr["companyseq"] = security.companySeq;
                    dr["send_type"] = 0;
                    dr["success_fg"] = 0;
                    dr["cust_code"] = "CAI";
                    dr["edi_text"] = editext;

                    string success_fg = "";
                    DataSet yds = MTRServiceModule.CallMTRServiceCallPost(security, ds);
                    //DataSet yds = YLWDBService.CallYlwServiceCallPost(security, ds);   //시뮬레이션용
                    if (yds != null)
                    {
                        DataTable dataBlock1 = yds.Tables["DataBlock1"];
                        if (dataBlock1 != null && dataBlock1.Rows.Count > 0)
                        {
                            success_fg = dataBlock1.Rows[0]["success_fg"] + "";
                            if (success_fg == "1")
                            {
                                File.Delete(file);
                            }
                        }
                    }

                    txtUpCnt.Text = Utils.ConvertToString(Utils.ToInt(txtUpCnt.Text) + 1);
                    Application.DoEvents();
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    txtUpMsg.Text = ex.Message;
                    YLWService.LogWriter.WriteLog(ex.Message);
                    string path = Path.GetDirectoryName(file);
                    path = Path.Combine(path, "Error_backup");
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    string tofile = Path.Combine(path, Path.GetFileName(file));
                    File.Move(file, tofile);
                }
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

            DataSet yds = MTRServiceModule.CallMTRServiceCall(security, ds);
            if (yds != null && yds.Tables.Count > 0)
            {
                if (yds.Tables.Contains("ErrorMessage")) throw new Exception(yds.Tables["ErrorMessage"].Rows[0]["Message"].ToString());
                DataTable dataBlock1 = yds.Tables["DataBlock1"];
                if (dataBlock1 != null && dataBlock1.Rows.Count > 0)
                {
                    string fileName = "";
                    try
                    {
                        if (!Directory.Exists(outpath)) Directory.CreateDirectory(outpath);
                        //string transdtm = dataBlock1.Rows[0]["edi_trans_dtm"] + "";
                        string transdtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                        fileName = "tolina_" + transdtm + "_" + dataBlock1.Rows[0]["tr_cs_code"] + "_0";

                        txtDownMsg.Text = "Write File : " + fileName + " (" + DateTime.Now + ")";
                        Application.DoEvents();

                        string file = outpath + "/" + fileName;
                        if (File.Exists(file)) throw new Exception("있는 파일명입니다[" + fileName + "]");
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
                        //MessageBox.Show(ex.Message);
                        txtDownMsg.Text = ex.Message;
                        YLWService.LogWriter.WriteLog(ex.Message);
                        return 0;
                    }
                    dr["edi_id"] = dataBlock1.Rows[0]["edi_id"];
                    string acdtNo = dataBlock1.Rows[0]["AcdtNo"] + "";

                    //첨부파일
                    DataTable dataBlock2 = yds.Tables["DataBlock2"];
                    if (dataBlock2 != null && dataBlock2.Rows.Count > 0)
                    {
                        Utils.ClearFolder(fileDownPath);
                        for (int ii = 0; ii < dataBlock2.Rows.Count; ii++)
                        {
                            if (!WriteAttachFile(dataBlock2.Rows[ii]["file_name"] + "", dataBlock2.Rows[ii]["file_seq"] + "")) return 0;
                        }
                        string zipFile = Path.Combine(attachTempPath, acdtNo + ".zip");
                        Utils.ZipAddDirectory(zipFile, fileDownPath);
                        Utils.FileMoveTo(zipFile, attachPath);
                        Utils.ClearFolder(fileDownPath);
                    }

                    txtDownCnt.Text = Utils.ConvertToString(Utils.ToInt(txtDownCnt.Text) + 1);
                    Application.DoEvents();
                    Application.DoEvents();

                    security.methodId = "commit";
                    yds = MTRServiceModule.CallMTRServiceCall(security, ds);
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

        public bool WriteAttachFile(string fileName, string fileSeq)
        {
            txtDownMsg.Text = "Write Attach File : " + fileName + " (" + DateTime.Now + ")";
            Application.DoEvents();

            YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
            if (!Directory.Exists(fileDownPath)) Directory.CreateDirectory(fileDownPath);
            string file = Path.Combine(fileDownPath, fileName);
            if (File.Exists(file)) File.Delete(file);
            string fileBase64 = YLWService.MTRServiceModule.CallMTRFileDownloadBase64(security, fileSeq, "0", "0");
            if (fileBase64 != "")
            {
                byte[] bytes_file = Convert.FromBase64String(fileBase64);
                FileStream fs = new FileStream(file, FileMode.Create);
                fs.Write(bytes_file, 0, bytes_file.Length);
                fs.Close();
            }
            return true;
        }

        private void ResponseFile()
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

            if (!Directory.Exists(inpath)) Directory.CreateDirectory(inpath);
            var files = Directory.GetFiles(inpath, "*.dat");
            foreach (var file in files)
            {
                try
                {
                    txtResponseMsg.Text = "Response File : " + Path.GetFileName(file) + " (" + DateTime.Now + ")";
                    Application.DoEvents();

                    string editext = "";
                    using (StreamReader str = new StreamReader(file, Encoding.Default))
                    {
                        editext = str.ReadToEnd();
                        editext = editext.Replace("\r", "").Replace("\n", "\r\n");
                    }

                    dt.Clear();
                    DataRow dr = dt.Rows.Add();

                    dr["companyseq"] = security.companySeq;
                    dr["send_type"] = 0;
                    dr["success_fg"] = 0;
                    dr["cust_code"] = "CAI";
                    dr["edi_text"] = editext;

                    string success_fg = "";
                    DataSet yds = MTRServiceModule.CallMTRServiceCallPost(security, ds);
                    //DataSet yds = YLWDBService.CallYlwServiceCallPost(security, ds);   //시뮬레이션용
                    if (yds != null)
                    {
                        DataTable dataBlock1 = yds.Tables["DataBlock1"];
                        if (dataBlock1 != null && dataBlock1.Rows.Count > 0)
                        {
                            success_fg = dataBlock1.Rows[0]["success_fg"] + "";
                            if (success_fg == "1")
                            {
                                File.Delete(file);
                            }
                        }
                    }
                    txtResponseCnt.Text = Utils.ConvertToString(Utils.ToInt(txtResponseCnt.Text) + 1);
                    Application.DoEvents();
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    txtResponseMsg.Text = ex.Message;
                    YLWService.LogWriter.WriteLog(ex.Message);
                    string path = Path.GetDirectoryName(file);
                    path = Path.Combine(path, "Error_backup");
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    string tofile = Path.Combine(path, Path.GetFileName(file));
                    File.Move(file, tofile);
                }
            }
        }

        private void UpAttachFile()
        {
            if (!Directory.Exists(getFilePath)) Directory.CreateDirectory(getFilePath);
            var files = Directory.GetFiles(getFilePath, "*.zip");
            foreach (var file in files)
            {
                try
                {
                    txtUpAttachMsg.Text = "Upload Zip File : " + Path.GetFileName(file) + " (" + DateTime.Now + ")";
                    Application.DoEvents();

                    Utils.ClearFolder(getFileTempPath);
                    Utils.ZipExtract(file, getFileTempPath);
                    string acdtNo = Path.GetFileNameWithoutExtension(file);
                    UpAttachFile(acdtNo, file);  //ZIP파일은 맨위에 올린다
                    var upfiles = Directory.GetFiles(getFileTempPath, "*.*");
                    foreach (var upfile in upfiles)
                    {
                        UpAttachFile(acdtNo, upfile);
                    }
                    Utils.DeleteFile(file);
                    Utils.ClearFolder(getFileTempPath);

                    txtUpAttachCnt.Text = Utils.ConvertToString(Utils.ToInt(txtUpAttachCnt.Text) + 1);
                    Application.DoEvents();
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    txtUpAttachMsg.Text = ex.Message;
                    YLWService.LogWriter.WriteLog(ex.Message);
                    string path = Path.GetDirectoryName(file);
                    path = Path.Combine(path, "Error_backup");
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    string tofile = Path.Combine(path, Path.GetFileName(file));
                    File.Move(file, tofile);
                }
            }
        }

        public bool UpAttachFile(string acdtNo, string realFileName)
        {
            string fileName = Path.GetFileName(realFileName);
            txtUpAttachMsg.Text = "Upload Attach File : " + fileName + " (" + DateTime.Now + ")";
            Application.DoEvents();

            YlwSecurityJson security = YLWService.MTRServiceModule.SecurityJson.Clone();  //깊은복사
            security.serviceId = "Metro.Package.AdjSL.BisAdjSLEDITransLina";
            security.methodId = "attach";
            DataSet ds = new DataSet("ROOT");
            DataTable dt = ds.Tables.Add("DataBlock1");

            dt.Columns.Add("companyseq");
            dt.Columns.Add("success_fg");
            dt.Columns.Add("trans_dtm");
            dt.Columns.Add("edi_id");
            dt.Columns.Add("file_name");
            dt.Columns.Add("file_seq");
            dt.Columns.Add("parent_id");
            dt.Columns.Add("id");
            dt.Columns.Add("AcdtNo");

            // File Info
            FileInfo finfo = new FileInfo(realFileName);
            byte[] rptbyte = (byte[])MetroSoft.HIS.cFile.ReadBinaryFile(realFileName);
            string fileBase64 = Convert.ToBase64String(rptbyte);
            // File Info
            //string fileSeq = YLWService.MTRServiceModule.CallMTRFileuploadGetSeq(security, finfo, fileBase64, "47820004");  // 이부분에서 오류남. CallMTRFileuploadGetSeq -> FileuploadGetSeq
            //string fileSeq = YLWService.YLWServiceModule.FileuploadGetSeq(security, finfo, fileBase64, "47820004");
            string fileSeq = YLWService.MTRServiceModule.CallMTRFileuploadGetSeq(security, finfo, fileBase64, "47820004");
            if (fileSeq == "0") return false;

            dt.Clear();
            DataRow dr = dt.Rows.Add();

            dr["companyseq"] = security.companySeq;
            dr["AcdtNo"] = acdtNo;
            dr["file_name"] = fileName;
            dr["file_seq"] = fileSeq;

            string success_fg = "";
            DataSet yds = MTRServiceModule.CallMTRServiceCallPost(security, ds);
            if (yds != null)
            {
                DataTable dataBlock1 = yds.Tables["DataBlock1"];
                if (dataBlock1 != null && dataBlock1.Rows.Count > 0)
                {
                    success_fg = dataBlock1.Rows[0]["success_fg"] + "";
                    if (success_fg == "1")
                    {
                        File.Delete(realFileName);
                    }
                }
            }
            return true;
        }
    }
}
