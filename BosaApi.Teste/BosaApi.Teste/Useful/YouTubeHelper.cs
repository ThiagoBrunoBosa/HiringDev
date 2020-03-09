using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BosaApi.Teste.Useful
{
    public static class YoutubeHelper
    {
        public static async Task<List<string>> YoutubeSearch(string researchTerm)
        {
            try
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyA8-miDs_sR6cC8OVuiuX-DOhavAQzrZ40",
                    ApplicationName = "Project 0"
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = researchTerm; // Replace with your search term.
                searchListRequest.MaxResults = 10;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = await searchListRequest.ExecuteAsync();

                List<string> videos = new List<string>();
                List<string> channels = new List<string>();
                List<string> playlists = new List<string>();

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {
                    videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                }

                return videos;

            }
            catch (Exception ex)
            {
                List<string> videos = new List<string>();

                videos.Add(ex.Message);

                return videos;
            }
        }
    }
}