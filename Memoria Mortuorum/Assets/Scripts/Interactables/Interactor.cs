using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{

    public TextMeshProUGUI mainText;
    public Transform InteractorSource;
    public float InteractRange;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                    Debug.Log("Anomalia: " + interactObj);
                    if(hitInfo.transform.tag == "Anomalia")
                    {
                        mainText.text = "Anomalia: " + hitInfo.transform.name;
                    }
                }
            }
        }
    }
    
}
