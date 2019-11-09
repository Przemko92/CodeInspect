using CodeInspect.Models;

namespace CodeInspect.Builders.Interfaces
{
    interface IBuildable
    {
        ParamRule Build();
    }
}