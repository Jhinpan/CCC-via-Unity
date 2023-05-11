using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

public class InputHandler : MonoBehaviour
{
    public InputField inputField;
    public Button submitButton;
    public string serverIP = "127.0.0.1";
    public int serverPort = 25001;

    public string shape;
    public Vector3 position;
    public Vector3 scale;
    public string color;

    void Start()
    {
        submitButton.onClick.AddListener(HandleSubmit);
    }

    void HandleSubmit()
    {
        string inputText = inputField.text;
        ParseInput(inputText);

        // You can use the variables shape, position, and color here.
        // For now, let's just print them out.
        Debug.Log("Shape: " + shape);
        Debug.Log("Position: " + position);
        Debug.Log("Scale: " + scale);
        Debug.Log("Color: " + color);

        CreateShape(shape, position, scale, color);
        
        // Convert shape data to JSON and send to server
        SendShapeDataToServer(shape, position, scale, color);
    }

    void ParseInput(string input)
    {
        // Use a regex to match and extract the shape, position, and color
        var match = Regex.Match(input, @"(\w+),\s*\((.*?)\),\s*\((.*?)\),\s*(\w+)");
        if (match.Success)
        {
            shape = match.Groups[1].Value;
            position = StringToVector3(match.Groups[2].Value);
            scale = StringToVector3(match.Groups[3].Value);
            color = match.Groups[4].Value;
        }
        else
        {
            Debug.Log("Invalid input format");
        }
    }



    Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // Split the elements
        string[] sArray = sVector.Split(',');
        
        // Debug.Log("sVector: " + sVector);
        // Debug.Log("sArray length: " + sArray.Length);
        // Debug.Log("sArray[0]: " + sArray[0]);
        // Debug.Log("sArray[1]: " + sArray[1]);
        // Debug.Log("sArray[2]: " + sArray[2]);

        // Store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2])
        );

        return result;
    }
    
    void CreateShape(string shape, Vector3 position, Vector3 scale, string color)
    {
        // Only handling "cube" for now
        if (shape.ToLower() == "cube")
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = position;
            cube.transform.localScale = scale;
            Renderer rend = cube.GetComponent<Renderer>();

            // Let's define colors for "red", "blue", and "green"
            switch (color.ToLower())
            {
                case "red":
                    rend.material.color = Color.red;
                    break;
                case "blue":
                    rend.material.color = Color.blue;
                    break;
                case "green":
                    rend.material.color = Color.green;
                    break;
                case "white":
                    rend.material.color = Color.white;
                    break;
                case "black":
                    rend.material.color = Color.black;
                    break;
                default:
                    Debug.Log("Unsupported color: " + color);
                    break;
            }
        }
        else if (shape.ToLower() == "sphere")
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = position;
            sphere.transform.localScale = scale;
            Renderer rend = sphere.GetComponent<Renderer>();

            // Let's define colors for "red", "blue", and "green"
            switch (color.ToLower())
            {
                case "red":
                    rend.material.color = Color.red;
                    break;
                case "blue":
                    rend.material.color = Color.blue;
                    break;
                case "green":
                    rend.material.color = Color.green;
                    break;
                case "white":
                    rend.material.color = Color.white;
                    break;
                case "black":
                    rend.material.color = Color.black;
                    break;
                default:
                    Debug.Log("Unsupported color: " + color);
                    break;
            }
        }
        else
        {
            Debug.Log("Unsupported shape: " + shape);
        }
    }
    
    // Create a new class to hold your shape data
    public class ShapeData
    {
        public string shape;
        public string position;
        public string scale;
        public string color;
    }
    
    void SendShapeDataToServer(string shape, Vector3 position, Vector3 scale, string color)
    {
        // // Create dictionary to hold shape data
        // Dictionary<string, string> shapeData = new Dictionary<string, string>()
        // {
        //     {"shape", shape},
        //     {"position", position.ToString()},
        //     {"scale", scale.ToString()},
        //     {"color", color}
        // };
        
        // Create an instance of ShapeData
        ShapeData shapeData = new ShapeData();
        shapeData.shape = shape;
        shapeData.position = position.ToString();
        shapeData.scale = scale.ToString();
        shapeData.color = color;
    
        // Convert dictionary to JSON
        string jsonData = JsonUtility.ToJson(shapeData);
    
        // Create a TcpClient and connect to server
        TcpClient client = new TcpClient(serverIP, serverPort);
    
        // Get a client stream for reading and writing
        NetworkStream stream = client.GetStream();
    
        // Translate the JSON data into a byte array
        byte[] data = System.Text.Encoding.ASCII.GetBytes(jsonData);
    
        // Send the data to the connected TcpServer
        stream.Write(data, 0, data.Length);
        Debug.Log("Sent: " + jsonData);
    
        // Close everything
        stream.Close();
        client.Close();
    }
    
}