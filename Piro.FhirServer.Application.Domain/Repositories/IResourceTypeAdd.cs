﻿using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IResourceTypeAdd
{
    public void Add(ResourceType resourceType);
}