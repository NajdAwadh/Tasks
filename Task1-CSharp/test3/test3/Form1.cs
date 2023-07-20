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

namespace test3
{
    public partial class Form1 : Form
    {
       // string file = "";
        TextBox fileNameBox = new TextBox();
        TextBox IDBox = new TextBox();
        TextBox TimeBox = new TextBox();
        TextBox AzimuthBox = new TextBox();
        TextBox ElevationBox = new TextBox();
        TextBox RangeBox = new TextBox();
       
        public Form1()
        {
            InitializeComponent();
         // Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create and initialize a GroupBox and a Button control.
            GroupBox groupBox1 = new GroupBox();
            groupBox1.Location = new Point(100, 10);
            groupBox1.Size = new Size(250, 100);

            groupBox1.Text = "Load File";
            Button button1 = new Button();
            button1.Click += new EventHandler(DynamicButton_Click);
            button1.Text = "Load File";
            button1.Location = new Point(50, 30);
            Label fileName  = new Label();
            fileName.Text = "File Name:";
            fileName.Location= new Point(20, 60);
            fileName.Size = new Size(60, 20);
            //TextBox fileNameBox = new TextBox();
            fileNameBox.Text = "";
            fileNameBox.Enabled = false;
            fileNameBox.Location = new Point(80, 60);
            fileNameBox.Size = new Size(150, 20);
            //fileNameBox.Text = file ;
            // Set the FlatStyle of the GroupBox.
            groupBox1.FlatStyle = FlatStyle.Flat;

            // Add the Button to the GroupBox.
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(fileName);
            groupBox1.Controls.Add(fileNameBox);


            // Add the GroupBox to the Form.
            Controls.Add(groupBox1);

            //button1.PerformClick();
            // Create and initialize a GroupBox and a Button control.
            GroupBox groupBox2 = new GroupBox();
            groupBox2.Location = new Point(100, 130);
           groupBox2.Size = new Size(250, 150);

            groupBox2.Text = "File Content";
            Label ID = new Label();
            ID.Text = "ID:";
            ID.Location = new Point(20, 20);
            ID.Size = new Size(60, 20);

            //TextBox IDBox = new TextBox();
            IDBox.Text = "";
            IDBox.Enabled = false;
            IDBox.Location = new Point(100, 20);
            IDBox.Size = new Size(130, 20);


            Label Time = new Label();
            Time.Text = "Time Stamp:";
            Time.Location = new Point(20, 45);
            Time.Size = new Size(80, 20);

            //TextBox TimeBox = new TextBox();
            TimeBox.Text = "";
            TimeBox.Enabled = false;
            TimeBox.Location = new Point(100, 45);

            Label Azimuth = new Label();
            Azimuth.Text = "Azimuth:";
            Azimuth.Location = new Point(20, 70);
            Azimuth.Size = new Size(80, 20);

            //TextBox AzimuthBox = new TextBox();
            AzimuthBox.Text = "";
            AzimuthBox.Enabled = false;
            AzimuthBox.Location = new Point(100, 70);


            Label Elevation = new Label();
            Elevation.Text = "Elevation:";
            Elevation.Location = new Point(20, 95);
            Elevation.Size = new Size(80, 20);

            //TextBox ElevationBox = new TextBox();
            ElevationBox.Text = "";
            ElevationBox.Enabled = false;
            ElevationBox.Location = new Point(100, 95);


            Label Range = new Label();
            Range.Text = "Range:";
            Range.Location = new Point(20, 120);
            Range.Size = new Size(80, 20);

            //TextBox RangeBox = new TextBox();
            RangeBox.Text = "";
            RangeBox.Enabled = false;
            RangeBox.Location = new Point(100, 120);


            // Set the FlatStyle of the GroupBox.
            groupBox2.FlatStyle = FlatStyle.Standard;

            // Add the Button to the GroupBox.
            groupBox2.Controls.Add(ID);
            groupBox2.Controls.Add(IDBox);
            groupBox2.Controls.Add(Time);
            groupBox2.Controls.Add(TimeBox);
            groupBox2.Controls.Add(Azimuth);
            groupBox2.Controls.Add(AzimuthBox);
            groupBox2.Controls.Add(Elevation);
            groupBox2.Controls.Add(ElevationBox);
            groupBox2.Controls.Add(Range);
            groupBox2.Controls.Add(RangeBox);


            // Add the GroupBox to the Form.
            Controls.Add(groupBox2);
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            String file;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                try
                {
                    //string text = File.ReadAllText(file);
                    //size = text.Length;
                    fileNameBox.Text = file;

                    //string[] lines = File.ReadAllLines(file);
                    String line;

                    var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        line =streamReader.ReadToEnd();
                        String[] values = line.Split(',');
                        //IDBox.Text = file;

                        IDBox.Text = values[0];
                        TimeBox.Text = values[1];
                        AzimuthBox.Text = values[2];
                        ElevationBox.Text = values[3];
                        RangeBox.Text = values[4];
                        Console.WriteLine(line); 
                        Console.WriteLine(values[0]);   
                        Console.WriteLine(values[1]);   
                        Console.WriteLine(IDBox.Text);  
                        Console.WriteLine(file);    
                        Console.WriteLine(TimeBox.Text);    


                    }
                

                }
                catch (IOException)
                {
                }
            }
          
            
        }

    }
}
