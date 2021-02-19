using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public Text scoreText;
    private int points;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float flapHeight;
    public GameObject pipe_up;
    public GameObject pipe_down;

    
    // Use this for initialization
    void Start () {
        points = 0;
        rb = GetComponent<Rigidbody2D>();
        BuildLevel();
    }

    void BuildLevel()
    {
        Instantiate(pipe_down, new Vector3(14, 10), transform.rotation);
        Instantiate(pipe_up, new Vector3(14, -10), transform.rotation);

        Instantiate(pipe_down, new Vector3(22, 5), transform.rotation);
        Instantiate(pipe_up, new Vector3(22, -15), transform.rotation);

        Instantiate(pipe_down, new Vector3(34, 0), transform.rotation);
        Instantiate(pipe_up, new Vector3(34, -20), transform.rotation);

        Instantiate(pipe_down, new Vector3(46, 8), transform.rotation);
        Instantiate(pipe_up, new Vector3(46, -12), transform.rotation);

        Instantiate(pipe_down, new Vector3(57, 6), transform.rotation);
        Instantiate(pipe_up, new Vector3(57, -14), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, flapHeight);
        }

        

        if (transform.position.y > 18 || transform.position.y <= -19)
        {
            Death();
        }

       
       scoreText.text = "Score: " + points.ToString();
        points++;
    }


    public void Death()
    {
        if (points > PlayerPrefs.GetInt("LevelHardScore"))
        {
            PlayerPrefs.SetInt("LevelHardScore", points);
            PlayerPrefs.Save();
        }

        rb.velocity = Vector3.zero;
        transform.position = new Vector2(0, 0);
        BuildLevel();
    }
}