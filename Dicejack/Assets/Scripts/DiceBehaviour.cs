using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehaviour : MonoBehaviour
{
    public int dice;
    public int d6Dice;

    public float[] percentatgesD6;

    // Start is called before the first frame update
    void Start()
    {
        dice = 0;
        d6Dice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollTheDice()
    {
        dice = Random.Range(1,101);
        Dice_d6();
    }

    void Dice_d6()
    {
        float sum = 0;

        for (int i = 0; i < percentatgesD6.Length; ++i)
        {
            sum += percentatgesD6[i];
            if (dice <= sum)
            {
                d6Dice = i + 1;
                break;
            }
        }
    }
}
