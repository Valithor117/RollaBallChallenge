using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;


    private Rigidbody rb;
    private int count;
    private int score;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText();
        winText.text = "";
        SetScoreText();
    }

    void FixedUpdate()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }

        
        { 
        if (Input.GetKey("escape"))
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
            count = count + 1;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("badPickup"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetScoreText();
        }
    }

          
    void SetCountText ()
    {
        countText.text = "<i>Count: " + count.ToString() + "</i>";

        if (count == 12)
        {
            transform.position = new Vector3(60, 2, 0.0f);
        }

        if (count >= 20)
        {
            winText.text = "<b>You got all the boxes!</b>";
        }
    }

    void SetScoreText ()
    {
        scoreText.text = "<i>Score: " + score.ToString() +"</i>";

    }
}