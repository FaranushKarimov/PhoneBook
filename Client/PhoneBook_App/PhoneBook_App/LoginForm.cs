
namespace PhoneBook_App
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    ///если нужно определить обработчик кликов то можно обойтись без этого 
    ///дважды нажав на кнопку на странице формы и автоматически создать маркер
    /// </summary>
    public partial class LoginForm : Form
    {
        Authentication user = new Authentication();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            login_btn.Click += new EventHandler(login_btn_Click);
            username.Text = "Enter Email Address";
        }

        private void loginbutton_layout_Paint(object sender, PaintEventArgs e)
        {

        }

        //Link To Go Register Page
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            tableLayoutPanel5.Visible = true;
        }

        //Back Button To Show Login Page Again
        private void back_btn_Click(object sender, EventArgs e)
        {
            tableLayoutPanel5.Visible = false;
            panel1.Visible = false;
        }

        //Register Button
        private void register_btn_Click(object sender, EventArgs e)
        {
            String name = register_username_txtBox.Text;
            String email = register_email_txtBox.Text;
            String password = register_password_txtBox.Text;
            int result = user.registerUser(name, email, password);

            if(result > 0)
            {
                MessageBox.Show("Succesfully Registered: " + user.user_id);
                userPage userPage = new userPage(user.user_id,this);
                userPage.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Could Not Registered\n Email Address is Already Taken");
            }
        }

        //To Login as a User
        private void login_btn_Click(object sender, EventArgs e)
        {
            String email = username_txtbox.Text;
            String password = password_txtbox.Text;
            int result = user.loginUser(email, password);

            if(result > 0)
            {
                MessageBox.Show("Succesfully Logged In: " + user.user_id);
                userPage userPage = new userPage(user.user_id,this);
                userPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email Address or Password is Wrong");
            }
        }

        private void Registe_username_Click(object sender, EventArgs e)
        {

        }
    }
}
