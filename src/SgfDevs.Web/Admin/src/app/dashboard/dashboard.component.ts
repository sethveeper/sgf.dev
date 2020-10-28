import { Component } from '@angular/core';

@Component({
    selector: 'app-dashboard',
    template: `
        <app-host-dashboard *abpPermission="'SgfDevs.Dashboard.Host'"></app-host-dashboard>
        <app-tenant-dashboard *abpPermission="'SgfDevs.Tenant'"></app-tenant-dashboard>
    `,
})
export class DashboardComponent {
}
