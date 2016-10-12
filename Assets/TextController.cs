using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	// Public variables
	public Text text; // public, since we want it available outside this controller
	public int score = 0;
	
	private enum States { // private since we don't want it available outside this controller
		cell, fork, sheets_0, lock_0, cell_fork, sheets_1, lock_1, 
		corridor_0, stairs_0, window_0, toolbox_0, corridor_hammer, stairs_1, window_1, toolbox_1, freedom
	};
	 
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell)			{cell ();}
		else if (myState == States.sheets_0)		{sheets_0();}
		else if (myState == States.lock_0)			{lock_0();}
		else if (myState == States.fork)			{fork();}
		else if (myState == States.cell_fork)		{cell_fork();}
		else if (myState == States.sheets_1)		{sheets_1();}
		else if (myState == States.lock_1)			{lock_1();}
		
		else if (myState == States.corridor_0)		{corridor_0();}
		else if (myState == States.stairs_0)		{stairs_0();}
		else if (myState == States.window_0)		{window_0();}
		else if (myState == States.toolbox_0)		{toolbox_0();}		
		else if (myState == States.corridor_hammer)	{corridor_hammer();}
		else if (myState == States.stairs_1)		{stairs_1();}
		else if (myState == States.window_1)		{window_1();}
		else if (myState == States.toolbox_1)		{toolbox_1();}
		else if (myState == States.freedom)			{freedom();}
	}
	
	// STATE METHODS
	
	#region InCellMethods
	// In the cell
	void cell () {
		text.text = "You wake up in some bullshit prison cell in Indonesia, with no idea how you got there." +
			" You are lying on some dirty-ass cot with stained-ass sheets wearing just pants." +
				" On the other side of the cell on another cot is another man. He introduces himself as" +
				" Brian Imanuel, AKA Rick Chigga. You don't know what that means. Also in the cell you find" +
				" a Rich Chigga album, some unidentifiable slop, a fork, and some mice." +
				" 'WTF did I do last night?', you think to yourself.\n\n" +
				"Your current score is: " + score + "\n\n" +
				" [Press S for Sheets, L for Lock, or F for Fork]";
		
		if(Input.GetKeyDown(KeyCode.S)){
			score++;
			myState = States.sheets_0;
		}
		
		if(Input.GetKeyDown (KeyCode.L)){
			myState = States.lock_0;
		}
		
		if(Input.GetKeyDown (KeyCode.F)){
			myState = States.fork;
		}
	}
	
	// Looking at sheets
	void sheets_0 () {
		text.text = "Gross, gross, gross. You don't want to even think about how many people" +
				" have slept in these sheets. There is nothing to see here, but ironically" +
				" there is so much you wish you could unsee.\n\n" +
				"Your current score is: " + score + "\n\n" +
				" [Press R to return to your cell]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	
	// Looking at lock
	void lock_0 () {
		text.text = "The huge old lock looks both sturdy as fuck and yet easily pickable." +
				" If only there were some small and pointy metal object in this cell that" +
				" you could use to pick the lock...\n\n" +
				"Your current score is: " + score + "\n\n" +
				" [Press R to return to your cell]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	
	// Looking at fork
	void fork () {
		text.text = "A small and pointy fork lies on the ground at your feet. It seems " +
				" extremely strong, yet pliable.\n\n" +
				"Your current score is: " + score + "\n\n" +
				" [Press T to take the fork or R to return to your cell]";
				
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
		
		if(Input.GetKeyDown(KeyCode.T)){
			myState = States.cell_fork;
		}
	}
	#endregion
	
	#region InCellWithForkMethods
	// In cell with fork
	void cell_fork () {
		text.text = "You're still standing in your bullshit prison cell, but this time" +
				" you're holding a fork.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press S for Sheets or L for Lock]";
		
		if(Input.GetKeyDown(KeyCode.S)){
			score++;
			myState = States.sheets_1;
		}
		
		if(Input.GetKeyDown (KeyCode.L)){
			myState = States.lock_1;
		}
	}
	
	// Looking at sheets with fork
	void sheets_1 () {
		text.text = "You furiously stab the filthy sheets with the fork screaming" +
				" 'This is all your fault! You'll burn in hell for what you've done to me!'." +
				" The sheets lay in a sad, crumpled pile. You're no closer to getting out of" +
				" this miserable cell, but you do feel a little bit better. As you turn from the bed" +
				" you notice Rich Chigga on his cot, staring at you with digust and fear.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to return to your cell]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_fork;
		}
	}
	
	// Looking at lock with fork
	void lock_1 () {
		text.text = "You look at the fork, then look at the lock. You then look up and into the distance and begin" +
				" to rub your chin thoughtfully. Again, you look at the fork, then look at the lock." +
				" 'I'm getting closer.', you think to yourself.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press P to try and pick the lock]";
		
		if(Input.GetKeyDown(KeyCode.P)){
			myState = States.corridor_0;
		}
	}
	#endregion
	
	#region InCorridorMethods
	// In the corridor
	void corridor_0 () {
		text.text = "You're standing in the corridor, having locked Rich Chigga in the cell behind you." +
					" To your left is a window, straight ahead of you is a toolbox, and to the right is stairs leading up.\n\n" +
					"Your current score is: " + score + "\n\n" +
					"[Press S to go up the stairs, T to search the toolbox, and W to go to the window]";
					
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_0;
		}
		
		if(Input.GetKeyDown(KeyCode.W)){
			myState = States.window_0;
		}
		
		if(Input.GetKeyDown(KeyCode.T)){
			myState = States.toolbox_0;
		}
		
	}
	
	// Looking at stairs
	void stairs_0 () {
		text.text = "You begin walking up the stairs but suddenly freeze as your hear guards voices up ahead." +
				" You cannot walk up the stairs without being caught.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to return to the corridor or Q to raise the score by 1]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
		
		if(Input.GetKeyDown(KeyCode.Q)){
			score++;
		}
	}
	
	// Looking at window
	void window_0 () {
		text.text = "You look out the window and notice that there are no guards. Who possibly could have left such a loophole" +
				" in a prison security system. You could defintely get out if you smash the window.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to return to the corridor]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}
	
	// Looking at toolbox
	void toolbox_0 () {
		text.text = "You open a bright red toolbox and notice a ton of tools, including a powerful looking hammer." +
				" A label on the side reads, 'Perfect for smashing windows!'.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to return to the corridor or T to take the hammer]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
		
		if(Input.GetKeyDown(KeyCode.T)){
			myState = States.corridor_hammer;
		}
	}
	#endregion
	
	#region InCorridorWithHammerMethods
	// In the corridor with a hammer
	void corridor_hammer () {
		text.text = "You are back in the corridor in front of your cell but" +
				" this time you're holding a hammer.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press S to go up the stairs, T to search the toolbox, and W to go to the window]";
		
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_1;
		}
		
		if(Input.GetKeyDown(KeyCode.W)){
			myState = States.window_1;
		}
		
		if(Input.GetKeyDown(KeyCode.T)){
			myState = States.toolbox_1;
		}
	}
	
	// At the stairs with a hammer
	void stairs_1 () {
		text.text = "You stand at the bottom of the stairs holding your hammer. You could probably" +
				" take one or two guards, but the rest would certainly kill you.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to return to the corridor or Q to raise the score by 1]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_hammer;
		}
		
		if(Input.GetKeyDown(KeyCode.Q)){
			score++;
		}
	}
	
	// At the toolbox with a hammer
	void toolbox_1 () {
		text.text = "You are about to smash apart the toolbox for it's cruelty, but then remember that's" +
				" where you found the hammer. Probably would alert the guards too.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to return to the corridor]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_hammer;
		}
	}
	
	// At the window with a hammer
	void window_1 () {
		text.text = "You're standing at the window with a hammer that reads, 'Great for smashing windows!', but" +
				" you're a bit at a loss as what to do.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to return to the corridor or S to smash the window]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_hammer;
		}
		
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.freedom;
		}
	}
	
	// Freedom
	void freedom () {
		text.text = "You quickly and efficiently smash through the window and make your leap to freedom, falling through" +
				" the open sunroof of a limosine, which squeals away into the night.\n\n" +
				"Your current score is: " + score + "\n\n" +
				"[Press R to restart the game]";
		
		if(Input.GetKeyDown(KeyCode.R)){
			score = 0;
			myState = States.cell;
		}
	}
	#endregion
	
}
