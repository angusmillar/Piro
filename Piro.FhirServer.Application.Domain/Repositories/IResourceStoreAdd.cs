﻿using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IResourceStoreAdd
{
    public Task Add(ResourceStore resourceStore);
}