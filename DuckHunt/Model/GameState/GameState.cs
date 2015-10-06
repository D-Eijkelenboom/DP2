using DuckHunt.Model.Container;

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
