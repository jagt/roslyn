// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Roslyn.Editor.InteractiveWindow;

namespace Roslyn.VisualStudio.InteractiveWindow
{
    [Export(typeof(IVsInteractiveWindowFactory))]
    internal sealed class VsInteractiveWindowFactory : IVsInteractiveWindowFactory
    {
        private readonly IComponentModel _componentModel;

        [ImportingConstructor]
        internal VsInteractiveWindowFactory(SVsServiceProvider serviceProvider)
        {
            _componentModel = (IComponentModel)serviceProvider.GetService(typeof(SComponentModel));
        }

        public IVsInteractiveWindow Create(Guid providerId, int instanceId, string title, IInteractiveEvaluator evaluator)
        {
            return new VsInteractiveWindow(_componentModel, providerId, instanceId, title, evaluator);
        }
    }
}
