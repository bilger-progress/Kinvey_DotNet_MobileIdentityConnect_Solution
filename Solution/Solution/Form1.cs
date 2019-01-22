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

        private String appKey = "xxx";
        private String appSecret = "xxx";
        private String authServiceID = "xxx";
        private String instanceID = "xxx";

        public Form1()
        {
            InitializeComponent();

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
            }
            catch (Exception mExc)
            {
                MessageBox.Show("Kinvey Ping Exception: " + mExc.Message);
            }

        }
        
            

    }
}
