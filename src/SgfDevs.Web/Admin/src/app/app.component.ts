import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
    selector: 'app-root',
    template: `
        <abp-loader-bar></abp-loader-bar>
        <abp-dynamic-layout></abp-dynamic-layout>
    `,
})
export class AppComponent implements OnInit {
    constructor(private router: Router) {
    }

    public ngOnInit(): void {
        (window as any).ngRouter = this.router;
    }
}
