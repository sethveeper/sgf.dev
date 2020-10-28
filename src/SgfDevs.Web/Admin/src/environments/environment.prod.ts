import { Config } from '@abp/ng.core';

const baseUrl = 'https://localhost:44359/admin';

export const environment = {
    production: true,
    application: {
        baseUrl,
        name: 'SgfDevs',
    },
    oAuthConfig: {
        issuer: 'https://localhost:44359',
        redirectUri: baseUrl,
        clientId: 'SgfDevs_App',
        responseType: 'code',
        scope: 'offline_access SgfDevs',
    },
    apis: {
        default: {
            url: 'https://localhost:44359',
            rootNamespace: 'SgfDevs',
        },
    },
} as Config.Environment;
