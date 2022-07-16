using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalEnemy : MonoBehaviour
{
    public Text totalEnemy;
    public EnemyManager enemyManager;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        totalEnemy.text = "" + enemyManager.total;
    }
}
