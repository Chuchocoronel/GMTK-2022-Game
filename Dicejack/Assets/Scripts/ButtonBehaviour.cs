using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public AudioClip hover;
    public AudioClip click;
    public AudioSource audioSource;
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        audioSource.PlayOneShot(click);

    }
    
}
