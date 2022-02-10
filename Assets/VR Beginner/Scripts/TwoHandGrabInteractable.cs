using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class TwoHandGrabInteractable : XRGrabInteractable
    {
        public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();

        private XRBaseInteractor secondInteractor; //Set on Second Attach
        private Quaternion initialSecondAttachRotation; //Required to reset second hand pivot

        // Start is called before the first frame update
        void Start()
        {
            foreach(XRSimpleInteractable interactable in secondHandGrabPoints)
            {
                interactable.onSelectEnter.AddListener(OnSecondHandGrab);
                interactable.onSelectExit.AddListener(OnSecondHandRelease);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override bool IsSelectableBy(XRBaseInteractor interactor)
        {
            bool isAlreadyGrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
            return base.IsSelectableBy(interactor);
        }

        void OnSecondHandGrab(XRBaseInteractor interator)
        {
            Debug.Log("Second Hand Grabbed!");
        }

        void OnSecondHandRelease(XRBaseInteractor interator)
        {
            Debug.Log("Second Hand Released!");
        }
    }
}
