﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Navigation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.LanguageServices.Implementation.Utilities;

namespace Microsoft.VisualStudio.LanguageServices.Implementation.TableDataSource
{
    internal class UriNavigator
    {
        private static UriNavigator s_instance;

        private IServiceProvider _serviceProvider;

        public UriNavigator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static void AttachRequestNaviateEventHandler(Hyperlink hyperLink, IServiceProvider serviceProvider)
        {
            if (s_instance == null)
            {
                // this has a race, so we might end up have more than one navigator. but it shouldn't matter.
                s_instance = new UriNavigator(serviceProvider);
            }

            hyperLink.RequestNavigate += s_instance.OnRequestNavigate;
        }

        private void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (e.Uri == null)
            {
                return;
            }

            BrowserHelper.StartBrowser(_serviceProvider, e.Uri);
            e.Handled = true;

            var hyperlink = sender as Hyperlink;
            if (hyperlink == null)
            {
                return;
            }

            var item = hyperlink.Tag as DiagnosticData;
            if (item == null)
            {
                return;
            }

            var telemetry = item.CustomTags.Any(t => t == WellKnownDiagnosticTags.Telemetry);
            DiagnosticLogger.LogHyperlink("ErrorList", item.Id, item.Description != null, telemetry, e.Uri.AbsoluteUri);
        }
    }
}
