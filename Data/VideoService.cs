using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace RVids.Data
{

    public class VideoService
    {
        private const string path =
            @"C:\Users\dakil\OneDrive\Humble\Machine Learning\The Complete Machine Learning Course with Python\thecompletemachinelearningcoursewithpython_video\Section 2";
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
            DirectoryInfo info = new DirectoryInfo(path);
            List<FileInfo> files = info.GetFiles("*.mp4").OrderBy(v => v.Name).ToList();
	
            return files;
        }

        public static string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            // Gets the 0.0.0.0 numbers
            string ipEntry = Dns.GetHostEntry(hostName).AddressList[2].ToString();

            return ipEntry;
        }

        public static List<Video> GetVideos()
        {
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] files = info.GetFiles("*.mp4");

            return files.Select(file => new Video {VideoName = file.Name, VideoPath = $"http://{GetIpAddress()}:5000/{file.Name}"}).ToList();
        }
    }

}