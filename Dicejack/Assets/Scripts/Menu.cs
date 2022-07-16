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

    void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Scena Charlie");
    }

    void OnFadeComplete()
    {
        switch(levelToLoad)
        {
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }
}
