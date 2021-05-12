using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace TR.ARPGInput
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private InputAction movement = new InputAction();

        [SerializeField] private LayerMask layerMaskWalk = new LayerMask();

        private NavMeshAgent agent = null;
        private Camera cam = null;

        void Start()
        {
            cam = Camera.main;
            agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            movement.Enable();
        }

        private void OnDisable()
        {
            movement.Disable();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (movement.ReadValue<float>() == 1)
            {
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    if (Physics.Raycast(ray, out hit, 300, layerMaskWalk))
                    {
                        PlayerMove(hit.point);
                    }
                }
            }
        }

        private void PlayerMove(Vector3 loc)
        {
            agent.SetDestination(loc);
        }

        private void PlayerStop(Vector3 stop)
        {
            
        }
    }
}
