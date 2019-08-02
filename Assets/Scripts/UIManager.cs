using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Button flyBtn;
    public Slider slider;
    public GameObject player;
    private Animator anim;
    public GameObject worldCanvasPanel;
    public GameObject titleText;
    public GameObject btnClose;
    public Material mat_color,mat_NoColor;
    public Sprite eyeSprite,legsSprite,mouthSprite,wingsSprite, downPartSprite;
    bool isfly;
    public bool isShown;
    GameObject hitGameObject;
    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }
    void Start()
    {
        isfly = true;
        anim = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Zoom()
    {
        Vector3 scale = new Vector3(slider.value, slider.value, slider.value);
        player.transform.localScale = scale;
    }

    void Update()
    {
        RaycastObject();
    }

    public void AnimationFly()
    {
        if(isfly)
        {
            isfly = false;
            SetAnimtion("Fly", true);
            flyBtn.GetComponent<Image>().color = Color.red;
        }
        else
        {
            isfly = true;
            SetAnimtion("Fly", false);
            flyBtn.GetComponent<Image>().color = Color.gray;
        }
    }

    public void BtnCloseStatus(bool status)
    {
        btnClose.SetActive(status);
    }

    void SetAnimtion(string actionName,bool status)
    {
        anim.SetBool(actionName, status);
    }
    Ray ray;
    RaycastHit hit;

    void RaycastObject()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
           if (Input.GetMouseButtonUp(0) && !isShown)
           {
                if (hit.transform.gameObject.name == "Eye")
                {
                    TriggerObject();
                    worldCanvasPanel.GetComponent<BirdContent>().SetReferenceImage(eyeSprite);
                }
                if (hit.transform.gameObject.name == "Mouth")
                {
                    TriggerObject();
                    worldCanvasPanel.GetComponent<BirdContent>().SetReferenceImage(mouthSprite);
                }
                if (hit.transform.gameObject.name == "DownFeature")
                {
                    TriggerObject();
                    worldCanvasPanel.GetComponent<BirdContent>().SetReferenceImage(downPartSprite);
                }
                if (hit.transform.gameObject.name == "Wing")
                {
                    TriggerObject();
                    worldCanvasPanel.GetComponent<BirdContent>().SetReferenceImage(wingsSprite);
                }
                if (hit.transform.gameObject.name == "Talons" )
                {
                    TriggerObject();
                    worldCanvasPanel.GetComponent<BirdContent>().SetReferenceImage(legsSprite);
                }

                //isShown = true;


            }

            titleText.GetComponent<TextMesh>().text = hit.transform.gameObject.name;
            hitGameObject = hit.transform.gameObject;
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = mat_color;
          //  print(hit.transform.gameObject.name);
        }
        else
        {
           
            if (hitGameObject!=null)
            {
                print(hitGameObject.name);
                hitGameObject.GetComponent<MeshRenderer>().material = mat_NoColor;
                titleText.GetComponent<TextMesh>().text = "";
                hitGameObject = null;
            }
            
        }
    }


    void TriggerObject()
    {
        titleText.SetActive(false);
        worldCanvasPanel.SetActive(true);
        worldCanvasPanel.GetComponent<BirdContent>().title.text = hit.transform.gameObject.name;
        worldCanvasPanel.GetComponent<BirdContent>().desc.text = hit.transform.GetComponent<Text>().text;
        BtnCloseStatus(true);
        isShown = true;
    }

}// class




























