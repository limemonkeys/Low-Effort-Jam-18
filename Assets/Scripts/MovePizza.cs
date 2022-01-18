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
            speed += 10;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Pizza Checker") 
        {
            SetPizzaComplete(false);
            originalSpeed += 10;
            speed = originalSpeed;
            transform.position = startingPosition;
            if (!pizzaComplete) 
            {
                gameManager.GetComponent<GameManager>().DecreaseLife();
            }
            gameManager.GetComponent<GameManager>().ResetMyPizza();
        }
    }

    public void SetPizzaComplete(bool pizzaComplete) 
    {
        this.pizzaComplete = pizzaComplete;
        if (pizzaComplete) 
        {
            gameManager.GetComponent<GameManager>().GenerateNextPizza();
        }
    }

    

}