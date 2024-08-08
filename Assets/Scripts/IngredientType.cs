using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientType : MonoBehaviour
{
    [SerializeField] Type type;
    [SerializeField] bool isOrder = false;

    private void Start()
    {
        if (!isOrder)
        {
            GameManager.Instance.SetCurrentIngredient(type);
        }
        else
        {
            GameManager.Instance.AddToList(type, true);
        }
    }

    public enum Type
    {
        Beef,
        Tomato,
        Lettuce,
        Cheese,
        TopBun,
        BottomBun
    }
}
