using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumManager : MonoBehaviour
{
    List<DiceBehaviour> diceBehaviour = new List<DiceBehaviour>();

    public int total;

    
    private void Update()
    {


        

    }

    public int Sum(DiceBehaviour[] behaviours)
    {
        DiceBehaviour[] behaviourArr = diceBehaviour.ToArray();

        total = 0;

        for (int i = 0; i < behaviourArr.Length; ++i)
        {
            total += behaviourArr[i].d6Dice;
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
