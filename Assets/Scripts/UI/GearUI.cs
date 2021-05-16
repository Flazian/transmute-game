using UnityEngine;
using UnityEngine.InputSystem;

public class GearUI : MonoBehaviour
{
    public GameObject gearUI;
    private InputAction gearPress = new InputAction(binding: "<Keyboard>/c");

    // Start is called before the first frame update
    void Start()
    {
        gearPress.AddBinding("<Keyboard>/g");
        gearPress.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (gearPress.triggered)
        {
            gearUI.SetActive(!gearUI.activeSelf);
        }
    }
}
