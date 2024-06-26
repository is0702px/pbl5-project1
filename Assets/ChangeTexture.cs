using UnityEngine;
using UnityEngine.UI;

public class ChangeTexture : MonoBehaviour
{
    public Texture2D[] textures;  // Stored texture array
    public GameObject model;      // To change the texture of the model
    public Text textureLabel;     // Displays UI text for the texture name
    private int currentTextureIndex = 0;  

    // Start is called before the first frame update
    void Start()
    {
        UpdateTexture();  
    }

    // When clicked by the button, change the texture
    public void ChangeTextureButton()
    {
        currentTextureIndex = (currentTextureIndex + 1) % textures.Length;
        UpdateTexture();
    }

    // Update the texture and UI text of the model
    private void UpdateTexture()
    {
        Renderer renderer = model.GetComponent<Renderer>();
        renderer.material.mainTexture = textures[currentTextureIndex];
        textureLabel.text = "Texture: " + textures[currentTextureIndex].name;
    }
}
