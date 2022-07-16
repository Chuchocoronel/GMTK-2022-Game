using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject rollButton;
    public GameObject hitButton;
    public GameObject standButton;

    public RollTheDice scriptRoll;

   public List<GameObject> dices = new List<GameObject>();

    Bounds square;

    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<SpriteRenderer>().bounds;
        
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
        float dist = square.size.x / (dices.Count+1);
        GameObject[] dicesArr = dices.ToArray();
        float totalDist = 0f;
        float origin = square.center.x - (square.size.x / 2);
        for(int i = 0; i < dicesArr.Length; ++i)
        {
            totalDist += dist;
            Vector3 pos = new Vector3(origin + totalDist, dicesArr[i].transform.position.y, 0);
            dicesArr[i].transform.SetPositionAndRotation( pos, dicesArr[i].transform.rotation);
        }
        rollButton.SetActive(true);
        hitButton.SetActive(false);
        standButton.SetActive(false);
    }
}
