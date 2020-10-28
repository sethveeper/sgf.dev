import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const GROUPS_GROUP_ROUTE_PROVIDER = [
    { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
    return () => {
        routes.add([
            {
                path: '/groups',
                iconClass: 'fas fa-file-alt',
                name: '::Menu:Groups',
                layout: eLayoutType.application,
                requiredPolicy: 'SgfDevs.Groups',
            },
        ]);
    };
}
