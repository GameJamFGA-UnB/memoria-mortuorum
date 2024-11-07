using UnityEngine;

public class InteractableDeathBed : MonoBehaviour, IInteractable
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform player;
    [SerializeField] GameObject anomalyController;
    public void Interact()
    {
        interectDeathBed();
    }

    public void interectDeathBed()
    {
        anomalyController.GetComponent<AnomalyController>().anomalyReset();
        anomalyController.GetComponent<AnomalyController>().anomalyEnabler();
        player.position = spawnPoint.position;
    }
}
