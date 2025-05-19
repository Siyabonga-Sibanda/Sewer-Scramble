using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    //Button parameters
    public bool isOn;
    [SerializeField] private bool isHeld;
    [SerializeField] private AudioSource clickSound;

    //Sprites for when button is on or off
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    void Start()
    {
        isOn = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = offSprite;
    }

    // Collision check for pushed buttons
    private void OnCollisionEnter2D(Collision2D collision)
    {
        clickSound.Play();
        if (!isOn && !isHeld)
        {
            isOn = true;
            spriteRenderer.sprite = onSprite;
            clickSound.Play();
        }

        else if (isOn && !isHeld) 
        {
            isOn = false;
            spriteRenderer.sprite = offSprite;
            clickSound.Play();
        }
    }

    //Collision checks for buttons that are held

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isHeld)
        {
            isOn = true;
            spriteRenderer.sprite = onSprite;
        }

        if (!isOn && isHeld)
        {
            clickSound.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isHeld) 
        {
            isOn = false;
            spriteRenderer.sprite = offSprite;
            clickSound.Play();
        }
    }
}
