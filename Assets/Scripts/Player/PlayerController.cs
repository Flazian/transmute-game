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

        public Interact focus;
        [SerializeField] private bool worldMove = true;

        [SerializeField] private InputAction movement = new InputAction();

        [SerializeField] private LayerMask layerMaskWalk = new LayerMask();
        [SerializeField] private LayerMask layerMaskInteract = new LayerMask();

        [SerializeField] private Transform target;

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

            if (target != null)
            {
                worldMove = false;
                PlayerMove(target.position);
                FaceTarget();
            }
            HandleInput();
        }

        private void HandleInput()
        {

            if (movement.ReadValue<float>() == 1)
            {
                RemoveFocus();
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (EventSystem.current.IsPointerOverGameObject() == false)
                {

                     if (Physics.Raycast(ray, out hit, 100, layerMaskInteract))
                     {
                         worldMove = false;
                         Interact interact = hit.collider.GetComponent<Interact>();
                         Debug.Log("clicked interactable");
                         if (interact != null)
                         {
                             SetFocus(interact);
                             
                         }
                     }
                    else
                    {
                        worldMove = true;
                    }
                  

                    if (Physics.Raycast(ray, out hit, 100, layerMaskWalk) && worldMove)
                    {
                        PlayerMove(hit.point);
                        //FaceMouse();
                        //RemoveFocus();
                    } 
                }
            }
        }

        public void FollowTarget(Interact newTarget)
        {
            agent.stoppingDistance = newTarget.pickUpRadius * 0.3f;
            agent.updateRotation = false;
            target = newTarget.interactTransform;
        }

        public void StopFollow()
        {
            agent.stoppingDistance = 0f;
            target = null;
            agent.updateRotation = true;
        }

        private void SetFocus(Interact newFocus)
        {
            if (newFocus != focus)
            {
                if (focus != null)
                {
                    focus.OnDefocus();
                }

                focus = newFocus;
                FollowTarget(newFocus);
            }

            newFocus.WhenFocused(transform);
        }

        private void RemoveFocus()
        {
            if (focus != null)
            {
                focus.OnDefocus();
            }


            focus = null;
            StopFollow();
        }

        private void PlayerMove(Vector3 loc)
        {
            agent.SetDestination(loc);
        }

        private void FaceTarget()
        {
            Vector3 dir = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        private void PlayerStop(Vector3 stop)
        {
            
        }
    }
}
