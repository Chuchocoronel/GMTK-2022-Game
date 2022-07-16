using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public RollTheDice scriptRoll;
    public GameObject player;
    PlayerManager playerMan;
    public GameObject d6DicePrefab;

    public List<GameObject> dices = new List<GameObject>();

    Bounds square;

    public int total;

    public int lives;

    public bool stand;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<SpriteRenderer>().bounds;
        total = 0;
        timer = 0;
        playerMan = player.GetComponent<PlayerManager>();
        stand = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStep()
    {
        if (!stand)
        {
            timer += Time.deltaTime;

            if (timer >= 1)
            {
                if (total < 21 && playerMan.total >= total)
                {
                    AddDice(Instantiate(d6DicePrefab, transform.position, transform.rotation));
                    scriptRoll.RolltheDice();
                    Sum();
                }
                else if (total < 21 && playerMan.total < total)
                {
                    stand = true;
                }

                timer = 0;
            }
        }
    }

    public void AddDice(GameObject newDice)
    {
        newDice.transform.SetParent(transform);
        dices.Add(newDice);
        scriptRoll.dice = newDice.GetComponent<DiceBehaviour>();
        scriptRoll.diceToRoll = true;
        float dist = square.size.x / (dices.Count + 1);
        GameObject[] dicesArr = dices.ToArray();
        float totalDist = 0f;
        float origin = square.center.x - (square.size.x / 2);
        for (int i = 0; i < dicesArr.Length; ++i)
        {
            totalDist += dist;
            Vector3 pos = new Vector3(origin + totalDist, dicesArr[i].transform.position.y, 0);
            dicesArr[i].transform.SetPositionAndRotation(pos, dicesArr[i].transform.rotation);
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
