using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit;
using System.IO;

namespace MailMergeEachRecordSeparatePDF {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            var datasource = DataHelper.GenerateEmployeeList();
            dataNavigator1.DataSource = datasource;
            richEditControl1.Options.MailMerge.DataSource = datasource;
            richEditControl1.Options.MailMerge.ViewMergedData = true;
            richEditControl1.LoadDocument("MailMergeSimple.rtf");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            int count = ((List<Employee>)richEditControl1.Options.MailMerge.DataSource).Count;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                using (RichEditDocumentServer docServer = new RichEditDocumentServer()) {
                    MailMergeOptions options = richEditControl1.CreateMailMergeOptions();

                    for (int i = 0; i < count; i++) {
                        string filename = string.Format("{0}{1}.pdf", saveFileDialog1.FileName, (i + 1).ToString());
                        options.FirstRecordIndex = options.LastRecordIndex = i;

                        using (FileStream fs = new FileStream(filename, FileMode.Create, System.IO.FileAccess.Write)) {
                            richEditControl1.MailMerge(options, docServer.Document);
                            docServer.ExportToPdf(fs);
                        }
                    }
                }
            }
        }
    }
}
