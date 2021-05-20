using UnityEngine;
using UnityEngine.UI;

public class GearSlot : MonoBehaviour
{
    public Image icon;
    [SerializeField] private GameObject slotIcon;
    //public Button unequipButton;
    public ItemStack item;

    public int gearSlot;

    private bool imageChanged = false;

    GearManager gearManager;

    // Start is called before the first frame update
    void Start()
    {
        gearManager = GearManager.Instance;
        icon = slotIcon.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gearManager.currentGear[gearSlot].baseItem != null && !imageChanged)
        {
            slotImage();
            imageChanged = true;
        }
        else
        {
            imageChanged = false;
        }


    }

    
    public void clickUnequipSlot(int _gearSlot)
    {
        gearSlot = _gearSlot;
        gearManager.Unequip(gearSlot);
        slotClear();
    }

    //this will come in later when gear gets images
    private void slotImage()
    {
        Sprite newIcon;
        newIcon = gearManager.currentGear[gearSlot].GetSprite();
        icon.sprite = newIcon;
        var tempColor = icon.color;
        tempColor.a = 1f;
        icon.color = tempColor;
    }

    private void slotClear()
    {
        if (gearManager.currentGear[gearSlot].baseItem == null)
        {
            var tempColor = icon.color;
            tempColor.a = 0.3f;
            icon.color = tempColor;
            
            switch(gearSlot)
            {
                case 0:
                    icon.sprite = gearManager.helm;
                    break;

                case 1:
                    icon.sprite = gearManager.chest;
                    break;

                case 2:
                    icon.sprite = gearManager.gloves;
                    break;

                case 3:
                    icon.sprite = gearManager.legs;
                    break;

                case 4:
                    icon.sprite = gearManager.boots;
                    break;

                case 5:
                    icon.sprite = gearManager.ring;
                    break;

                case 6:
                    icon.sprite = gearManager.mainHand;
                    break;

                case 7:
                    icon.sprite = gearManager.offHand;
                    break;

                default:
                    break;

            }
        }
    }
}
