using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace EksamensprojektTest
{
    public partial class Form1 : Form
    {
        static CsvRecord[] allRecords;

        public Form1()
        {
            InitializeComponent();
        }

        public sealed class CsvRecordMap : ClassMap<Values>
        {
            public CsvRecordMap()
            {
                Map(m => m.ID);
                Map(m => m.Question);
                Map(m => m.Answer);
                Map(m => m.Points);
                Map(m => m.Category);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("C:\\Users\\mathi\\OneDrive\\HTX\\3.g\\Programmering\\Eksamensprojekt\\csvfil.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<CsvRecordMap>();
                    var records = csv.GetRecords<Values>().ToArray();
                }
            }

            CsvRecord[] matchingRecords = allRecords.Where(a => a.Category == category && a.Points == points).ToArray();

            Random random = new Random();
            CsvRecord pickedRecord = matchingRecords[random.Next(matchingRecords.Length)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ("{0}", pickedRecord.Question);
        }
    }
}
