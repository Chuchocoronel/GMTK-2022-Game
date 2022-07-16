using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DicejackSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject[] coinLivesPlayer;
    public GameObject[] coinLivesEnemy;
    public Animator winAnimation;
    public Animator loseAnimation;
    public Animator drawAnimation;
    PlayerManager playerMan;
    EnemyManager enemyMan;
    public float targetTime = 2f;
    public GameObject d6DicePrefab;
    private IEnumerator coroutine;


    bool finishEnemy;

    void Start()
    {
        playerMan = player.GetComponent<PlayerManager>();
        playerMan.AddDice(Instantiate(d6DicePrefab, player.transform.position, player.transform.rotation));

        enemyMan = enemy.GetComponent<EnemyManager>();
        loseAnimation.SetBool("hasLost", false);
        winAnimation.SetBool("hasWon", false);
        drawAnimation.SetBool("hasDraw", false);
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
                loseAnimation.SetBool("hasLost", true);
                playerMan.lives--;
                coinLivesPlayer[playerMan.lives].SetActive(false);  
                playerMan.Reset();
                enemyMan.Reset(); 
                finishEnemy = false;
            }
            else if (enemyMan.total > 21)
            {
                winAnimation.SetBool("hasWon", true);
                enemyMan.lives--;
                coinLivesEnemy[enemyMan.lives].SetActive(false);
                playerMan.Reset();
                enemyMan.Reset();
                finishEnemy = false;
                
                
            }
            else if (playerMan.total > enemyMan.total)
            {
                winAnimation.SetBool("hasWon", true);
                enemyMan.lives--;    
                coinLivesEnemy[enemyMan.lives].SetActive(false);
                playerMan.Reset();
                enemyMan.Reset();
                finishEnemy = false;
            }
            else if (playerMan.total < enemyMan.total)
            {
                loseAnimation.SetBool("hasLost", true);
                playerMan.lives--;
                coinLivesPlayer[playerMan.lives].SetActive(false);
                playerMan.Reset();
                enemyMan.Reset();
                finishEnemy = false;
            }else if(playerMan.total == enemyMan.total)
            {
                drawAnimation.SetBool("hasDraw", true);
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

                coroutine = WaitAndPrint(2.0f);
                StartCoroutine(coroutine);

            }
        }
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        loseAnimation.SetBool("hasLost", false);
        winAnimation.SetBool("hasWon", false);
        drawAnimation.SetBool("hasDraw", false);
        playerMan.AddDice(Instantiate(d6DicePrefab, player.transform.position, player.transform.rotation));

    }
}
