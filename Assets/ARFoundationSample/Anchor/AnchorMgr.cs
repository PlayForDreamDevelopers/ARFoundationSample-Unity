using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace YVR.ARFoundation.Sample
{
    public class AnchorMgr : MonoBehaviour
    {
        public Transform anchorPrefab;

        public Transform anchorPoseTarget;

        public InputActionProperty createAnchorAction;

        public Dictionary<ARAnchor,GameObject> anchors = new ();

        public ARAnchorManager anchorManager;

        private List<string> loadAnchorsID = new ();

        private const string saveKey = "anchors";

        // Start is called before the first frame update
        void Start()
        {
            Unity.Jobs.LowLevel.Unsafe.JobsUtility.JobWorkerCount = 0;
            createAnchorAction.action.Enable();
            createAnchorAction.action.performed += CreateAnchorAsync;
            anchorManager.trackablesChanged.AddListener(OnTrackablesChanged);
            GetSavedAnchorsIDForPayerPrefs();
        }

        private void GetSavedAnchorsIDForPayerPrefs()
        {
            string cacheAnchorIDs = PlayerPrefs.GetString(saveKey);
            if (!string.IsNullOrEmpty(cacheAnchorIDs))
            {
                var ids = cacheAnchorIDs.Split(',');
                foreach (var id in ids)
                {
                    loadAnchorsID.Add(id);
                }
            }
        }

        private void SetSavedAnchorsID2PayerPrefs()
        {
            string ids = string.Join(",", loadAnchorsID);
            PlayerPrefs.SetString(saveKey, ids);
        }

        private void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARAnchor> changes)
        {
            foreach (var anchor in changes.updated)
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
        private async void CreateAnchorAsync(InputAction.CallbackContext context)
        {
            var pose = new Pose(anchorPoseTarget.position, anchorPoseTarget.rotation);
            var result = await anchorManager.TryAddAnchorAsync(pose);
            if (result.status.IsSuccess())
            {
                var anchor = result.value;
                CreateAnchorGameObject(anchor);
            }

            Debug.Log($"TryAddAnchorAsync result IsSuccess:{result.status.IsSuccess()},value:{result.value}");
        }

        private void CreateAnchorGameObject(ARAnchor anchor)
        {
            if (!anchors.ContainsKey(anchor))
            {
                var anchorTransform =  Instantiate(anchorPrefab, anchor.pose.position, anchor.pose.rotation);
                anchors.Add(anchor, anchorTransform.gameObject);
            }
        }

        public async void SaveAnchorAsync()
        {
            foreach (var anchor in anchors)
            {
                var result = await anchorManager.TrySaveAnchorAsync(anchor.Key);
                var trackableId = anchor.Key.trackableId.ToString();
                if (!loadAnchorsID.Contains(trackableId))
                {
                    loadAnchorsID.Add(trackableId);
                }

                Debug.Log($"SaveAnchorAsync result IsSuccess:{result.status.IsSuccess()},value:{result.value.ToString()}");
            }

            SetSavedAnchorsID2PayerPrefs();
        }

        public async void EraseAnchorAsync()
        {
            foreach (var anchor in anchors)
            {
               var result = await anchorManager.TryEraseAnchorAsync(anchor.Key.trackableId);
               if (result.IsSuccess())
               {
                   loadAnchorsID.Remove(anchor.Key.trackableId.ToString());
               }

               Debug.Log($"EraseAnchorAsync result IsSuccess:{result.IsSuccess()},statusCode:{result.statusCode}");
            }

            DestroyAnchorGameobject();
            SetSavedAnchorsID2PayerPrefs();
        }

        public void DestroyAnchorGameobject()
        {
            List<GameObject> removeAnchors = anchors.Values.ToList();
            foreach (var item in removeAnchors)
            {
                item.gameObject.SetActive(false);
            }

            anchors.Clear();
        }

        public async void LoadAnchorAsync()
        {
            foreach (var trackableId in loadAnchorsID)
            {
               var result = await anchorManager.TryLoadAnchorAsync(new TrackableId(trackableId));
               if (result.status.IsSuccess())
               {
                   CreateAnchorGameObject(result.value);
               }

               Debug.Log($"LoadAnchorAsync IsSuccess:{result.status.IsSuccess()}, anchorID:{result.value.trackableId}");
            }
        }
    }
}
