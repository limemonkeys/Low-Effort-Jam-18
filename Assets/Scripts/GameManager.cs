using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives;
    public List<string> toppingsOnPizza;
    public List<string> pizzaToppingsRequired;

    public List<string> availableToppings;
    public List<string> originalToppings;

    public GameObject movePizza;

    public GameObject PizzaSauce;
    public GameObject AlfredoSauce;
    public GameObject Cheese;
    public GameObject Bitcoin;
    public GameObject Dogecoin;
    public GameObject Ethereum;
    public GameObject Baldcoin;

    public GameObject customerPizzaSauce;
    public GameObject customerAlfredoSauce;
    public GameObject customerCheese;
    public GameObject customerBitcoin;
    public GameObject customerDogecoin;
    public GameObject customerEthereum;
    public GameObject customerBaldcoin;

    // Start is called before the first frame update
    void Start()
    {
        
        availableToppings.Add("Bitcoin Item");
        availableToppings.Add("Dogecoin Item");
        availableToppings.Add("Ethereum Item");
        availableToppings.Add("Baldcoin Item");
        originalToppings.Add("Bitcoin Item");
        originalToppings.Add("Dogecoin Item");
        originalToppings.Add("Ethereum Item");
        originalToppings.Add("Baldcoin Item");
        
        GenerateNextPizza();
    }
    
    public void AddTopping(string topping) 
    {
        if (topping == "Pizza Sauce Item")
        {
            PizzaSauce.SetActive(true);
        }
        if (topping == "Alfredo Sauce Item")
        {
            AlfredoSauce.SetActive(true);
        }
        if (topping == "Cheese Item")
        {
            Cheese.SetActive(true);
        }

        if (topping == "Bitcoin Item")
        {
            Bitcoin.SetActive(true);
        }
        if (topping == "Dogecoin Item")
        {
            Dogecoin.SetActive(true);
        }
        if (topping == "Ethereum Item")
        {
            Ethereum.SetActive(true);
        }
        if (topping == "Baldcoin Item")
        {
            Baldcoin.SetActive(true);
        }

        toppingsOnPizza.Add(topping);

        movePizza.GetComponent<MovePizza>().SetPizzaComplete(CheckPizzaComplete());
        
    }

    public void DecreaseLife() 
    {
        lives -= 1;
    }

    public void GenerateNextPizza()
    {

        toppingsOnPizza.Clear();
        pizzaToppingsRequired.Clear();
        availableToppings.Clear();
        ResetOrder();
        for (int i = 0; i < 4; i++) 
        {
            availableToppings.Add(originalToppings[i]);
        }
        
        int pizzaOrAlfredo = Random.Range(0, 2);
        if (pizzaOrAlfredo == 0)
        {
            pizzaToppingsRequired.Add("Pizza Sauce Item");
            customerPizzaSauce.SetActive(true);
            Debug.Log("Pizza Sauce Item");
        }
        else
        {
            customerAlfredoSauce.SetActive(true);
            pizzaToppingsRequired.Add("Alfredo Sauce Item");
            Debug.Log("Alfredo Sauce Item");
        }
        pizzaToppingsRequired.Add("Cheese Item");

        
        int numToppings = Random.Range(0, 5);
        Debug.Log("Num of toppings " + numToppings);

        for (int i = 0; i < numToppings; i++) 
        {
            Debug.Log("IN " + i);
            int ranNum = Random.Range(0, availableToppings.Count);
            Debug.Log("RANNUM" + ranNum);
            Debug.Log("AVAIL TOP COUNT" + availableToppings.Count);
            string chosenTopping = availableToppings[ranNum];
            Debug.Log("CHOSENTOPPING" + chosenTopping);

            Debug.Log(chosenTopping);
            if (chosenTopping == "Bitcoin Item") 
            {
                customerBitcoin.SetActive(true);
            }
            if (chosenTopping == "Dogecoin Item")
            {
                customerDogecoin.SetActive(true);
            }
            if (chosenTopping == "Ethereum Item")
            {
                customerEthereum.SetActive(true);
            }
            if (chosenTopping == "Baldcoin Item")
            {
                customerBaldcoin.SetActive(true);
            }

            pizzaToppingsRequired.Add(chosenTopping);
            availableToppings.RemoveAt(ranNum);
        } 

    }

    private bool CheckPizzaComplete() 
    {

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

    private void ResetOrder() 
    {
        customerPizzaSauce.SetActive(false);
        customerAlfredoSauce.SetActive(false);
        customerBitcoin.SetActive(false);
        customerDogecoin.SetActive(false);
        customerEthereum.SetActive(false);
        customerBaldcoin.SetActive(false);
    }

    public void ResetMyPizza()
    {
        PizzaSauce.SetActive(false);
        AlfredoSauce.SetActive(false);
        Cheese.SetActive(false);
        Bitcoin.SetActive(false);
        Dogecoin.SetActive(false);
        Ethereum.SetActive(false);
        Baldcoin.SetActive(false);
    }
}
