using UnityEngine;

public class Interact : MonoBehaviour
{
    public float pickUpRadius = 3f;
    public Transform interactTransform;

    bool focused = false;
    Transform player;

    bool interacted = false;

    public virtual void use()
    {
        Debug.Log("Interacting with" + transform.name);
        //virtual
    }

    void Update()
    {
        if (focused && !interacted)
        {
            float distance = Vector3.Distance(player.position, interactTransform.position);
            if (distance <= pickUpRadius)
            {
                use();
                interacted = true;
            }
        }

    }

    public void WhenFocused(Transform playerTransform)
    {
        focused = true;
        player = playerTransform;
        interacted = false;
    }

    public void OnDefocus()
    {
        focused = false;
        player = null;
        interacted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactTransform.position, pickUpRadius);
    }

}
