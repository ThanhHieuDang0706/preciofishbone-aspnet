// Create the main myMSALObj instance
import { PublicClientApplication, AuthenticationResult, AccountInfo } from '@azure/msal-browser';
import $ from 'jquery';
import { loginRequest, msalConfig, tokenRequest } from './_authConfig';
import { updateUI } from './_ui';
import { renderTable } from '../components/_table';
import { renderAlert } from '../components/_alert';

export const myMSALObj = new PublicClientApplication(msalConfig);
const accountId = 0;

// get username from session storage azure id
let username = '';

export function signIn() {
  /**
   * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
   */

  myMSALObj.loginRedirect(loginRequest);
}

export function selectAccount() {
  /**
   * See here for more info on account retrieval:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
   */
  const currentAccounts = myMSALObj.getAllAccounts();
  if (currentAccounts.length === 0) {
  }
  if (currentAccounts.length > 1) {
    // Add your account choosing logic here
  } else if (currentAccounts.length === 1) {
    username = currentAccounts[0].username;
    updateUI(currentAccounts[0].name || '');
  }
}

/**
 * A promise handler needs to be registered for handling the
 * response returned from redirect flow. For more information, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/acquire-token.md
 */

export const handleResponse = (response: AuthenticationResult | null) => {
  if (response !== null) {
    const account = response.account as AccountInfo;
    username = account.username || '';
    updateUI(account.name || '');
    renderTable();
  } else {
    selectAccount();
  }
};

export const handleRedirectPromise = () => {
  myMSALObj
    .handleRedirectPromise()
    .then(handleResponse)
    .catch((error: any) => {
      renderAlert(error.message as string);
    });
};

export const addSignInButtonEventClick = () => {
  $('#sign-in-button').on('click', () => {
    signIn();
  });
};

export function signOut() {
  /**
   * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
   */

  const logoutRequest = {
    account: myMSALObj.getAccountByUsername(username),
    postLogoutRedirectUri: msalConfig.auth.redirectUri
  };

  myMSALObj.logoutRedirect(logoutRequest);
}

export function getTokenRedirect(request: any = tokenRequest): Promise<AuthenticationResult | void> {
  /**
   * See here for more info on account retrieval:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
   */
  request.account = myMSALObj.getAccountByUsername(username) as AccountInfo;

  return myMSALObj.acquireTokenSilent(request).catch(error => {
    // fallback to interaction when silent call fails
    return myMSALObj.acquireTokenRedirect(request).then((response: any) => {
      handleResponse(response);
    });
  });
}

// user info helper
export function getUserInfo() {
  return myMSALObj.getAccountByUsername(username) as AccountInfo;
}
