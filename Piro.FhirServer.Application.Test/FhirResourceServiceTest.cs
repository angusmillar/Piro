using System.Collections.Generic;
using Piro.FhirServer.Application.Domain.Models;
using Xunit;
using Moq;
using Piro.FhirServer.Application.Domain.Repositories;
using Piro.FhirServer.Application.Services;

namespace Piro.FhirServer.Application.Test;

public class FhirResourceServiceTest
{
    [Fact]
    public void AddTest()
    {
        var resourceType = new ResourceType(id: 1, name: "Patient");
        var fhirResource = new ResourceStore(
            id: null,
            fhirId: "Test-1",
            resourceTypeId: resourceType.Id!.Value,
            resourceType: resourceType,
            referenceIndexList: new List<IndexReference>(),
            stringIndexList: new List<IndexString>(),
            backResourceReferenceIndexList: new List<IndexReference>());

        var addFhirResourceMock = new Mock<IResourceStoreAdd>();
        addFhirResourceMock.Setup(x => x.Add(It.IsAny<ResourceStore>()));
        
        var fhirResourceService = new ResourceStoreService(addFhirResourceMock.Object);
        
        fhirResourceService.Add(fhirResource);
        
    }
}