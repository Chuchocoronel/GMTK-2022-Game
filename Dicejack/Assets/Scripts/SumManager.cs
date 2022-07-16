using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumManager : MonoBehaviour
{    
    private void Update()
    {

    }

    public int Sum(DiceBehaviour[] behaviours)
    {
        int total = 0;

        for (int i = 0; i < behaviours.Length; ++i)
        {
            total += behaviours[i].d6Dice;
        }

        //if (diceCounter == diceBehaviour.Length-1)
        //{
            
        //    diceCounter = -1;

        //}
        //if (diceCounter < diceBehaviour.Length)
        //{
        //    diceCounter++;
        //    total += diceBehaviour[diceCounter].d6Dice;
            
        //}

        return total;
    }

    public void Reset(int charTotal)
    {
        charTotal = 0;
    }
}
