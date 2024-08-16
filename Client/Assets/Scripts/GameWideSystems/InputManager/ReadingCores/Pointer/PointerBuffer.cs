using GameWideSystems.InputManager.GestureReaders.Pointer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameWideSystems.InputManager.ReadingCores.Pointer
{
    public class PointerBuffer
    {
        private readonly PointerReaderEventHost pointerReaderEventHost;
        private readonly PointerInputConfigurations pointerInputConfigurations;
        private readonly MainInputs mainInputs;

        private readonly float pointerStart;
        
        public PointerBuffer(PointerReaderEventHost pointerReaderEventHost, PointerInputConfigurations pointerInputConfigurations,
            MainInputs mainInputs)
        {
            this.pointerReaderEventHost = pointerReaderEventHost;
            this.pointerInputConfigurations = pointerInputConfigurations;
            this.mainInputs = mainInputs;

            pointerStart = Time.time;
        }

        public void OnPress(InputAction.CallbackContext inputEvent)
        {
            IGesture gesture = new Press(ReadCurrentPosition());

            pointerReaderEventHost.BroadcastGesture(gesture);
        }

        public void OnUpdate()
        {
            if (pointerInputConfigurations.TapToLongPressThreshold > Time.time - pointerStart)
            {
                return;
            }

            IGesture gesture = new LongPress(ReadCurrentPosition());
            
            pointerReaderEventHost.BroadcastGesture(gesture);
            pointerReaderEventHost.BroadcastFinalization();
        }

        public void OnRelease(InputAction.CallbackContext inputEvent)
        {
            IGesture gesture = new Tap(ReadCurrentPosition());
            
            pointerReaderEventHost.BroadcastGesture(gesture);
            pointerReaderEventHost.BroadcastFinalization();
        }

        private Vector2 ReadCurrentPosition()
        {
            return mainInputs.Pointer.PointerPosition.ReadValue<Vector2>();
        }
        
    }
}