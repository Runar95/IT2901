using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearManController : NpcController
{
    //sets currentBlockNr on start
    void Start()
    {
        base.currentBlockNr = base.nrOfBlocks;
    }

    //overrides the method that sets what block should be set next
    //this particular implementation plays them in the opposite order of default
    protected override void UpdateOnClickBlock()
    {
        if(base.currentBlockNr >= 1)
        {
            base.onClickBlock = base.character.name + base.currentBlockNr;
            base.currentBlockNr--;
            return;
        }
        base.currentBlockNr = base.nrOfBlocks;
        UpdateOnClickBlock();
    }

}
