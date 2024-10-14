using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Exceptions;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    string leaderboardId = "Zone_IO_Leaderboard";
    public InputField playerNameInputField;  // For player to input their name
   // public Text leaderboardDisplay;         // Text UI element to display leaderboard
    public Button submitButton,showLeaderBoardButton;

    public GameObject entryPrefab; // Drag your UI panel prefab here
    public Transform contentParent; // Drag your Content gameObject from the Scroll View here

    async void Start()
    {

        showLeaderBoardButton.onClick.AddListener(ShowLeaderboard);
        // Initialize Unity Gaming Services
        //await UnityServices.InitializeAsync();


        // Add listener to submit button
        //submitButton.onClick.AddListener(() =>
        //{
        //    playerName = playerNameInputField.text;  // Get player name from input field
        //    SubmitScoreToLeaderboard(100);           // Example score submission, replace with actual score
        //});
    }
    private async void Update()
    {
        if (CloudSaveManager.UpdateLeaderBoard)
        {
             SubmitScoreToLeaderboard(CloudSaveManager.coin);
            CloudSaveManager.UpdateLeaderBoard = false;
        }
    }
    // Submit player's score and name to leaderboard
    public async void SubmitScoreToLeaderboard(int score)
    {
      /*  if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogError("Player name is empty. Cannot submit score.");
            return;
        }

        // Set player display name in Unity Authentication
        await SetPlayerDisplayName(playerName);
        */
        try
        {
            // Submit player's score to leaderboard
            await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardId, score);
            Debug.Log($"Score {score} submitted to leaderboard {leaderboardId}");

            // Fetch and display the leaderboard after submission
            await FetchLeaderboard();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to submit score: {e.Message}");
        }
    }

    // Set player display name
    

    // Fetch and display the leaderboard
    private async Task FetchLeaderboard()
    {
        try
        {
            // Fetch leaderboard entries, limited to top 10
            var leaderboardResponse = await LeaderboardsService.Instance.GetScoresAsync(leaderboardId);
            string leaderboardText = "Leaderboard:\n";

            // Display player names and positions
            int position = 1;
            foreach (var entry in leaderboardResponse.Results)
            {
                leaderboardText = $"{position}. {entry.PlayerName} - {entry.Score}";

                GameObject newEntry = Instantiate(entryPrefab, contentParent);
                Text positionText = newEntry.GetComponentInChildren<Text>();
                positionText.text = leaderboardText;
                Debug.Log(leaderboardText);
                position++;
            }
            Debug.Log("leaderboardResponse.Results: " + leaderboardResponse.Results);
            //leaderboardDisplay.text = leaderboardText;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to fetch leaderboard: {e.Message}");
        }
    }
    async void ShowLeaderboard()
    {
        await FetchLeaderboard();
        //await DisplayLeaderboard();
    }

    
}