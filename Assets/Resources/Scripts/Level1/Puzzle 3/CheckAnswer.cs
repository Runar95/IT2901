using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CheckAnswer : MonoBehaviour
{
	private int lastChanged;
	private bool parsed;
	private int correctAnswers;
	private int totalSelected;
	
	public Flowchart flowchart;
	// Keeps the state of all the checkboxes. In the game; col 1-5 row 1 are represented by 0-4, and col 6-10 and row 2 are represented by 5-9.
	private bool[] suggestedSolution = {false, false, false, false, false, false, false, false, false, false};
	private bool[] solution = {true, true, false, false, false, true, false, true, false, false};

    void OnEnable() 
    {
        BlockSignals.OnBlockStart += OnBlockStart;
    }
    
    //Is fired on block start, updates the suggested solution based on user input, and sends feedback 
    void OnBlockStart(Block block)
    {
    	parsed = int.TryParse(block.BlockName, out lastChanged);
    	if (parsed) {
    		updateSuggestedSolution();
    	} else if (block.BlockName.Equals("CheckAnswers")) {
    		checkAnswer();
		}
   	}
    
    //Updates the suggested solution array, and variable tracking the number of correct answers
    void updateSuggestedSolution() {
    	suggestedSolution[lastChanged - 1] = !suggestedSolution[lastChanged - 1];
		correctAnswers = 0;
		totalSelected = 0;
		for (int i = 0; i < solution.Length; i++) {
			if (suggestedSolution[i].Equals(solution[i]) && solution[i].Equals(true)) {
				correctAnswers++;
			}
			if (suggestedSolution[i]) {
				totalSelected++;
			}
		}
    }
    
    //Executes the appropriate block, depending on the score
    void checkAnswer() {
    	if (flowchart != null) {
    		
    	
	    	if (totalSelected <=4) {
	    		switch (correctAnswers)
				{
					case 0:
						flowchart.ExecuteBlock("0/4");
						break;
					case 1:
						flowchart.ExecuteBlock("1/4");
						break;
					case 2:
						flowchart.ExecuteBlock("2/4");
						break;
					case 3:
						flowchart.ExecuteBlock("3/4");
						break;
					case 4:
						flowchart.ExecuteBlock("4/4");
						break;
				}
	    	} else {
	    		flowchart.ExecuteBlock("Too many selected");
	    	}
	    	
	    }
    }
}
