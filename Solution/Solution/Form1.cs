using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kinvey;

namespace Solution
{
    public partial class Form1 : Form
    {
        private Client.Builder mBuilder;
        private Client mKinveyClient;

        // App, Environment and Service details.
        private String appKey = "xxx";
        private String appSecret = "xxx";
        private String authServiceID = "xxx";
        private String instanceID = "xxx";

        // Test User credentials.
        private String userName = "xxx";
        private String userPassword = "xxx";

        public Form1()
        {
            InitializeComponent();

            // Set-up the Kinvey backend connection.
            mBuilder = new Client.Builder(appKey, appSecret).SetInstanceID(instanceID).setLogger(Console.WriteLine);
            mKinveyClient = mBuilder.Build();
            KinveyPing();
        }

        private async void KinveyPing()
        {
            try
            {
                PingResponse mPingResponse = await mKinveyClient.PingAsync();
                MessageBox.Show("Kinvey Ping Response: " + mPingResponse.kinvey);
                buttonLoginKinveyMIC.Visible = true;
            }
            catch (Exception mExc)
            {
                MessageBox.Show("Kinvey Ping Exception: " + mExc.Message);
            }
        }

        private void buttonLoginKinveyMIC_Click(object sender, EventArgs e)
        {
            KinveyLoginMIC();
        }

        private async void KinveyLoginMIC()
        {
            // If there's a User logged-in, please log-out.
            if (Client.SharedClient.ActiveUser != null)
            {
                Client.SharedClient.ActiveUser.Logout();
            }
            await User.LoginWithMIC(userName, userPassword, authServiceID, mKinveyClient);
            MessageBox.Show("Successfully logged-in, User name: " + Client.SharedClient.ActiveUser.UserName);
        }
    }
}