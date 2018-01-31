/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
        public Text popText;
        public UnityEngine.UI.Image popImage;
        private TrackableBehaviour mTrackableBehaviour;

        /*
        public string url = "http://tcon1.dothome.co.kr/image/number_10.91515.png";;
        public Texture2D mTex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        public RawImage Rimage;
        */

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            popImage.sprite = Resources.Load<Sprite>("markerbar1");
            
         
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }
            popImage.sprite = Resources.Load<Sprite>("markerbar2");
            popText.text = "마커를 찾았습니다";
            GameController gc = GameObject.Find("StateController").GetComponent<GameController>();
            gc.markerCheck = true;
            gc.position = mTrackableBehaviour.TrackableName;

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }
            popImage.sprite = Resources.Load<Sprite>("markerbar1");
            popText.text = "마커를 찾으세요";
            GameController gc = GameObject.Find("StateController").GetComponent<GameController>();
            gc.markerCheck = false;
            gc.position = mTrackableBehaviour.TrackableName;
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }
        #endregion // PRIVATE_METHODS
 /*
        IEnumerator getPicture()
        {
            Renderer renderer = GetComponent<Renderer>();
            while (true)
            {
                WWW www = new WWW(url);
                yield return www;
                www.LoadImageIntoTexture(mTex);
                Rimage.texture = mTex;
            }
        }
        */


    }
}
