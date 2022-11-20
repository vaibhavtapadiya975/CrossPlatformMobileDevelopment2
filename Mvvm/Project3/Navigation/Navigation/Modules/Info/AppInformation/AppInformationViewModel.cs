using System;
using Navigation.Common;
using Xamarin.Essentials;

namespace Navigation.Modules.AppInformation
{
    public class AppInformationViewModel: BaseViewModel
    {
        public string AppName => $"App Name: Calculator History";
        public string AppVersion => $"App Version: {AppInfo.VersionString}";
        public string Author => "Project Members : Vaibhav Tapadiya \n Snehal Babar \n Vikas Singaram";
    }
}
