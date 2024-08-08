using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    static public IngredientSpawner Instance;
    [SerializeField] private List<GameObject> spawnableIngredients;

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

    public void GenerateRandomIngredient()
    {
        int ingType = Random.Range(0, spawnableIngredients.Count);
        Instantiate(spawnableIngredients[ingType], transform);
    }
    public void ClearIngredients()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
