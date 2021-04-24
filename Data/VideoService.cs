using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace RVids.Data
{

    public class VideoService
    {
        
        private static string path2 = @"D:\Extras\";
        public static string GetRandomVideo()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, GetVideos().Count);
            
            return BuildVideoPath(randomIndex);
        }
	   
        public static string BuildVideoPath(int number) => $"http://{GetIpAddress()}:5000/Vids/{GetVideoName(number)}";
        
        private static string GetVideoName(int number) => GetVids()[number].Name;
        
        private static List<FileInfo> GetVids()
        {
            DirectoryInfo info = new DirectoryInfo(path2);
            List<FileInfo> files = info.GetFiles("*.mp4").OrderBy(v => v.Name).ToList();
	
            return files;
        }

        public static string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            // Gets the IP Address numbers
            string ipEntry = Dns.GetHostEntry(hostName).AddressList[3].ToString();
            return ipEntry;
        }

        public static List<Video> GetRandomList()
        {
            DirectoryInfo info = new DirectoryInfo(path2);
            FileInfo[] files = info.GetFiles("*.mp4");
            List<Video> videos = files.Select(file => new Video
                                     {
                                         VideoName = file.Name, VideoPath = $"http://{GetIpAddress()}:5000/{file.Name}"
                                     })
                                    .ToList();
            videos.Shuffle();
            
            return videos;
        }
        
        public static List<Video> GetVideos()
        {
            DirectoryInfo info = new DirectoryInfo(path2);
            FileInfo[] files = info.GetFiles("*.mp4");

            return files.Select(file => new Video {VideoName = file.Name, VideoPath = $"http://{GetIpAddress()}:5000/{file.Name}"}).ToList();
        }
    }

}