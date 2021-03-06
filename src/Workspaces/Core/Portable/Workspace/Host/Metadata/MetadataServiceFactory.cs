﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Composition;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Host.Mef;

namespace Microsoft.CodeAnalysis.Host
{
    [ExportWorkspaceServiceFactory(typeof(IMetadataService), ServiceLayer.Default), Shared]
    internal sealed class MetadataServiceFactory : IWorkspaceServiceFactory
    {
        public IWorkspaceService CreateService(HostWorkspaceServices workspaceServices)
        {
            return new Service(workspaceServices.GetService<IDocumentationProviderService>());
        }

        private sealed class Service : IMetadataService
        {
            private readonly IDocumentationProviderService _documentationService;
            private readonly Provider _provider;

            public Service(IDocumentationProviderService documentationService)
            {
                _documentationService = documentationService;
                _provider = new Provider(this);
            }

            public MetadataFileReferenceProvider GetProvider()
            {
                return _provider;
            }

            public PortableExecutableReference GetReference(string resolvedPath, MetadataReferenceProperties properties)
            {
                return MetadataReference.CreateFromFile(resolvedPath, properties, _documentationService.GetDocumentationProvider(resolvedPath));
            }
        }

        private sealed class Provider : MetadataFileReferenceProvider
        {
            private readonly Service _service;

            internal Provider(Service service)
            {
                Debug.Assert(service != null);
                _service = service;
            }

            public override PortableExecutableReference GetReference(string resolvedPath, MetadataReferenceProperties properties)
            {
                return _service.GetReference(resolvedPath, properties);
            }
        }
    }
}
