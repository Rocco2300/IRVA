using System;
using UnityEngine;
using Valve.VR;

namespace L3_VR_SteamVR_Advanced.Scripts.Input
{
    public class SteamVRInputActionsTesting : MonoBehaviour
    {
        void Update()
        {
            // TODO 1 : Setup input for the already-defined `GrabPinch` action.
            //          Write a message in the console which signifies this input is correctly read.
            //          Use either the polling method or an event-based mechanism.
            var pinchState = SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.Any);
            //Debug.Log($"Pinch state: {pinchState}");

            // TODO 2 : Setup input for the `TouchTrigger` action (you'll have to first create it & bind it accordingly)
            //          Write a message in the console which signifies this input is correctly read.
            //          Use either the polling method or an event-based mechanism.
            var touchTriggerState = SteamVR_Actions._default.TouchTrigger.GetState(SteamVR_Input_Sources.Any);
            //Debug.Log($"Touch trigger: {touchTriggerState}");
        }

        private void OnGrabPinchChanged(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource,
            bool newValue)
        {
            //Debug.Log($"[SteamVRInputActionsTesting] Events: grabPinchState = {newValue}");
        }
        
        private void OnTouchTriggerChanged(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource,
            bool newValue)
        {
            //Debug.Log($"[SteamVRInputActionsTesting] Events: grabPinchState = {newValue}");
        }

        private void OnEnable()
        {
            SteamVR_Actions._default.GrabPinch.onChange += OnGrabPinchChanged;
            SteamVR_Actions._default.TouchTrigger.onChange += OnTouchTriggerChanged;
        }

        private void OnDisable()
        {
            SteamVR_Actions._default.GrabPinch.onChange -= OnGrabPinchChanged;
            SteamVR_Actions._default.TouchTrigger.onChange -= OnTouchTriggerChanged;
        }
    }
}