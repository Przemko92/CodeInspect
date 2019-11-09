using CodeInspect.Models;

namespace CodeInspect.Testers.Interfaces
{
    interface IInspector
    {
        void Init();
        InspectionResult Run();
    }
}