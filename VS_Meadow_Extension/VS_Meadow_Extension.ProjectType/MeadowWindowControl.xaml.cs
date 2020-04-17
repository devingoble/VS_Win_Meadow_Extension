namespace Meadow
{
    using EnvDTE;
    using EnvDTE80;
    using Meadow.Helpers;
    using MeadowCLI.DeviceManagement;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Management;
    using task = System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.VisualStudio.Threading;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Microsoft.VisualStudio.Settings.Internal;
    using Newtonsoft.Json.Linq;
    using System.Net;
    using System.IO.Compression;
    using System.Windows.Ink;
    using System.Threading;
    //using Task = System.Threading.Tasks.Task;
    using System.Text.RegularExpressions;
    //using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MeadowWindowControl.
    /// </summary>
    public partial class MeadowWindowControl : UserControl
    {
        readonly Guid DEVICE_INTERFACE_GUID_STDFU = new Guid(0x3fe809ab, 0xfb91, 0x4cb5, 0xa6, 0x43, 0x69, 0x67, 0x0d, 0x52, 0x36, 0x6e);
        static Guid windowGuid = new Guid("AD01DF73-6990-4361-8587-4FC3CB91A65F");
        readonly string versionCheckUrl = "https://s3-us-west-2.amazonaws.com/downloads.wildernesslabs.co/Meadow_Beta/latest.json";
        string latestJson = "latest.json";
        IVsOutputWindowPane meadowPane;
        IVsWindowFrame windowFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeadowWindowControl"/> class.
        /// </summary>
        public MeadowWindowControl()
        {
            this.InitializeComponent();
        }

        //[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        //[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshDeviceList();
        }

        public void RefreshDeviceList()
        {
            //MeadowSettings settings = new MeadowSettings(Globals.SettingsFilePath);

            //Devices.Items.Clear();

            //Devices.Items.Add(new Device { Caption = "Select Target Device Port" });

            //var captions = MeadowDeviceManager.GetSerialDeviceCaptions();
            //List<Device> devices = new List<Device>();

            //foreach (var c in captions)
            //{
            //    devices.Add(new Device
            //    {
            //        Caption = c,
            //        SerialPort = GetSerialPortFromCaption(c)
            //    });
            //}

            //var selectedIndex = 0;

            //for (int i = 0; i < devices.Count; i++)
            //{
            //    if (devices[i].SerialPort == settings.DeviceTarget)
            //    {
            //        selectedIndex = i + 1;
            //    }
            //    Devices.Items.Add(devices[i]);
            //}

            //Devices.DisplayMemberPath = "Caption";
            //Devices.SelectedValuePath = "SerialPort";

            //Devices.SelectedIndex = selectedIndex;
        }

        private void Devices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (Devices.SelectedIndex <= 0) return;

            //MeadowSettings settings = new MeadowSettings(Globals.SettingsFilePath, false);
            //settings.DeviceTarget = Devices.SelectedValue.ToString();
            //settings.Save();
        }

        private async void Flash_Device(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "Binary (*.BIN;)|*.BIN;";
            //dlg.InitialDirectory = Globals.FirmwareDownloadsFilePath;

            //Nullable<bool> result = dlg.ShowDialog();

            //if (result.HasValue && result.Value)
            //{
            //    FileInfo fi = new FileInfo(dlg.FileName);
            //    await OutputMessageAsync($"Preparing to update device firmware...", true);

            //    var query = "SELECT * FROM Win32_USBHub";
            //    ManagementObjectSearcher device_searcher = new ManagementObjectSearcher(query);
            //    string deviceId = string.Empty;
            //    foreach (ManagementObject usb_device in device_searcher.Get())
            //    {
            //        if (usb_device.Properties["Name"].Value.ToString() == "STM Device in DFU Mode")
            //        {
            //            deviceId = usb_device.Properties["DeviceID"].Value.ToString();
            //        }
            //    }

            //    var payload = File.ReadAllText(Path.Combine(Globals.FirmwareDownloadsFilePath, latestJson));

            //    if (!string.IsNullOrEmpty(deviceId))
            //    {
            //        await OutputMessageAsync($"Deploying firmare {fi.Name} to device.");

            //        var device = new STDfuDevice($@"\\?\{deviceId.Replace("\\", "#")}#{{{DEVICE_INTERFACE_GUID_STDFU.ToString()}}}");

            //        await task.Task.Run(async () =>
            //        {
            //            await OutputMessageAsync("Erasing sectors");

            //            await TaskScheduler.Default;
            //            device.EraseAllSectors();

            //            await OutputMessageAsync($"Starting upload, this may take a few minutes...");
            //            await OutputMessageAsync($"Uploading {fi.Name}");

            //            await TaskScheduler.Default;
            //            UploadFile(device, dlg.FileName, 0x08000000);

            //            await OutputMessageAsync($"Resetting device");

            //            await TaskScheduler.Default;
            //            device.LeaveDfuMode();
            //            device.Dispose();

            //            await OutputMessageAsync($"Complete");
            //        });
            //    }
            //    else
            //    {
            //        await OutputMessageAsync("Device not found. Connect the device in bootloader mode by plugging in the device while holding down the BOOT button.");
            //        await OutputMessageAsync("For more help, visit http://developer.wildernesslabs.co/Meadow/Meadow_Basics/Troubleshooting/VisualStudio/");
            //    }

            //    RefreshDeviceList();
            //}
            //else
            //{
            //    await OutputMessageAsync($"Flash device aborted.");
            //}
        }

        private void UploadFile(STDfuDevice device, string filepath, uint address)
        {
            //ushort blockSize = device.BlockTransferSize;
            //byte[] hexFileBytes = File.ReadAllBytes(filepath);

            //// set our download address pointer
            //if (device.SetAddressPointer(address) == false)
            //{
            //    throw new Exception("Could not set base address for flash operation.");
            //}

            //// write blocks to the board and verify; we must have already erased our sectors before this point
            //for (ushort index = 0; index <= (hexFileBytes.Length / blockSize); index++)
            //{
            //    // write block to the board
            //    byte[] buffer = new byte[Math.Min(hexFileBytes.Length - (index * blockSize), blockSize)];
            //    Array.Copy(hexFileBytes, index * blockSize, buffer, 0, buffer.Length);
            //    bool success = device.WriteMemoryBlock(index, buffer);
            //    if (!success)
            //    {
            //        Console.WriteLine("write failed");
            //    }

            //    //// verify written block
            //    //byte[] verifyBuffer = new byte[buffer.Length];
            //    //success = device.ReadMemoryBlock(index, verifyBuffer);
            //    //if (!success || !buffer.SequenceEqual(verifyBuffer))
            //    //{
            //    //    Console.WriteLine("verify failed");
            //    //}
            //}
        }

        private async void Download_Firmware(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    HttpClient httpClient = new HttpClient();
            //    var payload = await httpClient.GetStringAsync(versionCheckUrl);
            //    var version = GetVersionFromPayload(payload);

            //    Uri download = new Uri(GetDownloadUrlFromPayload(payload));
            //    var fileName = download.Segments.ToList().Last();

            //    if (Directory.Exists(Globals.FirmwareDownloadsFilePath))
            //    {
            //        Directory.Delete(Globals.FirmwareDownloadsFilePath, true);
            //    }

            //    Directory.CreateDirectory(Globals.FirmwareDownloadsFilePath);
            //    DirectoryInfo di = new DirectoryInfo(Globals.FirmwareDownloadsFilePath);

            //    await OutputMessageAsync($"Downloading firmware version: {version}.", true);
            //    di.Delete(true);
            //    Directory.CreateDirectory(Globals.FirmwareDownloadsFilePath);

            //    WebClient webClient = new WebClient();
            //    webClient.DownloadFile(download, Path.Combine(Globals.FirmwareDownloadsFilePath, fileName));
            //    webClient.DownloadFile(versionCheckUrl, Path.Combine(Globals.FirmwareDownloadsFilePath, latestJson));
            //    ZipFile.ExtractToDirectory(Path.Combine(Globals.FirmwareDownloadsFilePath, fileName), Globals.FirmwareDownloadsFilePath);
            //    await OutputMessageAsync($"Download complete.");
            //}
            //catch (Exception ex)
            //{
            //    await OutputMessageAsync($"Error occurred while downloading latest OS. Please try again later.");
            //}

        }

        private async void ActivateMeadowPaneAsync()
        {
            //try
            //{
            //    if (meadowPane == null)
            //    {
            //        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            //        IVsOutputWindow outWindow = ServiceProvider.GlobalProvider.GetService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            //        if (outWindow != null)
            //        {
            //            string customTitle = "Meadow Device Explorer";
            //            outWindow.CreatePane(ref windowGuid, customTitle, 1, 1);
            //            outWindow.GetPane(ref windowGuid, out meadowPane);
            //        }
            //    }
            //}
            //catch (Exception ex) { }

        }

        private async void ActivateOutputWindowAsync()
        {
            //try
            //{
            //    if (windowFrame == null)
            //    {
            //        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            //        var vsUiShell = ServiceProvider.GlobalProvider?.GetService(typeof(SVsUIShell)) as IVsUIShell;
            //        if (vsUiShell != null)
            //        {
            //            uint flags = (uint)__VSFINDTOOLWIN.FTW_fForceCreate;
            //            vsUiShell.FindToolWindow(flags, VSConstants.StandardToolWindows.Output, out windowFrame);
            //        }

            //    }
            //}
            //catch (Exception ex) { }
        }


        //try
        //    {

        //    }
        //    catch (Exception ex) { }
        private async void OutputMessageAsync(string message, bool clear = false)
        {
            //try
            //{
            //    await ActivateMeadowPaneAsync();
            //    await ActivateOutputWindowAsync();

            //    if(windowFrame != null && meadowPane != null)
            //    {
            //        await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            //        windowFrame.Show();

            //        if (clear)
            //        {
            //            meadowPane.Clear();
            //        }
            //        meadowPane.Activate(); // Brings this pane into view
            //        meadowPane.OutputString($"[{DateTime.Now.ToLocalTime()}] {message}" + Environment.NewLine);
            //    }
                
            //}
            //catch (Exception ex) { }
            
        }

        private string GetVersionFromPayload(string payload)
        {
            var json = JObject.Parse(payload);
            return json["version"].Value<string>();
        }

        private string GetDownloadUrlFromPayload(string payload)
        {
            var json = JObject.Parse(payload);
            return json["downloadUrl"].Value<string>();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private string GetSerialPortFromCaption(string caption)
        {
            return Regex.Match(caption, @"(?<=\().+?(?=\))").Value;
        }
    }
}
