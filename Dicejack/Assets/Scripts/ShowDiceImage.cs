using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDiceImage : MonoBehaviour
{
    SpriteRenderer renderer;
    
    public Sprite[] sprites;

    public DiceBehaviour behaviour;
    int diceNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sprite = sprites[behaviour.d6Dice];
    }
}
