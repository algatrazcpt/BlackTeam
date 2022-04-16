using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemImageControl : MonoBehaviour
{
    public Sprite[] itemImages;
    public Image image;
    public void Start()
    {
        image.sprite = itemImages[0];
    }
    public void ItemMaterialChange(int value,bool isOpen)
    {
        if (isOpen)
        {
            image.sprite = itemImages[value+1];
        }
        else
        {
            image.sprite = itemImages[0];
        }
        
    }
}
