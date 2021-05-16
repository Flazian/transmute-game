using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Transmutation : MonoBehaviour
{
    public GameObject transmuteUI;
    public GameObject image1;
    public GameObject image2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transmute(int _1, int _2)
    {
        //image1.GetComponent<Image>().sprite = 
        transmuteUI.SetActive(!transmuteUI.activeSelf);
    }

    public void choice1(ref int _slotIndex1, ref int _chosenSlot)
    {
        _chosenSlot = _slotIndex1;  
    }

    public void choice2(ref int _slotIndex2, ref int _chosenSlot)
    {
        _chosenSlot = _slotIndex2;
        transmuteUI.SetActive(!transmuteUI.activeSelf);
    }
}
