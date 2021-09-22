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

namespace rentacar.Resources
{
    public partial class sozlesmeOrnegi : Form
    {
        public sozlesmeOrnegi()
        {
            InitializeComponent();
        }

        private void sozlesmeOrnegi_Load(object sender, EventArgs e)
        {
            string image_outputDir = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);// debug klasörü neredeyse pathi getir.
            DirectoryInfo df = new DirectoryInfo(image_outputDir + @"C:\Users\yildi\Desktop\rentacar enson 2\rentacar\rentacar\bin\Debug\aracResimleri\sozlesmeOrnegi.pdf"); // O klasörün içindeki ilgili resmi bul
            System.Diagnostics.Process.Start(df.ToString()); // ilgili dosyayı ac
        }
    }
}
