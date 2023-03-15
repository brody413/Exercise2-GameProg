using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NetController : MonoBehaviour
{
    // Variables
    //Rigid body for applying physics
    private Rigidbody2D rb;
    private float Speed = 6f;
    public Text TxtonScreen;
    public TextMeshProUGUI txtGameOver;
    private int Score = 0;

    //GameObject
    public GameObject gamePanel;
    

    // Use awake method
    void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>(); // set the rigidbody
        gamePanel.SetActive(false); // sets the game over screen to false
    }

    // Update is called once per frame
    void Update()
    {
        // checks for x input
        float x = Input.GetAxisRaw("Horizontal");
        // sets y to 0 so we cant move up and down
        float y = 0;

        // uses a vector to create my taregt point
        Vector2 targetVector = new Vector2(x, y);
        Move(targetVector.normalized); // calls my move method
    
    }

    // move net method
    private void Move(Vector2 targetDirection)
    {
        rb.velocity = targetDirection * Speed; // applys velocity to the object so it will move
    }

    // oncollision method for bomb and fish
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // checks the tag of fish
        if (collision.gameObject.tag == "Fish")
        {
            // if it collides, desotry the fish and increase the score 
            Destroy(collision.gameObject);
            Score++;
            TxtonScreen.text = "Score: " + Score; // place score on screen

        }
        // checks collision of bomb
        else if (collision.gameObject.tag == "Bomb")
        {
            // if collision destory bomb
            Destroy(collision.gameObject);
            gamePanel.SetActive(true); // set game over screen to true
            txtGameOver.text = "Score: " + Score; // add score to game over screen
        }


        
    }
}
