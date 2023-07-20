using System.Net.Mail;
using System.Text.RegularExpressions;
//using System.Net

namespace Login
{
    public partial class Form1 : Form
    {
        TextBox EmailBox = new TextBox();
        TextBox PasswordBox = new TextBox();
        Label requiredEmail = new Label();
        Label invalidEmail = new Label();
        Label requiredPassword = new Label();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Label star = new Label();
            star.Text = "*";
           // star.ForeColor = Color.Red;
            GroupBox groupBox = new GroupBox();
            groupBox.Location = new Point(100, 10);
            groupBox.Size = new Size(320, 250);
            groupBox.Text = "Login Form";
            groupBox.FlatStyle = FlatStyle.Flat;


            Button SubmitButton = new Button();
            SubmitButton.Click += new EventHandler(submitValidation);
            SubmitButton.Text = "Submit";
            SubmitButton.Location = new Point(100, 200);


            Label Email = new Label();
            Email.Text = "Username" +star.Text;
            //Email.Text = star.Text;

            Email.Location = new Point(15, 65);
            Email.Size = new Size(70, 20);

            //TextBox EmailBox = new TextBox();
            //EmailBox.Text = "example@gmail.com";
            EmailBox.PlaceholderText = "example@gmail.com";
            //EmailBox.Focus = false;

           
            EmailBox.Location = new Point(90, 60);
            EmailBox.Size = new Size(150, 20);

            //Label requiredEmail = new Label();
            requiredEmail.Text = "Field required" ;
            requiredEmail.Location = new Point(90, 90);
            requiredEmail.Size = new Size(230, 20);
            requiredEmail.Hide();

            invalidEmail.Text = "Username should be an email";
            invalidEmail.Location = new Point(90, 90);
            invalidEmail.Size = new Size(230, 20);
            invalidEmail.Hide();


            Label Password = new Label();
            Password.Text = "Password"  +star.Text;
            Password.Location = new Point(15, 115);
            Password.Size = new Size(70, 20);
            

            //TextBox PasswordBox = new TextBox();
            PasswordBox.Text = "";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Location = new Point(90, 110);
            PasswordBox.Size = new Size(150, 20);

            requiredPassword.Text = "Field required";
            requiredPassword.Location = new Point(90, 140);
            requiredPassword.Size = new Size(150, 20);
            requiredPassword.Hide();


            // Add labels and textBoxes and Button to the GroupBox.

            groupBox.Controls.Add(Email);
            groupBox.Controls.Add(EmailBox);
            groupBox.Controls.Add(requiredEmail);
            groupBox.Controls.Add(invalidEmail);

            groupBox.Controls.Add(Password);
            groupBox.Controls.Add(PasswordBox);
            groupBox.Controls.Add(requiredPassword);


            groupBox.Controls.Add(SubmitButton);


            // Add the GroupBox to the Form.
            Controls.Add(groupBox);
        }

        public void submitValidation(object sender, EventArgs e)
        {
           
            
                if (string.IsNullOrEmpty(EmailBox.Text))
                {
                    requiredEmail.Show();
                }
                else
                {
                    requiredEmail.Hide();
                }
                if (string.IsNullOrEmpty(PasswordBox.Text))
                {
                    requiredPassword.Show();
                }
                else
                {
                    requiredPassword.Hide();
                }

               string regex = @"^[^@\s]+@[^@\s]+\.(.*[a-zA-Z0-9])";

                if ( Regex.IsMatch(EmailBox.Text, regex, RegexOptions.IgnoreCase))
                {
                    invalidEmail.Hide();
                }
                else
                {
                    invalidEmail.Show();
                }
                
                if (string.IsNullOrEmpty(EmailBox.Text)==false && string.IsNullOrEmpty(PasswordBox.Text)==false && Regex.IsMatch(EmailBox.Text, regex, RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Login Successful");

                }
           
            


        }

    }
}