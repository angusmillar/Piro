// See https://aka.ms/new-console-template for more information

extern alias R4;
using Hl7.Fhir.Rest;
using Piro.PlayArea;
using R4::Hl7.Fhir.Model;

R4.Hl7.Fhir.Model.Patient patient = new Patient();
patient.Id = "FhirID";
patient.Name = new List<HumanName>() { new HumanName() { Family = "MIllar" } };

string resourceJason = String.Empty;

try
{
    var FhirJsonSerializer = new R4.Hl7.Fhir.Serialization.FhirJsonSerializer();
    FhirJsonSerializer.Settings.Pretty = true;

    resourceJason = FhirJsonSerializer.SerializeToString(patient, SummaryType.False);
}
catch (Exception oExec)
{
    
}    
    
    
    
TestParseing testParseing = new TestParseing();
testParseing.Parse(resourceJason);

Console.WriteLine("Hello, World!");