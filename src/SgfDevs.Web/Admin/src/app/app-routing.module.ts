import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
    },
    {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
        canActivate: [AuthGuard, PermissionGuard],
        data: {
            requiredPolicy: 'SgfDevs.Dashboard.Host || AbpAccount.SettingManagement',
        },
    },
    {
        path: 'identity',
        loadChildren: () => import('@volo/abp.ng.identity').then((m) => m.IdentityModule.forLazy()),
    },
    {
        path: 'account',
        loadChildren: () =>
            import('@volo/abp.ng.account').then((m) => m.AccountModule.forLazy({ redirectUrl: '/' })),
    },
    {
        path: 'language-management',
        loadChildren: () =>
            import('@volo/abp.ng.language-management').then((m) => m.LanguageManagementModule.forLazy()),
    },
    {
        path: 'saas',
        loadChildren: () => import('@volo/abp.ng.saas').then((m) => m.SaasModule.forLazy()),
    },
    {
        path: 'audit-logs',
        loadChildren: () =>
            import('@volo/abp.ng.audit-logging').then((m) => m.AuditLoggingModule.forLazy()),
    },
    {
        path: 'identity-server',
        loadChildren: () =>
            import('@volo/abp.ng.identity-server').then((m) => m.IdentityServerModule.forLazy()),
    },
    {
        path: 'text-template-management',
        loadChildren: () =>
            import('@volo/abp.ng.text-template-management').then((m) =>
                m.TextTemplateManagementModule.forLazy()
            ),
    },
    {
        path: 'setting-management',
        loadChildren: () =>
            import('@abp/ng.setting-management').then((m) => m.SettingManagementModule.forLazy()),
    },
    { path: 'groups', loadChildren: () => import('./groups/group/group.module').then(m => m.GroupModule) },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {
}
