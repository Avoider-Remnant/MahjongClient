using UnityEngine;

namespace GameWideSystems.InputManager.GestureReaders.Pointer
{
    public class LongPress : IPointerGesture
    {
        public InputType InputType => InputType.Pointer;
        public Vector2 SourcePosition { get; set; }

        public LongPress(Vector2 sourcePosition)
        {
            SourcePosition = sourcePosition;
        }
    }
}