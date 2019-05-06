using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SwinGameSDK;

static class InstructionImgController
{
	public static void DrawInstructionImg ()
	{
		SwinGame.ClearScreen ();
		SwinGame.DrawBitmap ("Instruction.png", 0, 0);
		SwinGame.DrawBitmap ("Instruction2.png", 400, 300);
		SwinGame.DrawText ("Here are the details you need to understand", Color.Azure, GameResources.GameFont ("Instruction"), 415, 150);
		SwinGame.DrawText ("You are now ready to play.", Color.Azure, GameResources.GameFont ("Instruction"), 15, 400);
		SwinGame.DrawText ("Press M to go to Menu and start playing.", Color.Azure, GameResources.GameFont ("Instruction"), 15, 430);
		SwinGame.DrawText ("We wish you the best of luck!", Color.Azure, GameResources.GameFont ("Instruction"), 15, 460);
	}

	public static void HandleImgInstructInput ()
	{
		if (SwinGame.KeyTyped (KeyCode.vk_m)) {
			GameController.SwitchState (GameState.ViewingMainMenu);
		} else if (SwinGame.KeyTyped (KeyCode.vk_ESCAPE)) {
			GameController.SwitchState (GameState.ViewingInstruction);
		}
	}
}