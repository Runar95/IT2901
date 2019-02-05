using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/*

This class is meant to handle dialog for characters in the game. One simply has to add this script as a component 
to npc's that one would like to perform dialog. 

By default an npc will at any time have one block of dialog to perform. If the paramter is set that the npc has more
blocks to perform (nrOfBlocks > 1) than 1, the scripts will set those blocks to be performed in sequential order
(if using this default option make sure to name dialog boxes as <charactername>1, <charactername>2 etc)

If one would like to play dialog in any other order than default, simply make a new script, inherit from this one, and override UpdateOnClickBlock
Also consider adding a start method
 
*/
public class NpcController : MonoBehaviour
{
    //flowchart on which blocks related to npc is situated
    public Flowchart flowchart;

    //character connected to a given npc
    public Character character;
    
    //the block to be called next time one clicks the npc
    protected string onClickBlock;

    //current block number
    //by default, one should start at 0
    protected int currentBlockNr = 0;

    //total number of blocks
    public int nrOfBlocks = 1;


    protected virtual void UpdateOnClickBlock()
    {
        if (this.currentBlockNr < nrOfBlocks)
        {
            this.currentBlockNr++;
            this.onClickBlock = character.name + currentBlockNr;
        }
    }


    //Executes a block with name = blockname if it exists 
    protected void ExecuteSpecificBlock(string blockName)
    {
        try
        {
            flowchart.ExecuteBlock(blockName);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }

    }


    //run when sprite is clicked on
    public void OnMouseDown()
    {
        Debug.Log("Clicking " + this.character.name + " works like a motherfucking charm");
        bool isFree = DialogController.ClaimDialog(this.flowchart);
        if (isFree)
        {
            UpdateOnClickBlock();
            ExecuteSpecificBlock(this.onClickBlock);
            DialogController.ReleaseDialog();
        }      
    }
}
