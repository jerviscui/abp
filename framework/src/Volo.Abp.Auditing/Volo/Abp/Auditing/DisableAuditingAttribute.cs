using System;

namespace Volo.Abp.Auditing
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class DisableAuditingAttribute : Attribute
    {
        //todo cuizj: add base class for check
    }
}