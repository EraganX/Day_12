using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public string currentColor;

    public SpriteRenderer spriteRenderer;

    public Color redColor;
    public Color blueColor;
    public Color puppleColor;
    public Color yellowColor;

    private Rigidbody2D rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomColor();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "ColorChanger")
        {
            SetRandomColor();
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "GameWin")
        {
            Time.timeScale = 0;
        }

        if (collision.tag != currentColor && collision.tag != "ColorChanger" && collision.tag != "GameWin")
        {
            GameManager.Instance.GameOverPanelActive();
        }
    }

    private void SetRandomColor()
    {
        int index = Random.Range(0,4);

        switch (index)
        {
            case 0:
                currentColor = "Red";
                spriteRenderer.color = redColor;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.color = yellowColor;
                break;
            case 2:
                currentColor = "Purpple";
                spriteRenderer.color = puppleColor;
                break;
            case 3:
                currentColor = "Blue";
                spriteRenderer.color = blueColor;
                break;
        }
    }

    private void OnBecameInvisible()
    {
        GameManager.Instance.GameOverPanelActive();
    }

    
}
