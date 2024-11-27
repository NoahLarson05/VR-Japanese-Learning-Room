using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    public int timeToClear = 10; // Time in seconds to clear the whiteboard
    private Color[] clearColors;

    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        clearColors = texture.GetPixels();
        r.material.mainTexture = texture;
        StartCoroutine(ClearWhiteboardRoutine()); // Start the routine to clear the whiteboard periodically 
    }

    private IEnumerator ClearWhiteboardRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToClear); // Wait for  seconds
            SaveWhiteboardToPNG(); // Save the whiteboard to a PNG file
            ClearTexture(); // Clear the whiteboard texture
        }
    }

    // Method to clear the whiteboard by setting all pixels to white (or any background color)
    private void ClearTexture()
    {
        // Create a blank color array (e.g., white) to fill the texture
        //Color[] clearColors = Enumerable.Repeat(setColor, (int)(textureSize.x * textureSize.y)).ToArray();
        texture.SetPixels(clearColors); // Apply the color to the entire texture
        texture.Apply(); // Apply changes to the texture
    }
    public void SaveWhiteboardToPNG()
    {
        try
        {
            // Get the current timestamp for unique filename
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string fileName = $"Whiteboard_{timestamp}.png";

            // Get the bytes of the PNG
            Texture2D rotatedTexture = RotateTexture(texture);
            byte[] bytes = rotatedTexture.EncodeToPNG();

            // Save to a file in a specific path
            // You can change this path as needed
            string path = System.IO.Path.Combine("C:\\Users\\tamago\\image", fileName);
            //string path = System.IO.Path.Combine(Application.persistentDataPath, fileName);
            System.IO.File.WriteAllBytes(path, bytes);

            Debug.Log($"Saved whiteboard to: {path}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving whiteboard: {e.Message}");
        }
    }

    private Texture2D RotateTexture(Texture2D originalTexture)
    {
        Texture2D rotatedTexture = new Texture2D(originalTexture.height, originalTexture.width);

        int width = originalTexture.width;
        int height = originalTexture.height;


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                rotatedTexture.SetPixel(height - 1 - j, i, originalTexture.GetPixel(i, j));
            }
        }

        rotatedTexture.Apply();
        return rotatedTexture;
    }
}
