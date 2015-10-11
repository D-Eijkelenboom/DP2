﻿
namespace DuckHunt.Model.GameState
{
	public enum GameStateType
	{
		[GameStateInfoAttribute(typeof(MenuState))]
		menuState,
		[GameStateInfoAttribute(typeof(Level1State))]
		level1,
		[GameStateInfoAttribute(typeof(Level2State))]
		level2,
		[GameStateInfoAttribute(typeof(FinishedState))]
		finished,
		[GameStateInfoAttribute(typeof(PausedState))]
		pause,
		[GameStateInfoAttribute(typeof(GameOverState))]
		gameOver
	}
}
