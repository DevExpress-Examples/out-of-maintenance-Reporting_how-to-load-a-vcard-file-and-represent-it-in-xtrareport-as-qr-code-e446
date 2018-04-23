using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraReports.UI;
namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            List<MyObj> myItems = new List<MyObj>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "VCard|*.vcf|All|*.*";
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                foreach(string s in ofd.FileNames) {
                    myItems.Add(new MyObj() { Path = s, Vcard = File.ReadAllBytes(s) });
                }
                XtraReport1 report = new XtraReport1();
                report.DataSource = myItems;
                report.ShowPreviewDialog();
            }
        }
    }
    public class MyObj {
        string path;
        public string Path { get { return path; } set { path = value; } }
        byte[] vcard;
        public byte[] Vcard { get { return vcard; } set { vcard = value; } }

    }
}
