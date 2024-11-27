using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
// This script is used to represent the whiteboard itself, which has a texture that can be drawn on.
public class Whiteboard_test : MonoBehaviour
{
    public Texture2D texture; // Texture on which the marker draws
    public Vector2 textureSize = new Vector2(2048, 2048); // Size of the texture in pixels

    // Initialization
    void Start()
    {
        // Get the renderer component of the whiteboard
        var r = GetComponent<Renderer>();

        // Create a new Texture2D with the specified size and assign it to the whiteboard's material
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
 //       ClearWhiteboardRoutine(); // Start the routine to clear the whiteboard periodically 
    }
    /*
    private IEnumerator ClearWhiteboardRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10); // Wait for 10 seconds

            ClearTexture(); // Clear the whiteboard texture
        }
    }

    // Method to clear the whiteboard by setting all pixels to white (or any background color)
    private void ClearTexture()
    {
        // Create a blank color array (e.g., white) to fill the texture
        Color[] clearColors = Enumerable.Repeat(Color.black, (int)(textureSize.x * textureSize.y)).ToArray();
        texture.SetPixels(clearColors); // Apply the color to the entire texture
        texture.Apply(); // Apply changes to the texture
    }
    */
}
