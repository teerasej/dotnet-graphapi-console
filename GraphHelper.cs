using System;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace GraphAPI_1
{
    public class GraphHelper
    {
        private static GraphServiceClient graphClient;

        public static void Initialize(IAuthenticationProvider authProvider)
        {
            graphClient = new GraphServiceClient(authProvider);
        }

        public static async Task<User> GetMeAsync()
        {
            try
            {
                return await graphClient.Me.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting signed-in user: {ex.Message}");
                return null;
            }
        }

        public static async Task<ProfilePhoto> GetUserPhotoAsync() {
            try
            {
                return await graphClient.Me.Photo.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting signed-in user: {ex.Message}");
                return null;
            }
        }

        public static async Task<IDriveItemChildrenCollectionPage> GetUserDriveItems() {
            try
            {
                var drives = await graphClient.Me.Drives.Request().GetAsync();
                return await graphClient.Me.Drives[drives[0].Id].Root.Children.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting signed-in user: {ex.Message}");
                return null;
            }
        }
    }
}
