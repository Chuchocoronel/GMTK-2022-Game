using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject rollButton;
    public GameObject hitButton;
    public GameObject standButton;

    RollTheDice scriptRoll;

    List<GameObject> dices = new List<GameObject>();

    Bounds square;

    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<SpriteRenderer>().bounds;
        scriptRoll = rollButton.GetComponent<RollTheDice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptRoll.diceToRoll && dices.Count > 0)
        {
            rollButton.SetActive(false);
            hitButton.SetActive(true);
            standButton.SetActive(true);
        }
    }

    public void AddDice(GameObject newDice)
    {
        rollButton.SetActive(true);

        newDice.transform.SetParent(transform);
        dices.Add(newDice);
        scriptRoll.dice = newDice.GetComponent<DiceBehaviour>();
        scriptRoll.diceToRoll = true;
    }
}
