import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER, Provider } from '@angular/core';
import { APP_BASE_HREF } from "@angular/common";

export const APP_ROUTE_PROVIDER: Provider[] = [
    { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
    { provide: APP_BASE_HREF, useValue: '/admin' },
];

function configureRoutes(routes: RoutesService) {
    return () => {
        routes.add([
            {
                path: '/',
                name: '::Menu:Home',
                iconClass: 'fas fa-home',
                order: 1,
                layout: eLayoutType.application,
            },
            {
                path: '/dashboard',
                name: '::Menu:Dashboard',
                iconClass: 'fas fa-chart-line',
                order: 2,
                layout: eLayoutType.application,
                requiredPolicy: 'SgfDevs.Dashboard.Host || AbpAccount.SettingManagement',
            },
        ]);
    };
}
