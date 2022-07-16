using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPlayer : MonoBehaviour
{
    public Text totalPlayer;
    public PlayerManager playerManager;
   
    // Update is called once per frame
    void Update()
    {
        totalPlayer.text = "" + playerManager.total;
    }
}
