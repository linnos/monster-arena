using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    private TextMeshPro text;
    public string textToDisplay { get; set; } = "Hello dar";

    void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }
    
    void Start()
    {
        text.text = textToDisplay;
    }
}
