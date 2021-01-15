using System;

namespace Volo.Abp.MultiTenancy
{
    public interface IMultiTenant
    {
        /// <summary>
        /// Id of the related tenant.
        /// </summary>
        Guid? TenantId { get; }//todo cuizj: tolong
    }
}
