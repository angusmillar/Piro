// extern alias Stu3;
// using Stu3::Hl7.Fhir.Serialization;

extern alias R4;
extern alias Stu3;
using Hl7.Fhir.Model;
using ModelR4 = R4.Hl7.Fhir.Model;
using ModelStu3 = Stu3.Hl7.Fhir.Model;

using SerializationStu3 = Stu3.Hl7.Fhir.Serialization;
using SerializationR4 = R4.Hl7.Fhir.Serialization;

namespace Piro.PlayArea;

public class TestParseing
{
    public void Parse(string resourceString)
    {
        //Hl7.Fhir.Model.Resource resource = ParseStu3Json(resourceString);
        Hl7.Fhir.Model.Resource resource = ParseR4Json(resourceString);

        resource.Meta = new Hl7.Fhir.Model.Meta() { LastUpdated = DateTimeOffset.Now, VersionId = "V1" };
        
        string ResourceName = resource.TypeName;

        ModelStu3.Patient Patient3 = (ModelStu3.Patient)resource;
        

        if (resource is ModelStu3.Patient patientStu3)
        {
            string familyName = patientStu3.Name.First().Family;
        }
        else if (resource is ModelR4.Patient patientR4)
        {
            string familyName = patientR4.Name.First().Family;
        }

    }
    
    public Hl7.Fhir.Model.Resource ParseStu3Json(string jsonResource)
    {      
        try
        {
            SerializationStu3.FhirJsonParser FhirJsonParser = new SerializationStu3.FhirJsonParser();
            return FhirJsonParser.Parse<Hl7.Fhir.Model.Resource>(jsonResource);
        }
        catch (Exception oExec)
        {
            throw oExec;
        }
    }
    
    public Hl7.Fhir.Model.Resource ParseR4Json(string jsonResource)
    {      
        try
        {
            SerializationR4.FhirJsonParser FhirJsonParser = new SerializationR4.FhirJsonParser();
            return FhirJsonParser.Parse<Hl7.Fhir.Model.Resource>(jsonResource);
        }
        catch (Exception oExec)
        {
            throw oExec;
        }
    }
}