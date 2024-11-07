using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class AnomalyController : MonoBehaviour
{

    public List<Transform> anomalys = new List<Transform>();
    void Start()
    {
        getChildren();
        //anomalyReset();
    }

    void getChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<InteractableObject>();
            anomalys.Add(child);
        }

        foreach (Transform anomaly in anomalys)
            Debug.Log(anomaly);

    }
    public void anomalyEnabler()
    {
        int children = anomalys.Count;
        int random = Random.Range(0, children);
        int random2 = Random.Range(0, children);

        for (int i = 0; i < children; ++i)
        {
            if (i == random || i == random2)
            {
                anomalys[i].gameObject.SetActive(true);
            }
        }
    }
    public void anomalyReset()
    {
        foreach (Transform anomaly in anomalys)
            anomaly.gameObject.SetActive(false);
            
        
    }
}
