using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;

namespace CustomerThreads
{
    public static class GoogleDriveBackup
    {
        static readonly string[] Scopes = { DriveService.Scope.DriveFile };
        static readonly string ApplicationName = "CustomerThreads";

        public static void BackupFile(string localFilePath)
        {
            try
            {
                UserCredential credential;

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
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

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = "data.json"
                };

                FilesResource.CreateMediaUpload request;
                using (var stream = new FileStream(localFilePath, FileMode.Open))
                {
                    request = service.Files.Create(
                        fileMetadata,
                        stream,
                        "application/json");

                    request.Fields = "id";
                    request.Upload();
                }
            }
            catch (Exception ex)
            {
                // Silent fail (no popup, app keeps working)
                Console.WriteLine("Backup failed: " + ex.Message);
            }
        }
    }
}