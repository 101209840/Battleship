using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;
using static GameController;
using static UtilityFunctions;
using static GameResources;
using static DeploymentController;
using static DiscoveryController;
using static MenuController;
using static HighScoreController;

/// <summary>

/// ''' The EndingGameController is responsible for managing the interactions at the end

/// ''' of a game.

/// ''' </summary>

static class EndingGameController
{

	/// <summary>
	///     ''' Draw the end of the game screen, shows the win/lose state
	///     ''' </summary>
	public static void DrawEndOfGame ()
	{
		UtilityFunctions.DrawField (GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
		UtilityFunctions.DrawSmallField (GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

		if (HumanPlayer.Missed > 5 && _aiSetting == AIOption.Insane) {
			SwinGame.DrawTextLines ("NO MORE TURNS!", Color.White, Color.Transparent, GameResources.GameFont ("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());
			if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.vk_RETURN) || SwinGame.KeyTyped(KeyCode.vk_ESCAPE))
			GameController.SwitchState(GameState.ViewingMainMenu);
		} 
		else if (GameController.HumanPlayer.IsDestroyed) {
			SwinGame.DrawTextLines ("YOU LOSE!", Color.White, Color.Transparent, GameResources.GameFont ("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());

		} else {
			SwinGame.DrawTextLines ("-- WINNER --", Color.White, Color.Transparent, GameResources.GameFont ("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());

		}
				GameController.shipleft = 5;
				GameController.missleft = 15;
				GameController.showshipleft = "";
				GameController.showmissleft = "";
	}
    /// <summary>
    ///     ''' Handle the input during the end of the game. Any interaction
    ///     ''' will result in it reading in the highsSwinGame.
    ///     ''' </summary>
    public static void HandleEndOfGameInput()
    {
        if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.vk_RETURN) || SwinGame.KeyTyped(KeyCode.vk_ESCAPE))
        {
            HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
            GameController.EndCurrentState();
        }
    }
}
