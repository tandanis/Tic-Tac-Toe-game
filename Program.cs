using System;

public class TicTacToe
{
	public enum Sides : uint
	{
		X,
		O
	};
	
	private System.UInt32 m_uintCol = 3;
	private System.UInt32 m_uintRow = 3;
	public int[,] m_gameState;
	
	public TicTacToe()
	{
		int i, j;
		m_gameState = new int[this.m_uintCol, this.m_uintRow];
		for(i = 0; i < this.m_uintCol; i++)
		{
			for(j = 0; j < this.m_uintRow; j++)
			{
				this.m_gameState[i, j] = -1;
			}
		}
	}
	
	public void printState()
	{
		int i, j;

		for(i = 0; i < this.m_uintCol; i++)
		{
			for(j = 0; j < this.m_uintRow; j++)
			{
				if(this.m_gameState[i, j] == (int)Sides.X)
					Console.Write("X");
				else if(this.m_gameState[i, j] == (int)Sides.O)
					Console.Write("O");
				else
					Console.Write("*");
			}
			Console.Write("\n");
		}
	}
	
	public bool checkMove(Sides side)
	{
		System.UInt32 i, j;
		UInt32 counter = 0;
		
		//Iterating through X axis due to vertical knock-out
		for(i = 0; i < m_uintCol; i++, counter = 0)
		{
			for(j = 0; j < m_uintRow; j++)
			{
				// Check for X axis, if there is any dash been placed as vertically.
				if(this.m_gameState[i, j] == (int)side)
					counter++;
				
				if(counter >= this.m_uintRow)
					return false;
			}
		}
		
		//Iterating through Y axis due to cross knock-out
		for(i = 0, j = 0; i < m_uintCol; i++, j++)
		{
			// Check for Y axis, if there is any dash been placed as horizontally.
			if(this.m_gameState[i, j] == (int)side)
				counter++;

			if(counter >= this.m_uintRow)
				return false;
		}
		return true;
	}
	
	public void gameOver()
	{
		Console.Clear();
		Console.WriteLine("Game Over!");
	}
	
	public void makeMove(Sides side, System.UInt32 col, System.UInt32 row)
	{
		this.m_gameState[--col, --row] = (int)side;
		Console.Clear();
		this.printState();
		
		if(!this.checkMove(side))
			gameOver();
		
	}
}

public class Program
{
	public static void Main()
	{
		TicTacToe game = new TicTacToe();
		game.makeMove(TicTacToe.Sides.X, 1, 1);
		game.makeMove(TicTacToe.Sides.X, 1, 1);
		game.makeMove(TicTacToe.Sides.X, 1, 2);
		//game.makeMove(TicTacToe.Sides.X, 1, 3);
		game.makeMove(TicTacToe.Sides.X, 2, 1);
		game.makeMove(TicTacToe.Sides.X, 2, 2);
		game.makeMove(TicTacToe.Sides.O, 2, 3);
		game.makeMove(TicTacToe.Sides.O, 3, 3);
		game.makeMove(TicTacToe.Sides.O, 3, 2);
		game.makeMove(TicTacToe.Sides.X, 3, 1);
		
	}
}