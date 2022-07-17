using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator animator;

    int levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        FadeToLevel(1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    void OnFadeComplete()
    {
        switch(levelToLoad)
        {
            case 1:
                SceneManager.LoadScene("Game");
                break;
            case 2:
                SceneManager.LoadScene("Lose");
                break;
            case 3:
                SceneManager.LoadScene("Win");
                break;
            case 4:
                SceneManager.LoadScene("MainMenu");
                break;
            case 5:
                SceneManager.LoadScene("DiffiultSellector");
                break;
            case 6:
                SceneManager.LoadScene("Easy");
                break;
            case 7:
                SceneManager.LoadScene("Hard");
                break;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
