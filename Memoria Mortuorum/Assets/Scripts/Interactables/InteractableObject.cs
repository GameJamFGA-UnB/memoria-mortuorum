using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{

    
    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
    }
}
