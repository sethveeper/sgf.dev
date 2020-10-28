import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type {
    GetGroupsInput,
    GroupDto,
} from '../../../proxy/groups/models';
import { GroupService } from '../../../proxy/groups/group.service';

@Component({
    selector: 'app-group',
    changeDetection: ChangeDetectionStrategy.Default,
    providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
    templateUrl: './group.component.html',
    styles: [],
})
export class GroupComponent implements OnInit {
    data: PagedResultDto<GroupDto> = {
        items: [],
        totalCount: 0,
    };

    filters = {} as GetGroupsInput;

    form: FormGroup;

    isFiltersHidden = true;

    isModalBusy = false;

    isModalOpen = false;

    selected?: GroupDto;

    constructor(
        public readonly list: ListService,
        public readonly track: TrackByService,
        public readonly service: GroupService,
        private confirmation: ConfirmationService,
        private fb: FormBuilder
    ) {
    }

    ngOnInit() {
        const getData = (query: ABP.PageQueryParams) =>
            this.service.getList({
                ...query,
                ...this.filters,
                filterText: query.filter,
            });

        const setData = (list: PagedResultDto<GroupDto>) => (this.data = list);

        this.list.hookToQuery(getData).subscribe(setData);
    }

    clearFilters() {
        this.filters = {} as GetGroupsInput;
    }

    buildForm() {
        const {
            name,
            facebookLink,
            twitterLink,
            linkedInLink,
            instagramLink,
            youTubeLink,
            twitchLink,
            websiteLink,
            websiteTitle,
            locationText,
            establishedDateText,
        } = this.selected || {};

        this.form = this.fb.group({
            name: [name ?? null, [Validators.required]],
            facebookLink: [facebookLink ?? null, []],
            twitterLink: [twitterLink ?? null, []],
            linkedInLink: [linkedInLink ?? null, []],
            instagramLink: [instagramLink ?? null, []],
            youTubeLink: [youTubeLink ?? null, []],
            twitchLink: [twitchLink ?? null, []],
            websiteLink: [websiteLink ?? null, []],
            websiteTitle: [websiteTitle ?? null, []],
            locationText: [locationText ?? null, []],
            establishedDateText: [establishedDateText ?? null, []],
        });
    }

    hideForm() {
        this.isModalOpen = false;
        this.form.reset();
    }

    showForm() {
        this.buildForm();
        this.isModalOpen = true;
    }

    submitForm() {
        if (this.form.invalid) return;

        const request = this.selected
            ? this.service.update(this.selected.id, this.form.value)
            : this.service.create(this.form.value);

        this.isModalBusy = true;

        request
            .pipe(
                finalize(() => (this.isModalBusy = false)),
                tap(() => this.hideForm()),
            )
            .subscribe(this.list.get);
    }

    create() {
        this.selected = undefined;
        this.showForm();
    }

    update(record: GroupDto) {
        this.selected = record;
        this.showForm();
    }

    delete(record: GroupDto) {
        this.confirmation.warn(
            '::DeleteConfirmationMessage',
            '::AreYouSure',
            { messageLocalizationParams: [] }
        ).pipe(
            filter(status => status === Confirmation.Status.confirm),
            switchMap(() => this.service.delete(record.id)),
        ).subscribe(this.list.get);
    }
}
