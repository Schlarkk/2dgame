using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleAnimation : MonoBehaviour
{

    public SpriteRenderer Player;
    AudioSource audioSource;
    public Texture2D[] frames;
    public float fadeTime = 0.1f;
    int currentFrame = 0;

    public float damagedTime = 1f;
    public Texture2D damagedFrame;

    public GameObject deadParticles;
    public AudioClip deadSFX;

    public Texture2D movementSprite;
    bool isMoving = false;
    
    bool isDamaged = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isMoving && !isDamaged)
        {
            
        }

       // mover();
    }

    void mover()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            Player.sprite = Sprite.Create(movementSprite, new Rect(0, 0, movementSprite.width, movementSprite.height), new Vector2(0.5f, 0.5f));
            gameObject.transform.localScale = new Vector3(1.1f, 0.9f, 1.1f);
        } 
        else if(Input.GetKeyUp(KeyCode.A))
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            isMoving = false;
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            isMoving = false;
        }
    }

    public void damaged()
    {
        isDamaged = true;
        Player.enabled = false;
        
        CancelInvoke("ResetIdle");
        Invoke("ResetIdle", damagedTime);
    }

    void ResetIdle()
    {
        isDamaged = false;
        currentFrame = 0;
        Player.enabled = true;
        

    }

    public void dead()
    {
        isDamaged = true;
        Player.enabled = false;
        audioSource.PlayOneShot(deadSFX);
        deadParticles.SetActive(true);
    }

    void Idle()
    {
        if (Time.frameCount % Mathf.RoundToInt(1f / fadeTime) == 0)
        {
            currentFrame++;
            if (currentFrame >= frames.Length)
            {
                currentFrame = 0;
            }
            Player.sprite = Sprite.Create(frames[currentFrame], new Rect(0, 0, frames[currentFrame].width, frames[currentFrame].height), new Vector2(0.5f, 0.5f));
        }
    }
}
