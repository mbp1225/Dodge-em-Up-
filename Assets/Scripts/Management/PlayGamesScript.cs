﻿using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayGamesScript : MonoBehaviour
{
	public static PlayGamesScript instance;

	void Awake()
    {
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
			
		}
		else if(instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
	}

	void Start ()
	{
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();

		SignIn();

		print("Started");
	}

	void SignIn()
	{
		Social.localUser.Authenticate((bool success) => {});
		print("Signed In");
	}

	#region Leaderboards

	public static void AddScoreToLeaderboard(string leaderboardId, long score)
	{
		Social.ReportScore(score, leaderboardId, success => {});
		print("Score Added");
	}

	public static void ShowLeaderboardsUI()
	{
		Social.ShowLeaderboardUI();
		print("Leaderboard Shown");
	}

	#endregion /Leaderboards
}
