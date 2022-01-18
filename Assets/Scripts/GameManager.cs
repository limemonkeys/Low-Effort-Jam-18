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

    public AudioSource Splat1;
    public AudioSource Splat2;
    public AudioSource Splat3;

    public AudioSource Coins1;
    public AudioSource Coins2;
    public AudioSource Coins3;

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
            RandomSplat();
            PizzaSauce.SetActive(true);
        }
        if (topping == "Alfredo Sauce Item")
        {
            RandomSplat();
            AlfredoSauce.SetActive(true);
        }
        if (topping == "Cheese Item")
        {
            RandomSplat();
            Cheese.SetActive(true);
        }

        if (topping == "Bitcoin Item")
        {
            RandomCoin();
            Bitcoin.SetActive(true);
        }
        if (topping == "Dogecoin Item")
        {
            RandomCoin();
            Dogecoin.SetActive(true);
        }
        if (topping == "Ethereum Item")
        {
            RandomCoin();
            Ethereum.SetActive(true);
        }
        if (topping == "Baldcoin Item")
        {
            RandomCoin();
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

    private void RandomCoin()
    {
        int randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            Coins1.Play();
        }
        else if (randNum == 1)
        {
            Coins2.Play();
        }
        else
        {
            Coins3.Play();
        }
    }

    private void RandomSplat()
    {
        int randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            Splat1.Play();
        }
        else if (randNum == 1)
        {
            Splat2.Play();
        }
        else
        {
            Splat3.Play();
        }
    }
}
