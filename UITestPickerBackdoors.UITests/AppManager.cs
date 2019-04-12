using System;
using System.IO;
using System.Reflection;
using Xamarin.UITest;

namespace UITestPickerBackdoors.UITests
{
    public class AppManager
    {
 

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (!TestEnvironment.IsTestCloud)
            {
                CreateLocalScreenshotDirectory();
            }

            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                       .Android
                       .Debug()
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();

            }

            if (Platform == Platform.iOS)
            {
                Environment.SetEnvironmentVariable("UITEST_FORCE_IOS_SIM_RESTART", "1");

                app = ConfigureApp
                .iOS
                .Debug()
                .PreferIdeSettings()
                .EnableLocalScreenshots()
                .StartApp();
            }

        }

        #region Screenshots

        static string LocalScreenshotDirectory;

        private static void CreateLocalScreenshotDirectory()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            FileInfo fi = new FileInfo(currentFile);
            var dir = fi.Directory.Parent.Parent.Parent.FullName;
            var PlatformName = Platform == Platform.Android ? "Android" : "iOS";
            LocalScreenshotDirectory = Directory.CreateDirectory($"{dir}/Test-Screenshots/{DateTime.Now:yyyy-MM-dd-HH-mm-ss}-{PlatformName}").FullName;
        }

        public static void Screenshot(string title)
        {
            var fi = app.Screenshot(title);
            if (!TestEnvironment.IsTestCloud)
            {
                CopyScreenShotToLocalDir(title, fi);
            }

        }

        private static int screenshotSequence = 0;
        private static void CopyScreenShotToLocalDir(string name, FileInfo fi)
        {
            try
            {

                // Tidy up the name
                name = name.Trim();
                name = name.Replace(".", "");

                // New name has a two digit 0-padded sequence on the front.
                var newLocation = $"{LocalScreenshotDirectory}/{++screenshotSequence:D2}-{name}{fi.Extension}";
                
                File.Move(fi.FullName, newLocation);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Warning - could not move screenshot file {fi.Name} - {ex.Message}");
            }
        }

        #endregion Screenshots
    }
}
