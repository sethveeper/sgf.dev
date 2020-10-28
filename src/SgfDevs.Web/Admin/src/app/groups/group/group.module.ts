import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { ThemeLeptonModule } from '@volo/abp.ng.theme.lepton';
import { GroupComponent } from './components/group.component';
import { GroupRoutingModule } from './group-routing.module';

@NgModule({
    declarations: [GroupComponent],
    imports: [
        GroupRoutingModule,
        CoreModule,
        ThemeSharedModule,
        ThemeLeptonModule,
        CommercialUiModule,
        NgxValidateCoreModule,
        NgbCollapseModule,
        NgbDatepickerModule,
        NgbDropdownModule,
    ],
})
export class GroupModule {
}
