using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
    public void ToHard()
    {
        SceneManager.LoadScene("Hard");

    }
    public void ToMedium()
    {
        SceneManager.LoadScene("Game");

    }
    public void ToEasy()
    {
        SceneManager.LoadScene("Easy");

    }
    public void ToDifficultySelection()
    {
        SceneManager.LoadScene("DiffiultSellector");
    }


}
