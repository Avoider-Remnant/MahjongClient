﻿using System.Collections.Generic;
using System.Linq;
using GameWideSystems.InputManager.DefaultHandlingLayers;
using Zenject;

namespace GameWideSystems.InputManager
{
    public class InputHost : IInputHost
    {
        private readonly List<IInputHandlerLayer> inputLayers = new();

        public InputHost([Inject(Optional = true)] IInputHandlerLayer[] inputHandlers)
        {
            inputLayers.Add(new UIInputPointerHandlingLayer());
            
            if (inputHandlers is not null && inputHandlers.Length > 0)
            {
                inputLayers.AddRange(inputHandlers);
            }
            
            inputLayers.Sort(CompareLayers);
        }

        public void AddInputLayer(IInputHandlerLayer inputHandlerLayer)
        {
            inputLayers.Add(inputHandlerLayer);
            
            inputLayers.Sort(CompareLayers);
        }

        public bool RemoveInputLayer(IInputHandlerLayer inputHandlerLayer)
        {
            return inputLayers.Remove(inputHandlerLayer);
        }

        public void HostInputEvent(IGesture gesture)
        {
            if (inputLayers.Any(layer => layer.InputType == gesture.InputType && layer.TryHandle(gesture)))
            {
                return;
            }
        }

        private static int CompareLayers(IInputHandlerLayer a, IInputHandlerLayer b)
        {
            return a.Index.CompareTo(b.Index);
        }
    }
}