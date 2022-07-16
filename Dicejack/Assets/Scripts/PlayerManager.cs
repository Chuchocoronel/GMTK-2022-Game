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

    public int total;

    public int lives;

    public bool stand;

    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<SpriteRenderer>().bounds;
        total = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptRoll.diceToRoll && dices.Count > 0 && !stand)
        {
            rollButton.SetActive(false);
            hitButton.SetActive(true);
            standButton.SetActive(true);

            Sum();
        }

        if (stand)
        {
            rollButton.SetActive(false);
            hitButton.SetActive(false);
            standButton.SetActive(false);
        }
    }

    public void AddDice(GameObject newDice)
    {
        rollButton.SetActive(true);
        hitButton.SetActive(false);
        standButton.SetActive(false);
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
    }

    public void Sum()
    {
        total = 0;

        GameObject[] dicesArr = dices.ToArray();

        for (int i = 0; i < dicesArr.Length; ++i)
        {
            total += dicesArr[i].GetComponent<DiceBehaviour>().d6Dice;
        }
    }

    public void Reset()
    {
        total = 0;
        GameObject[] dicesArr = dices.ToArray();
        for (int i = 0; i < dicesArr.Length; ++i)
        {
            Destroy(dicesArr[i]);
        }
        dices.Clear();
        stand = false;
    }
}
