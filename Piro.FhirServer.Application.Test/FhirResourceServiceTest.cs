using System.Collections.Generic;
using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Services;
using Xunit;
using Moq;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Test;

public class FhirResourceServiceTest
{
    [Fact]
    public void AddTest()
    {
        var resourceType = new ResourceType(id: null, name: "Patient");
        var fhirResource = new FhirResource(
            id: null,
            fhirId: "Test-1",
            resourceTypeId: null,
            resourceType: resourceType,
            indexResourceReferenceList: new List<IndexResourceReference>(),
            indexStringList: new List<IndexString>(),
            backResourceReferenceIndexList: new List<IndexResourceReference>());

        var addFhirResourceMock = new Mock<IAddFhirResource>();
        addFhirResourceMock.Setup(x => x.Add(It.IsAny<FhirResource>()));
        
        var fhirResourceService = new FhirResourceService(addFhirResourceMock.Object);
        
        fhirResourceService.Add(fhirResource);
        
    }
}