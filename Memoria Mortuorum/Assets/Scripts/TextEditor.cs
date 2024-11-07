using UnityEngine;
using TMPro;

public class TextEditor : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    public TextMeshProUGUI mainText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainText.text = "Velocidade: " + rb.linearVelocity.x.ToString();
    }
}
