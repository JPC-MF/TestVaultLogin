using ACW = Autodesk.Connectivity.WebServices;
using ACWTools = Autodesk.Connectivity.WebServicesTools;
using Framework = Autodesk.DataManagement.Client.Framework;
using Vault = Autodesk.DataManagement.Client.Framework.Vault;
using Forms = Autodesk.DataManagement.Client.Framework.Vault.Forms;

namespace TestVaultLogin
{
    public partial class Form1 : Form
    {
        private Vault.Currency.Connections.Connection? conn = null;

        public Form1()
        {
            InitializeComponent();

            //Initialize the Vault Forms Library
            Forms.Library.Initialize();
        }

        private void mUserFeedback(Vault.Currency.Connections.Connection? connection)
        {
            if (connection == null)
            {
                Framework.Forms.Library.ShowError("The login failed. Check your connection inputs.", "Vault-API-Sample");
            }
            else
            {
                string mUserName = connection.WebServiceManager.AuthService.Session.User.Name;
                Framework.Forms.Library.ShowMessage("Great! You successfully logged in to " + connection.Vault + " with user name: " + mUserName, "Vault-API-Sample", Framework.Forms.Currency.ButtonConfiguration.None);
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.conn = Vault.Forms.Library.Login(null);
            mUserFeedback(conn);

            Vault.Library.ConnectionManager.CloseAllConnections();
        }
    }
}
