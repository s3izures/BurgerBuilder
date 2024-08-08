using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnableOrders;
    [SerializeField] GameObject topBun; //Excluded so that it can be spawned last
    [SerializeField] GameObject botBun; //Excluded so that it can be spawned first

    [SerializeField] int orderMax = 6;
    [SerializeField] int orderMin = 3;

    void Start()
    {
        GenerateRandomOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateRandomOrder()
    {
        int orderAmt = Random.Range(orderMin, orderMax);

        for (int i = 0; i < orderAmt; i++)
        {
            if (i == 0)
            {
                Instantiate(botBun, transform);
            }
            else if (i < orderAmt - 1)
            {
                int orderType = Random.Range(0, spawnableOrders.Count);
                Instantiate(spawnableOrders[orderType], transform);
            }
            else
            {
                Instantiate(topBun, transform);
            }
        }
    }
}
