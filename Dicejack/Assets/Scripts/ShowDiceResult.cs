using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDiceResult : MonoBehaviour
{
    Text resultText;
    public Button rollButton;

    public DiceBehaviour behaviour;
    int diceresult;

    // Start is called before the first frame update
    void Start()
    {
        resultText = GetComponent<Text>();
        resultText.text = "Dice: Not Rolled";
    }

    // Update is called once per frame
    void Update()
    {
        diceresult = behaviour.d6Dice;
        resultText.text = "Dice: " + diceresult.ToString();
    }
}
