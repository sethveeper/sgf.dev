using SgfDevs.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SgfDevs.Permissions
{
    public class SgfDevsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(SgfDevsPermissions.GroupName);

            myGroup.AddPermission(SgfDevsPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(SgfDevsPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(SgfDevsPermissions.MyPermission1, L("Permission:MyPermission1"));

            var groupPermission = myGroup.AddPermission(SgfDevsPermissions.Groups.Default, L("Permission:Groups"));
            groupPermission.AddChild(SgfDevsPermissions.Groups.Create, L("Permission:Create"));
            groupPermission.AddChild(SgfDevsPermissions.Groups.Edit, L("Permission:Edit"));
            groupPermission.AddChild(SgfDevsPermissions.Groups.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SgfDevsResource>(name);
        }
    }
}
