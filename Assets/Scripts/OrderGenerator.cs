using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    static public OrderGenerator Instance;
    [SerializeField] List<GameObject> spawnableOrders;
    [SerializeField] GameObject topBun; //Excluded so that it can be spawned last
    [SerializeField] GameObject botBun; //Excluded so that it can be spawned first

    [SerializeField] int orderMax = 6;
    [SerializeField] int orderMin = 3;
    private int orderAmt;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance)
        {
            Destroy(this);
        }
    }

    public void GenerateRandomOrder()
    {
        orderAmt = Random.Range(orderMin, orderMax);

        for (int i = 0; i < orderAmt; i++)
        {
            if (i == 0)
            {
                Instantiate(botBun, transform);
                //Then add to list
            }
            else if (i < orderAmt - 1)
            {
                int orderType = Random.Range(0, spawnableOrders.Count);
                Instantiate(spawnableOrders[orderType], transform);
                //Then add to list
            }
            else
            {
                Instantiate(topBun, transform);
                //Then add to list
            }
        }
    }
    public void ClearOrder()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
