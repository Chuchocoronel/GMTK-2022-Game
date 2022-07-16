using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumManager : MonoBehaviour
{
    public DiceBehaviour[] diceBehaviour;
    public int diceIndex = 0;
    public int diceCounter = -1;
    public int total;

    
    private void Update()
    {


        

    }
   

    public void Sum()
    {
        if (diceCounter == diceBehaviour.Length-1)
        {
            
            diceCounter = -1;

        }
        if (diceCounter < diceBehaviour.Length)
        {
            diceCounter++;
            total += diceBehaviour[diceCounter].d6Dice;
            
        }
    }

    public void Reset()
    {
        total = 0;
        diceCounter = -1;
    }
}
