using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungreBeePlayer : MonoBehaviour
{
    private int score = 0;

    public Text scoreText;
    public Text gameOver;

    public GameObject redFlower1;
    public GameObject redFlower2;
    public GameObject orangeFlower1;
    public GameObject orangeFlower2;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject purpleFlower;
    public GameObject lava;

    private void Start()
    {
        StartCoroutine("CorutineMakeLava");
    }

    public IEnumerator CorutineMakeLava()
    {
        for (int i = -179; i <= 0; i += 3)
        {
            for (int j = 30; j >= -30; j-=2)
            {
                Instantiate(lava, new Vector3(i, j, 0), lava.transform.rotation);

                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    private void RedFlowerDoor()
    {
        if(redFlower1 == null)
        {
            door1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
            if (door1.transform.position.y > 12.0f)
            {
                door1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }

            door3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
            if(door3.transform.position.y > -3)
            {
                door3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
        }
    }

    private void OrangeFlowerDoor()
    {
        if (orangeFlower1 == null)
        {
            
            door1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10, 0);
            if (door1.transform.position.y < -9.4f)
            {
                door1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }

            door2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10, 0);
            if (door2.transform.position.y < -7.3f)
            {
                door2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
        }
    }

    private void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        StopCoroutine("CorutineMakeLava");
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }

    private void CollisionFlower(int flowerScore)
    {

        score = score + flowerScore;
        scoreText.text = "Score: " + score;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Lava")
        {
            GameOver();
        }

        if (col.gameObject.tag == "Flower")
        {

            Destroy(col.gameObject);
            CollisionFlower(5);
        }

        if (col.gameObject.tag == "redFlower")
        {
            
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
            CollisionFlower(5);
            Destroy(orangeFlower2);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "orangeFlower")
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
            CollisionFlower(5);
            Destroy(redFlower2);
            Destroy(col.gameObject);
        }
    }

    public void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10.0f, 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10.0f, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-10.0f, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(10.0f, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }

    void Update()
    {
        PlayerControl();
        RedFlowerDoor(); 
        OrangeFlowerDoor();
        if (purpleFlower == null)
        {
            GameOver();
        }
    }
}
