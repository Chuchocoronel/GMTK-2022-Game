using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DicejackSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    PlayerManager playerMan;
    EnemyManager enemyMan;

    public GameObject d6DicePrefab;

    bool finishEnemy;

    void Start()
    {
        playerMan = player.GetComponent<PlayerManager>();
        playerMan.AddDice(Instantiate(d6DicePrefab, player.transform.position, player.transform.rotation));

        enemyMan = enemy.GetComponent<EnemyManager>();
       
        finishEnemy = false;
    }

    
    void Update()
    {
        if (playerMan.total >= 21)
        {
            playerMan.stand = true;
        }
        if (enemyMan.total >= 21)
        {
            enemyMan.stand = true;
            finishEnemy = true;
        }

        if (playerMan.stand)
        {
            if (!finishEnemy)
            {
                enemyMan.stand = false;
                enemyMan.UpdateStep();
            }
        }

        if (enemyMan.stand && playerMan.stand)
        {
            if (playerMan.total > 21)
            {
                playerMan.lives--;
                playerMan.Reset();
                enemyMan.Reset(); 
                finishEnemy = false;
            }
            else if (enemyMan.total > 21)
            {
                enemyMan.lives--;
                playerMan.Reset();
                enemyMan.Reset();
                finishEnemy = false;
            }
            else if (playerMan.total > enemyMan.total)
            {
                enemyMan.lives--;
                playerMan.Reset();
                enemyMan.Reset();
                finishEnemy = false;
            }
            else if (playerMan.total < enemyMan.total)
            {
                playerMan.lives--;
                playerMan.Reset();
                enemyMan.Reset();
                finishEnemy = false;
            }

            if (playerMan.lives == 0 || enemyMan.lives == 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                playerMan.AddDice(Instantiate(d6DicePrefab, player.transform.position, player.transform.rotation));
            }
        }
    }
}
