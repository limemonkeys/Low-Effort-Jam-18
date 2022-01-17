using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives;
    public List<string> toppingsOnPizza;
    public List<string> pizzaToppingsRequired;

    // Start is called before the first frame update
    void Start()
    {
        GenerateNextPizza();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTopping(string topping) 
    {
        toppingsOnPizza.Add(topping);
        Debug.Log(toppingsOnPizza);

        bool pizzaStatus = CheckPizzaComplete();
        print("PizzaFinished: " + pizzaStatus);
    }

    public void DecreaseLife() 
    {
        lives -= 1;
    }

    private void GenerateNextPizza() 
    {
        pizzaToppingsRequired.Clear();
        pizzaToppingsRequired.Add("Money Sauce Item");
        print("Next pizza: " + pizzaToppingsRequired.Count);
    }

    private bool CheckPizzaComplete() 
    {
        /*
        bool pizzaComplete = true;
        if (toppingsOnPizza.Count == pizzaToppingsRequired.Count) 
        {
            for (currTopping in toppingsOnPizza)
            {
                if (!pizzaToppingsRequired.Contains(currTopping))
                {
                    pizzaComplete = false;
                }
            }
        }
        else
        {
            pizzaComplete = false;
        }
        return pizzaComplete;
        */

        bool pizzaComplete = true;
        if (toppingsOnPizza.Count == pizzaToppingsRequired.Count)
        {
            foreach (string currTopping in toppingsOnPizza)
            {
                if (!pizzaToppingsRequired.Contains(currTopping))
                {
                    pizzaComplete = false;
                }
            }

        }
        else
        {
            pizzaComplete = false;
        }
        return pizzaComplete;
    }
}
