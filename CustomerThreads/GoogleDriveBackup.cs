using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerThreads
{
    public static class GoogleDriveBackup
    {
        static readonly string[] Scopes = { DriveService.Scope.DriveFile };
        static readonly string ApplicationName = "CustomerThreads";

        public static async Task BackupFileAsync(string localFilePath)
        {
            try
            {
                // 1️⃣ Authenticate
                UserCredential credential;
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    var clientSecrets = GoogleClientSecrets.FromStream(stream).Secrets;

                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        clientSecrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("CustomerThreads.Token", true)
                    );
                }

                // 2️⃣ Initialize Drive service
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });

                // 3️⃣ Check if file already exists
                var existingFiles = (await service.Files.List().ExecuteAsync()).Files;
                var existingFile = existingFiles.FirstOrDefault(f => f.Name == "data.json");

                // 4️⃣ Upload or update
                using (var fs = new FileStream(localFilePath, FileMode.Open))
                {
                    if (existingFile != null)
                    {
                        var updateRequest = service.Files.Update(
                            new Google.Apis.Drive.v3.Data.File(),
                            existingFile.Id,
                            fs,
                            "application/json"
                        );
                        await updateRequest.UploadAsync();
                    }
                    else
                    {
                        var fileMetadata = new Google.Apis.Drive.v3.Data.File() { Name = "data.json" };
                        var createRequest = service.Files.Create(fileMetadata, fs, "application/json");
                        createRequest.Fields = "id";
                        await createRequest.UploadAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // silent fail, log to console
                Console.WriteLine("Google Drive backup failed: " + ex.Message);
            }
        }

        public static bool DownloadFile(string localFilePath)
        {
            try
            {
                UserCredential credential;

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("CustomerThreads.Token", true)
                    ).Result;
                }

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Find the file named "data.json"
                var listRequest = service.Files.List();
                listRequest.Q = "name='data.json' and trashed=false";
                listRequest.Fields = "files(id, name)";
                var files = listRequest.Execute().Files;

                if (files == null || files.Count == 0)
                    return false; // No file found

                var fileId = files[0].Id;

                using (var stream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
                {
                    var request = service.Files.Get(fileId);
                    request.MediaDownloader.ProgressChanged += (progress) =>
                    {
                        if (progress.Status == Google.Apis.Download.DownloadStatus.Failed)
                            Console.WriteLine("Download failed.");
                    };
                    request.Download(stream);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restore failed: " + ex.Message);
                return false;
            }
        }
    }
}