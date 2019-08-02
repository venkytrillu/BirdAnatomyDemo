using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BirdContent : MonoBehaviour
{
    public static BirdContent instance;
    public Text title, desc;
    public Image imageRef;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
      
    }


    public void DestoryObject()
    {
        UIManager.instance.isShown = false;
        UIManager.instance.titleText.SetActive(true);
        UIManager.instance.worldCanvasPanel.SetActive(false);
        UIManager.instance.BtnCloseStatus(false);
        
    }



    public void SetReferenceImage(Sprite sprite)
    {
        imageRef.sprite = sprite;
    }

} // class
