using Unity.Services.Leaderboards;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using System.Threading.Tasks;

public class DisplayLeaderboard : MonoBehaviour
{
    public Text leaderboardText;
    public GameObject leaderboardPanel;
    public ScrollRect leaderboardScrollView;

    public async void ShowLeaderboard()
    {
        leaderboardText.text = "Fetching leaderboard...";
        
        // Get top 20 players from the leaderboard
        var leaderboardEntries = await LeaderboardsService.Instance.GetScoresAsync("CoinLeaderboard", new GetScoresOptions { Offset = 0, Limit = 20 });


        leaderboardText.text = "";
        int rank = 1;
        foreach (var entry in leaderboardEntries.Results)
        {
            string playerName = entry.PlayerName;
            int playerCoins = (int)entry.Score;

            leaderboardText.text += $"{rank}. {playerName} - {playerCoins} coins\n";
            rank++;
        }
    }
    public async void SubmitScore(int coins)
    {
        string playerName = await GetPlayerName();

        // Submit the player's coin count to the leaderboard
        await LeaderboardsService.Instance.AddPlayerScoreAsync("CoinLeaderboard", coins);

        Debug.Log("Score submitted successfully!");
    }

    private async Task<string> GetPlayerName()
    {
        var data = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "PlayerName" });
        return data["PlayerName"].ToString();
    }
    public Text playerRankText;
    public async void ShowPlayerRank()
    {
        string playerName = await GetPlayerName();

        // Fetch leaderboard entries, assuming we fetch more than enough entries to include the player
        var leaderboardScores = await LeaderboardsService.Instance.GetScoresAsync("CoinLeaderboard", new GetScoresOptions { Offset = 0, Limit = 100 });

        int rank = 1; // Initial rank position
        bool playerFound = false;

        foreach (var entry in leaderboardScores.Results)
        {
            if (entry.PlayerName == playerName)
            {
                playerRankText.text = $"Player {playerName} is ranked {rank} with {entry.Score} coins.";
                playerFound = true;
                break;
            }
            rank++;
        }

        if (!playerFound)
        {
            playerRankText.text = "Player not found in the top leaderboard entries.";
        }
    }
   
    
}
