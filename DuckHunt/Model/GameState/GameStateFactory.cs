using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckHunt.Helper;

namespace DuckHunt.Model.GameState
{
	public class GameStateFactory
	{
		public static GameState createGameState(GameStateType gameState)
		{
			var gameStateAttribute = gameState.GetAttribute<GameStateInfoAttribute>();
			if (gameStateAttribute == null)
			{
				return null;
			}
			var type = gameStateAttribute.Type;
			GameState result = Activator.CreateInstance(type) as GameState;
			return result;
		}
	}
}
