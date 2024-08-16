using System;
using UnityEngine.InputSystem;

namespace GameWideSystems.InputManager.ReadingCores.Pointer
{
    public class PointerCore : IInputReadingCore
    {
        public event Action<IGesture> OnGestureRead;
        
        private readonly MainInputs mainInputs;
        private readonly PointerInputConfigurations pointerInputConfigurations;
        private readonly PointerReaderEventHost pointerReaderEventHost;
        
        private PointerBuffer pointerBuffer;

        public PointerCore(PointerInputConfigurations pointerInputConfigurations)
        {
            mainInputs = new MainInputs();
            pointerReaderEventHost = new PointerReaderEventHost();
            
            this.pointerInputConfigurations = pointerInputConfigurations;

            mainInputs.Pointer.Press.performed += Press;
            mainInputs.Pointer.Press.canceled += Release;

            pointerReaderEventHost.OnGesture += BroadcastGesture;
            pointerReaderEventHost.OnFinalized += FinalizeGestureReading;
        }

        public void Dispose()
        {
            mainInputs?.Dispose();
        }

        public void Activate()
        {
            mainInputs.Pointer.Enable();
        }

        public void Deactivate()
        {
            mainInputs.Pointer.Disable();
        }
        
        public void Tick()
        {
            pointerBuffer?.OnUpdate();
        }

        private void Press(InputAction.CallbackContext inputEvent)
        {
            pointerBuffer = new PointerBuffer(pointerReaderEventHost, pointerInputConfigurations, mainInputs);
            
            pointerBuffer.OnPress(inputEvent);
        }

        private void Release(InputAction.CallbackContext inputEvent)
        {
            pointerBuffer?.OnRelease(inputEvent);
        }
        
        private void FinalizeGestureReading()
        {
            pointerBuffer = null;
        }
        
        private void BroadcastGesture(IGesture gesture)
        {
            OnGestureRead?.Invoke(gesture);
        }


    }
}