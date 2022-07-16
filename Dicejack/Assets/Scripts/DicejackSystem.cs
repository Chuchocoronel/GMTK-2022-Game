using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicejackSystem : MonoBehaviour
{
    public GameObject player;

    public GameObject d6DicePrefab;

    void Start()
    {
        player.GetComponent<PlayerManager>().AddDice(Instantiate(d6DicePrefab, player.transform.position, player.transform.rotation));
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.GetComponent<PlayerManager>().AddDice(Instantiate(d6DicePrefab, player.transform.position, player.transform.rotation));
        }
    }
}
