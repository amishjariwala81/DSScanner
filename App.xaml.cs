namespace DSScanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI4MDM0OUAzMjM0MmUzMDJlMzBpNVR4L3VtdEVHc3ZMRFZGek9OVEZ5MFlnYUdqMWFYWTdhZFBBVVVSNmNvPQ==");//Added by Amish as per requirement  24.2.9
            MainPage = new MainPage();
        }
    }
}