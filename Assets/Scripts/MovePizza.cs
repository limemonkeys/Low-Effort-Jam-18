using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePizza : MonoBehaviour
{
    private Rigidbody2D pizzaRB;
    public float speed;
    private float originalSpeed;
    public bool pizzaComplete;
    public Vector2 startingPosition;
    public GameObject gameManager;

    public AudioSource Cash1;
    public AudioSource Cash2;

    public AudioSource FogHorn;
    public AudioSource Farts;

    public AudioSource Monkey1;
    public AudioSource Monkey2;
    public AudioSource Monkey3;

    void Start() 
    {
        originalSpeed = speed;
        pizzaComplete = false;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pizzaComplete)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else 
        {
            speed += 20;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Pizza Checker") 
        {            
            originalSpeed += 10;
            speed = originalSpeed;
            transform.position = startingPosition;
            if (!pizzaComplete)
            {
                gameManager.GetComponent<GameManager>().DecreaseLife();
                RandomMonkey();
                FogHorn.Play();
                Farts.Play();
            }
            else 
            {
                RandomCash();
            }
            SetPizzaComplete(false);
            gameManager.GetComponent<GameManager>().ResetMyPizza();
            gameManager.GetComponent<GameManager>().GenerateNextPizza();
        }
    }

    public void SetPizzaComplete(bool pizzaComplete) 
    {
        this.pizzaComplete = pizzaComplete;
        
        
    }

    private void RandomMonkey()
    {
        int randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            Monkey1.Play();
        }
        else if (randNum == 1)
        {
            Monkey2.Play();
        }
        else 
        {
            Monkey3.Play();
        }
    }

    private void RandomCash()
    {
        int randNum = Random.Range(0, 2);
        if (randNum == 0)
        {
            Cash1.Play();
        }
        else
        {
            Cash2.Play();
        }
    }

}