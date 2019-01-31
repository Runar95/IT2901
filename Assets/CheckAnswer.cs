using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System.Linq;

public class CheckAnswer : MonoBehaviour
{
	private int lastChanged;
	private bool parsed;
	
	public Flowchart flowchart;
	
	// Keeps the state of all the checkboxes. In the game; col 1-5 row 1 are represented by 0-4, and col 6-10 and row 2 are represented by 5-9.
	private bool[] suggestedSolution = {false, false, false, false, false, false, false, false, false, false};
	private bool[] solution = {true, true, false, false, false, true, false, true, false, false};

    void OnEnable() 
    {
        // Register as listener for Block events
        BlockSignals.OnBlockStart += OnBlockStart;
    }
    
    //Finds the index of the checkbox that was most recently clicked on, and updates the 'suggestedSolution' array
    void OnBlockStart(Block block)
    {
    	parsed = int.TryParse(block.BlockName, out lastChanged);
    	if (parsed) {
    		suggestedSolution[lastChanged - 1] = !suggestedSolution[lastChanged - 1];
    		if (solution.SequenceEqual(suggestedSolution)) {
    			flowchart.ExecuteBlock("Puzzle solved");
    		}	
    	} 
    }
}
