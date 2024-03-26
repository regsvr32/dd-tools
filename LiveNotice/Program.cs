using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;

namespace LiveNotice {
  internal static class Program {
    static readonly string optionFilePath = AppContext.BaseDirectory + "options.json";
    static readonly string cacheDirPath = AppContext.BaseDirectory + "cache";
    public static bool muteLaunch { get; private set; } = false;
    public static Options options { get; private set; } = loadOptions();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
      ApplicationConfiguration.Initialize();
      if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1) { return; }
      if (!Directory.Exists(cacheDirPath)) {
        Directory.CreateDirectory(cacheDirPath);
      }
      ToastNotificationManagerCompat.OnActivated += toastArgs => {
        Process.Start(new ProcessStartInfo($"https://live.bilibili.com/{toastArgs.Argument}") { UseShellExecute = true });
      };
      startListen();
      muteLaunch = args.Contains("-m");
      Application.Run(new OptionsForm());
    }

    static Options loadOptions() {
      if (File.Exists(optionFilePath)) {
        var parsed = JsonSerializer.Deserialize<Options>(File.ReadAllText(optionFilePath));
        if (parsed != null) { return parsed; }
      }
      return new Options(new string[0], 60, false);
    }

    public static Options getOptions() { return options; }

    public static void setOptions(Options newOptions) {
      options = newOptions;
      if (nextQueryTime > DateTime.Now.AddSeconds(newOptions.querySpanSeconds)) { startListen(); }
      var assemblyName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
      var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      var autoLaunchShortcut = $"{appData}\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\{assemblyName}.lnk";
      if (File.Exists(autoLaunchShortcut)) {
        if (!newOptions.autoLaunch) { File.Delete(autoLaunchShortcut); }
      }
      else {
        if (newOptions.autoLaunch) {
          var shortcut = (IWshRuntimeLibrary.IWshShortcut)new IWshRuntimeLibrary.WshShellClass().CreateShortcut(autoLaunchShortcut);
          shortcut.TargetPath = AppContext.BaseDirectory + assemblyName + ".exe";
          shortcut.WorkingDirectory = AppContext.BaseDirectory;
          shortcut.Arguments = "-m";
          shortcut.Save();
        }
      }
      File.WriteAllText(optionFilePath, JsonSerializer.Serialize(newOptions));
    }

    static CancellationTokenSource? cancelTokenSource = null;
    public static bool listening { get { return cancelTokenSource != null; } }
    static DateTime nextQueryTime = DateTime.MinValue;

    public static void startListen() {
      if (listening) { stopListen(); }
      cancelTokenSource = new CancellationTokenSource();
      var cancelToken = cancelTokenSource.Token;
      Task.Run(async () => {
        var notified = new HashSet<string>();
        using (var client = new HttpClient()) {
          client.Timeout = TimeSpan.FromSeconds(10);
          while (true) {
            try {
              nextQueryTime = DateTime.Now.AddSeconds(options.querySpanSeconds);
              await Task.Delay(options.querySpanSeconds * 1000, cancelToken);
              if (options.listenUids.Length == 0) { continue; }
              var payload = JsonContent.Create(new { uids = options.listenUids.Where(str => str.Length > 0).Select(long.Parse).ToArray() });
              await payload.LoadIntoBufferAsync();
              var result = await client.PostAsync("https://api.live.bilibili.com/room/v1/Room/get_status_info_by_uids", payload, cancelToken);
              if (result.StatusCode == HttpStatusCode.OK) {
                var content = JsonDocument.Parse(result.Content.ReadAsStream()).RootElement;
                if (content.GetProperty("code").GetInt64() == 0) {
                  var data = content.GetProperty("data");
                  foreach (var prop in data.EnumerateObject()) {
                    var uid = prop.Name;
                    var room = prop.Value;
                    var isLiving = room.GetProperty("live_status").GetInt64() == 1;
                    if (isLiving == notified.Contains(uid)) { continue; }
                    if (isLiving) {
                      var roomId = room.GetProperty("room_id").GetRawText();
                      var toast = new ToastContentBuilder()
                        .AddArgument(roomId)
                        .AddText($"{room.GetProperty("uname").GetString()}正在直播：{room.GetProperty("title").GetString()}")
                        .AddText($"https://live.bilibili.com/{roomId}");

                      var cover = room.GetProperty("cover_from_user").GetString();
                      if (!string.IsNullOrEmpty(cover)) {
                        var coverImg = $"{cacheDirPath}\\{uid}.jpg";
                        using (var input = await client.GetStreamAsync(room.GetProperty("cover_from_user").GetString(), cancelToken))
                        using (var output = File.Create(coverImg)) { await input.CopyToAsync(output, cancelToken); }
                        toast.AddHeroImage(new Uri("file:///" + coverImg));
                      }
                      toast.Show();
                      notified.Add(uid);
                    }
                    else {
                      notified.Remove(uid);
                    }
                  }
                }
              }
            }
            catch (TaskCanceledException err) {
              if (err.CancellationToken == cancelToken) { return; }
            }
            catch (Exception err) { Debug.WriteLine(err); }
          }
        }
      }, cancelToken);
    }

    public static void stopListen() {
      cancelTokenSource?.Cancel();
      cancelTokenSource = null;
    }
  }
}