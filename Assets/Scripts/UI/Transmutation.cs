using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class Transmutation : MonoBehaviour
{
    public static Transmutation instance;

    public GameObject transmuteUI;
    public GameObject image1;
    public GameObject image2;

    public int choice = 0;
    public bool choiceMade = false;

    //SPRITES
    [SerializeField] private Sprite helm;
    [SerializeField] private Sprite chest;
    [SerializeField] private Sprite gloves;
    [SerializeField] private Sprite legs;
    [SerializeField] private Sprite boots;
    [SerializeField] private Sprite ring;
    [SerializeField] private Sprite mainHand;
    [SerializeField] private Sprite offHand;

    public ItemStack lastTransmuted;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //for some reason this doesnt work so i loaded manually
        /* Sprite helm = Resources.Load<Sprite>("helmSlot");
        Sprite chest = Resources.Load<Sprite>("chestSlot");
        Sprite gloves = Resources.Load<Sprite>("handsSlot");
        Sprite legs = Resources.Load<Sprite>("legsSlot");
        Sprite boots = Resources.Load<Sprite>("bootsSlot");
        Sprite ring = Resources.Load<Sprite>("ringSlot");
        Sprite mainHand = Resources.Load<Sprite>("mainHandSlot");
        Sprite offHand = Resources.Load<Sprite>("offHandSlot"); */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transmute(int index1, int index2, ItemStack _gear)
    {
        Debug.Log(index1);
        Debug.Log(index2);
        switch(index1)
        {
            case 0:
                setImage1(helm);
                break;

            case 1:
                setImage1(chest);
                break;

            case 2:
                setImage1(gloves);
                Debug.Log("called");
                break;

            case 3:
                setImage1(legs);
                break;

            case 4:
                setImage1(boots);
                break;

            case 5:
                setImage1(ring);
                break;

            case 6:
                setImage1(mainHand);
                break;

            case 7:
                setImage1(offHand);
                break;

            case 8:
                //apply when two hand image created
                break;
            

        }

        switch (index2)
        {
            case 0:
                setImage2(helm);
                break;

            case 1:
                setImage2(chest);
                break;

            case 2:
                setImage2(gloves);
                break;

            case 3:
                setImage2(legs);
                break;

            case 4:
                setImage2(boots);
                break;

            case 5:
                setImage2(ring);
                break;

            case 6:
                setImage2(mainHand);
                break;

            case 7:
                setImage2(offHand);
                break;

            case 8:
                //apply when two hand image created
                break;


        }

        //image1.GetComponent<Image>().sprite = 
        transmuteUI.SetActive(!transmuteUI.activeSelf);

        lastTransmuted = _gear;
    }

    private void setImage1(Sprite sprite)
    {
        image1.GetComponent<Image>().sprite = sprite;
    }

    private void setImage2(Sprite sprite)
    {
        image2.GetComponent<Image>().sprite = sprite;
    }

    public void clickChoice(int _choice)
    {
        choice = _choice;
        transmuteUI.SetActive(!transmuteUI.activeSelf);

        lastTransmuted.overrideType = lastTransmuted.GetItemTypes()[_choice-1];

        GearManager.Instance.Equip(lastTransmuted);
        lastTransmuted.InventoryRemove();
    }

}
