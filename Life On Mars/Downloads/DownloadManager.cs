using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Life_On_Mars.Downloads
{
    public class DownloadManager
    {
        public static string BASE_URL = "https://api.nasa.gov/mars-photos/api/v1/";
        public static string API_KEY = "iIWfSm9w9599W0RaKYNT7VqBn8eSQ3vX3Acpuo2B";
        public static List<Photo> GetPhotosBySol(EnumRover rover,EnumCamera camera,int sol,int page=1)
        {
            if (!camera.IsEnabledOnRover(rover))
                throw new ArgumentException("This camera is not available on this rover", "camera");
            List<Photo> photos = new List<Photo>();
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("rovers/{rover}/photos?sol={sol}&camera={camera}&page={page}&api_key={api}", Method.GET);
            request.AddUrlSegment("rover", rover.ToString().ToLower());
            request.AddUrlSegment("sol", sol.ToString());
            request.AddUrlSegment("camera", camera.ToString().ToLower());
            request.AddUrlSegment("page", page);
            request.AddUrlSegment("api", API_KEY);
            IRestResponse<PhotoList> response2 = client.Execute<PhotoList>(request);
            return response2.Data.Photos;
        }

        public static List<Photo> GetPhotosByDate(EnumRover rover, EnumCamera camera, string date, int page = 1)
        {
            if (!camera.IsEnabledOnRover(rover))
                throw new ArgumentException("This camera is not available on this rover", "camera");
            List<Photo> photos = new List<Photo>();
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("rovers/{rover}/photos?earth_date={earth_date}&camera={camera}&page={page}&api_key={api}", Method.GET);
            request.AddUrlSegment("rover", rover.ToString().ToLower());
            request.AddUrlSegment("earth_date", date.ToString());
            request.AddUrlSegment("camera", camera.ToString().ToLower());
            request.AddUrlSegment("page", page);
            request.AddUrlSegment("api", API_KEY);
            IRestResponse<PhotoList> response2 = client.Execute<PhotoList>(request);
            return response2.Data.Photos;
        }

        public static string DownloadPhoto(Photo photo)
        {
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".jpg";

            WebClient Client = new WebClient();
            Client.DownloadFile(photo.ImgSrc, fileName);

            return fileName;
        }
    }
}
