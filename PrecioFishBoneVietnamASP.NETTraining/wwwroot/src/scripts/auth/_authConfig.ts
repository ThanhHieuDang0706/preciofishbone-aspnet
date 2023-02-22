import { RedirectRequest } from '@azure/msal-browser';

const msalConfig = {
  auth: {
    clientId: '8dc36eea-531c-4787-8e9b-38de4db29624',
    authority: 'https://login.microsoftonline.com/ccb176fe-8010-4cf0-a10c-0a3c789a1cef',
    redirectUri: 'https://localhost:7214/index.html',
    postLogoutRedirectUri: 'https://localhost:7214/index.html'
  },
  cache: {
    cacheLocation: 'localStorage', // This configures where your cache will be stored
    storeAuthStateInCookie: true // Set this to "true" if you're having issues on Internet Explorer 11 or Edge
  },
  system: {}
};

// Add scopes for the ID token to be used at Microsoft identity platform endpoints.
const loginRequest: RedirectRequest = {
  scopes: ['openid', 'profile', 'User.Read', 'api://8dc36eea-531c-4787-8e9b-38de4db29624/Folders.Read']
};

// Add scopes for the access token to be used at Microsoft Graph API endpoints.
const tokenRequest = {
  scopes: ['api://8dc36eea-531c-4787-8e9b-38de4db29624/Folders.Read'],
  grant_type: 'authorization_code',
  response_type: 'code',
  client_id: msalConfig.auth.clientId,
  tenant: 'ccb176fe-8010-4cf0-a10c-0a3c789a1cef',
  redirect_uri: msalConfig.auth.redirectUri
};

export { msalConfig, loginRequest, tokenRequest };
