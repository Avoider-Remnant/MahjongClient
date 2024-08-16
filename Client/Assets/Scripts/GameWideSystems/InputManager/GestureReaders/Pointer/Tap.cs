using UnityEngine;

namespace GameWideSystems.InputManager.GestureReaders.Pointer
{
    public class Tap : IPointerGesture
    {
        public InputType InputType => InputType.Pointer;
        public Vector2 SourcePosition { get; set; }

        public Tap(Vector2 sourcePosition)
        {
            SourcePosition = sourcePosition;
        }
    }
}