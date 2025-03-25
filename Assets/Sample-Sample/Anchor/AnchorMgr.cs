using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

namespace YVR.ARFoundation.Sample
{
    public class AnchorMgr : MonoBehaviour
    {
        public Transform anchorPrefab;

        public Transform anchorPoseTarget;

        public InputActionProperty createAnchorAction;

        public InputActionProperty removeAnchorAction;

        public ARAnchorManager arAnchorManager;

        public Dictionary<ARAnchor,GameObject> anchors = new ();

        // Start is called before the first frame update
        void Start()
        {
            createAnchorAction.action.Enable();
            removeAnchorAction.action.Enable();
            createAnchorAction.action.performed += CreateAnchor;
            removeAnchorAction.action.performed += RemoveAnchor;
            arAnchorManager.anchorsChanged += OnAnchorsChanged;
        }

        private void OnAnchorsChanged(ARAnchorsChangedEventArgs args)
        {
            foreach (var anchor in args.updated)
            {
                foreach (var pair in anchors)
                {
                    if (pair.Key.trackableId == anchor.trackableId)
                    {
                        pair.Value.transform.SetPositionAndRotation(anchor.transform.position, anchor.transform.rotation);
                    }
                }
            }
        }

        private void CreateAnchor(InputAction.CallbackContext context)
        {
            var anchorTransform =  Instantiate(anchorPrefab, anchorPoseTarget.position, anchorPoseTarget.rotation);
            var anchor = anchorTransform.gameObject.AddComponent<ARAnchor>();
            anchors.Add(anchor, anchorTransform.gameObject);
        }

        private void RemoveAnchor(InputAction.CallbackContext context)
        {
            foreach (var pair in anchors)
            {
                Destroy(pair.Value);
            }

            anchors.Clear();
        }

    }

}
