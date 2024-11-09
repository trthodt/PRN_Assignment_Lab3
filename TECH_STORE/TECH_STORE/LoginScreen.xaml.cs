using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using Tech_BussinessObjects;
using Tech_Repositories.Interface;
using Tech_Services.Implement;
using Tech_Services.Interface;

namespace TECH_STORE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private IUserService _userService;
        public LoginScreen()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = pbPassword.Password;
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Email and Password");
                return;
            }
            User user = _userService.FindUserByEmail(email);
            if (user == null) {
                MessageBox.Show("Wrong Email");
                return;
            }
            if (user.Password.Equals(password)) {
                if (user.Role.Equals("admin")) {
                    ProductScreen screen = new ProductScreen();
                    screen.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("You don't have permission to access this application!");
                }
                
                
            } else
            {
                MessageBox.Show("Wrong password");
            }
        }
    }
}