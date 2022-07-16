using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheDice : MonoBehaviour
{
    public DiceBehaviour dice;
    public GameObject player;
    public GameObject d6DicePrefab;
    public bool diceToRoll;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RolltheDice()
    {
        if (dice)
        {
            dice.RollTheDice();
            dice = null;
            diceToRoll = false;
        }
    }

    public void HitDice()
    {
        player.GetComponent<PlayerManager>().AddDice(Instantiate(d6DicePrefab, player.transform.position, player.transform.rotation));
    }

    public void StandDice()
    {
        player.GetComponent<PlayerManager>().stand = true;
    }
}
