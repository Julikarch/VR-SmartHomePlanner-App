using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Meta.XR.MRUtilityKit;
using UnityEngine;
// using Oculus.SpatialAnchors;

public class SnapToSurface : MonoBehaviour
{
    public float snapDistance = 0.5f; // Maximum distance to snap
    public LayerMask surfaceLayerMask; // LayerMask to identify surfaces (e.g., walls)

    private MRUKRoom sceneManager;
    private List<MRUKAnchor> sceneAnchors = new List<MRUKAnchor>();

    void Start()
    {
        // Find the OVRSceneManager in the scene
        sceneManager = FindObjectOfType<MRUKRoom>();

        if (sceneManager != null)
        {
            // Subscribe to the event that fires when the scene is loaded
            // sceneManage. .SceneModelLoadedSuccessfully += OnSceneModelLoaded;
            // // Start the scene model loading process
            // sceneManager.LoadSceneModel();
            sceneAnchors = sceneManager.Anchors;// .GetRoomAnchors();
        }
        else
        {
            Debug.LogError("OVRSceneManager not found in the scene.");
        }
    }

    private void OnSceneModelLoaded()
    {
        // Get all scene anchors (which include the room mesh data)
        // sceneAnchors = sceneManager.Scene .SceneAnchors;
    }

    void Update()
    {
        // Continuously check for nearby surfaces to snap to
        CheckForSnap();
    }

    private void CheckForSnap()
    {
        foreach (var anchor in sceneAnchors)
        {
            // Check if the anchor is of the type you want to snap to (e.g., Wall)
            if (anchor.AnchorLabels[0] == "FLOOR"
                || anchor.AnchorLabels[0] == "TABLE")
            {
                // float distanceToPlane = Vector3.Distance(transform.position, anchor.PlaneRect.Value.center);
                // if (distanceToPlane <= snapDistance)
                // {
                    // Check if the transform is within the range of the PlaneRect
                Vector3 anchorMin = anchor.PlaneRect.Value.min;
                Vector3 anchorMax = anchor.PlaneRect.Value.max;
                // Vector3 clampedPosition = new Vector3(
                //     Mathf.Clamp(transform.position.x, anchorMin.x, anchorMax.x),
                //     Mathf.Clamp(transform.position.y, anchorMin.y, anchorMax.y),
                //     Mathf.Clamp(transform.position.z, anchorMin.z, anchorMax.z)
                // );
                if(transform.position.z > anchorMin.y - snapDistance
                    && transform.position.z < anchorMax.y + snapDistance
                    && transform.position.x > anchorMin.x - snapDistance
                    && transform.position.x < anchorMax.x + snapDistance
                    && transform.position.y > anchor.transform.position.y - snapDistance
                    && transform.position.y < anchor.transform.position.y + snapDistance)
                {   
                    SnapToObject(anchor.transform, anchor.AnchorLabels[0]);
                    break;
                }

                // Snap the object to the clamped position
                // transform.position = clampedPosition;
                // break; // Exit the loop once snapped
                // // }
                // float distance = Vector3.Distance(transform.position, anchor.transform.position);
                // if (distance <= snapDistance)
                // {
                //     // Snap the object to the surface
                //     SnapToObject(anchor.transform, anchor.AnchorLabels[0]);
                //     break; // Exit the loop once snapped
                // }
            } else if(anchor.AnchorLabels[0] == "WALL_FACE" )
            {
                // float distanceToPlane = Vector3.Distance(transform.position, anchor.PlaneRect.Value.center);
                // if (distanceToPlane <= snapDistance)
                // {
                    // Check if the transform is within the range of the PlaneRect
                Vector3 anchorMin = anchor.PlaneRect.Value.min;
                Vector3 anchorMax = anchor.PlaneRect.Value.max;
                // Vector3 clampedPosition = new Vector3(
                //     Mathf.Clamp(transform.position.x, anchorMin.x, anchorMax.x),
                //     Mathf.Clamp(transform.position.y, anchorMin.y, anchorMax.y),
                //     Mathf.Clamp(transform.position.z, anchorMin.z, anchorMax.z)
                // );
                if(transform.position.y > anchorMin.y - snapDistance
                    && transform.position.y < anchorMax.y + snapDistance
                    && transform.position.x > anchorMin.x - snapDistance
                    && transform.position.x < anchorMax.x + snapDistance
                    && transform.position.z > anchor.transform.position.z - snapDistance
                    && transform.position.z < anchor.transform.position.z + snapDistance)
                {   
                    // SnapToObject(anchor.transform, anchor.AnchorLabels[0]);
                    break;
                }

                // Snap the object to the clamped position
                // transform.position = clampedPosition;
                // break; // Exit the loop once snapped
                // // }
                // float distance = Vector3.Distance(transform.position, anchor.transform.position);
                // if (distance <= snapDistance)
                // {
                //     // Snap the object to the surface
                //     SnapToObject(anchor.transform, anchor.AnchorLabels[0]);
                //     break; // Exit the loop once snapped
                // }
            } else if(anchor.AnchorLabels[0] == "COUCH")
            {
                float distanceToPlane = Vector3.Distance(transform.position, anchor.VolumeBounds.Value.center);
                if (distanceToPlane <= snapDistance)
                {
                    // Check if the transform is within the range of the PlaneRect
                    Vector3 anchorMin = anchor.VolumeBounds.Value.min;
                    Vector3 anchorMax = anchor.VolumeBounds.Value.max;
                    // Vector3 clampedPosition = new Vector3(
                    //     Mathf.Clamp(transform.position.x, anchorMin.x, anchorMax.x),
                    //     Mathf.Clamp(transform.position.y, anchorMin.y, anchorMax.y),
                    //     Mathf.Clamp(transform.position.z, anchorMin.z, anchorMax.z)
                    // );
                    if(transform.position.y > anchorMin.y - snapDistance
                        && transform.position.y < anchorMax.y + snapDistance
                        && transform.position.x > anchorMin.x - snapDistance
                        && transform.position.x < anchorMax.x + snapDistance)
                    {   
                        // SnapToObject(anchor.transform, anchor.AnchorLabels[0]);
                        break;
                    }

                    // Snap the object to the clamped position
                    // transform.position = clampedPosition;
                    // break; // Exit the loop once snapped
                }
            }
            // {
            //     float distance = Vector3.Distance(transform.position, anchor.transform.position);
            //     if (distance <= snapDistance)
            //     {
            //         // Snap the object to the surface
            //         SnapToObject(anchor.transform);
            //         break; // Exit the loop once snapped
            //     }
            // }
        }
    }

    private void SnapToObject(Transform targetTransform, string typ)
    {
        // Align the object to the target transform (surface)
        switch(typ)
        {
            case "WALL_FACE":
            case "FLOOR":
            case "TABLE":
                transform.position = new Vector3(transform.position.x, targetTransform.position.y, transform.position.z);
                // transform.rotation = targetTransform.rotation;
                break;
            // case "FLOOR":
            //     transform.position = new Vector3(transform.position.x, targetTransform.position.y, transform.position.z);
            //     // transform.rotation = targetTransform.rotation;
            //     break;
            // case "TABLE":
            //     transform.position = new Vector3(transform.position.x, targetTransform.position.y, transform.position.z);
            //     // transform.rotation = targetTransform.rotation;
            //     break;
            case "COUCH":
                transform.position = new Vector3(transform.position.x, targetTransform.position.y, transform.position.z);
                // transform.rotation = targetTransform.rotation;
                break;
            default:
                break;
        }
        // transform.position = targetTransform.position;
        // transform.rotation = targetTransform.rotation;
    }
    // public static void Main()
    // {
    //     string stringA = "(x:-0.61, y:-1.50, width:1.22, height:3.00)";
    //     string stringB = "Center: (0.00, 0.00, -0.28), Extents: (0.78, 0.29, 0.28)";

    //     // Extract values from string A
    //     var valuesA = ExtractValuesFromStringA(stringA);
    //     Debug.Log($"A - x: {valuesA.x}, y: {valuesA.y}, maxX: {valuesA.maxX}, maxY: {valuesA.maxY}");

    //     // Extract values from string B
    //     var valuesB = ExtractValuesFromStringB(stringB);
    //     Debug.Log($"B - x: {valuesB.x}, y: {valuesB.y}, z: {valuesB.z}, maxX: {valuesB.maxX}, maxY: {valuesB.maxY}, maxZ: {valuesB.maxZ}");
    // }

    public class ValuesA
    {
        public float x;
        public float y;
        public float maxX;
        public float maxY;

        public ValuesA(float x, float y, float maxX, float maxY)
        {
            this.x = x;
            this.y = y;
            this.maxX = maxX;
            this.maxY = maxY;
        }
    }

    public static ValuesA ExtractValuesFromStringA(string input)
    {
        var regex = new Regex(@"x:(-?\d+(\.\d+)?), y:(-?\d+(\.\d+)?), width:(\d+(\.\d+)?), height:(\d+(\.\d+)?)");
        var match = regex.Match(input);

        if (match.Success)
        {
            float x = float.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            float y = float.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            float width = float.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture);
            float height = float.Parse(match.Groups[7].Value, CultureInfo.InvariantCulture);

            float maxX = x + width;
            float maxY = y + height;

            return new ValuesA(x, y, maxX, maxY);
        } else {
            return null;
        }
    }

    public class ValuesB
    {
        public float x;
        public float y;
        public float z;
        public float maxX;
        public float maxY;
        public float maxZ;

        public ValuesB(float x, float y, float z, float maxX, float maxY, float maxZ)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.maxX = maxX;
            this.maxY = maxY;
            this.maxZ = maxZ;
        }
    }

    public static ValuesB ExtractValuesFromStringB(string input)
    {
        var regex = new Regex(@"Center: \((\-?\d+(\.\d+)?), (\-?\d+(\.\d+)?), (\-?\d+(\.\d+)?)\), Extents: \((\-?\d+(\.\d+)?), (\-?\d+(\.\d+)?), (\-?\d+(\.\d+)?)\)");
        var match = regex.Match(input);

        if (match.Success)
        {
            float centerX = float.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            float centerY = float.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            float centerZ = float.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture);
            float extentX = float.Parse(match.Groups[7].Value, CultureInfo.InvariantCulture);
            float extentY = float.Parse(match.Groups[9].Value, CultureInfo.InvariantCulture);
            float extentZ = float.Parse(match.Groups[11].Value, CultureInfo.InvariantCulture);

            float maxX = centerX + extentX;
            float maxY = centerY + extentY;
            float maxZ = centerZ + extentZ;

            return new ValuesB(centerX, centerY, centerZ, maxX, maxY, maxZ);
        }

        return null;
    }
}