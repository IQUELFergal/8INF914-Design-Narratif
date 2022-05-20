using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Vector2 boxSize = Vector2.one;
    Vector2 boxOffset = Vector2.up;
    [SerializeField] LayerMask layermask;
    ContactFilter2D contactFilter2D;

    public int selectedColliderIndex = 0;
    public List<Collider2D> currentInteractableColliders = new List<Collider2D>();
    IInteractable[] currentInteractables;

    // Start is called before the first frame update
    void Start()
    {
        contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(layermask);
    }

    public void Interact(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (currentInteractables != null && currentInteractables.Length > 0)
        {
            foreach (IInteractable interactable in currentInteractables)
            {
                interactable.Interact(this);
            }
        }
    }

    public void SwitchCollider(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (currentInteractableColliders.Count > 1)
        {
            selectedColliderIndex++;
            if (selectedColliderIndex >= currentInteractableColliders.Count)
            {
                selectedColliderIndex = 0;
            }
        }
    }

    public void SetOffset(Vector2 offset)
    {
        boxOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox((Vector2)transform.position + boxOffset, boxSize, 0, contactFilter2D, currentInteractableColliders) > 0) 
        {
            if (selectedColliderIndex >= currentInteractableColliders.Count)
            {
                selectedColliderIndex = 0;
            }
            IInteractable[] interactables = currentInteractableColliders[selectedColliderIndex].GetComponents<IInteractable>();
            if (interactables.Length == 0) currentInteractables = null;
            else currentInteractables = interactables;
        }
        else
        {
            selectedColliderIndex = 0;
            if (currentInteractables != null)
            {
                currentInteractables = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)boxOffset, boxSize);
    }
}
