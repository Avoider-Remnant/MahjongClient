﻿using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameWideSystems.UIManagement.Screen
{
    public interface IUIScreenBuilder
    {
        public ScreenType ScreenType { get; }
        public UniTask<IUIScreen> Build(Transform screenHolder, IScreenParams screenParams, CancellationToken cancellationToken);
    }
}