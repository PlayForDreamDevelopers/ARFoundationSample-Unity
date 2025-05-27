using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using YVR.Core;
using YVR.Core.ImageTracking;

public class TrackedImagesListener : MonoBehaviour
{
    public ARTrackedImageManager arTrackedImageManager;

    // Start is called before the first frame update
    void Start()
    {
        arTrackedImageManager.trackedImagesChanged += args =>
        {
            foreach (var arTrackedImage in args.added)
            {
                UpdateInfo(arTrackedImage);
            }
        };
    }

    void UpdateInfo(ARTrackedImage trackedImage)
    {
        Debug.LogError($"TrackedImage.name:{trackedImage.name}," +
                       $"referenceImage.name:{trackedImage.referenceImage.name}," +
                       $"size:{trackedImage.size}," +
                       $"referenceImage.guid:{trackedImage.referenceImage.guid}," +
                       $"referenceImage.textureGuid:{trackedImage.referenceImage.textureGuid}");
        // Set canvas camera
        var canvas = trackedImage.GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main;

        // Update information about the tracked image
        var text = canvas.GetComponentInChildren<Text>();
        text.text = string.Format(
            "{0}\ntrackingState: {1}\nGUID: {2}\nReference size: {3} cm\nDetected size: {4} cm",
            trackedImage.referenceImage.name,
            trackedImage.trackingState,
            trackedImage.referenceImage.guid,
            trackedImage.referenceImage.size,
            trackedImage.size);

        var planeParentGo = trackedImage.transform.GetChild(0).gameObject;
        var planeGo = planeParentGo.transform.GetChild(0).gameObject;

        // Disable the visual plane if it is not being tracked
        if (trackedImage.trackingState != TrackingState.None)
        {
            planeGo.SetActive(true);

            // The image extents is only valid when the image is being tracked
            trackedImage.transform.localScale = new Vector3(trackedImage.size.x, trackedImage.size.y, 1);

            // Set the texture
            var material = planeGo.GetComponentInChildren<MeshRenderer>().material;
            Debug.LogError($"{trackedImage.referenceImage.texture}");
            material.mainTexture = trackedImage.referenceImage.texture;
        }
        else
        {
            planeGo.SetActive(false);
        }
    }
}