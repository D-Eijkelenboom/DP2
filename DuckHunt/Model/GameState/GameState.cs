using DuckHunt.Model.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.GameState
{
	public interface GameState
	{
		ActionContainer ActionContainer { get; set; }
		MainContainer MainContainer { get; set; }
		GameStateManager GSM { get; set; }

		void init(GameStateManager gsm);
		void cleanup();
		void pause();
		void resume();

		void handleInput();
		void update(double dt);
		void draw();

	}
}
