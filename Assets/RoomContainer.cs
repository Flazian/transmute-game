using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomContainer : MonoBehaviour
{
    public Vector2Int index;

    public List<GameObject> topWalls;
    public List<GameObject> bottomWalls;
    public List<GameObject> leftWalls;
    public List<GameObject> rightWalls;

    public GameObject topPlug;
    public GameObject bottomPlug; //teehee
    public GameObject leftPlug;
    public GameObject rightPlug;

    public bool[] neighbours = new bool[4];

    private InputAction roomPress = new InputAction(binding: "<Keyboard>/r");

    void Start()
    {
        roomPress.Enable();
    }
    
    void Update()
    {
        if (roomPress.triggered)
        {
            Generate();
        }
    }

    public void Generate()
    {
        HandlePlug(topPlug, neighbours[0]);
        HandlePlug(bottomPlug, neighbours[1]);
        HandlePlug(leftPlug, neighbours[2]);
        HandlePlug(rightPlug, neighbours[3]);
    }

    public void SetActive(List<GameObject> _list, bool _value)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].SetActive(_value);
        }
    }

    public void HandlePlug(GameObject _plug, bool _value)
    {
        if (_value)
        {
            _plug.SetActive(false);
        }
        else
        {
            _plug.SetActive(true);
        }
    }
}
