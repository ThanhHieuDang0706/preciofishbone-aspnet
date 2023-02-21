// Create the main myMSALObj instance
import msal, { PublicClientApplication } from '@azure/msal-browser';

import $ from 'jquery';
import { loginRequest, msalConfig } from './_authConfig';
import { showWelcomeMessage } from './_ui';
import ready from '../utilities/_helper';

export const myMSALObj = new PublicClientApplication(msalConfig);
let accountId = 0;

// get username from session storage azure id
let username = '';
function signIn() {
  /**
   * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
   */

  myMSALObj.loginRedirect(loginRequest);
}

const handleRedirectLogin = () => {
  myMSALObj
    .loginRedirect(loginRequest)
    .then(function(loginResponse) {
      accountId = loginResponse.account.homeAccountId;
      console.log(accountId);
      // Display signed-in user content, call API, etc.
    })
    .catch(function(error) {
      // login failure
      console.log(error);
    });
};

export function selectAccount() {
  /**
   * See here for more info on account retrieval:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
   */

  const currentAccounts = myMSALObj.getAllAccounts();

  if (currentAccounts.length === 0) {
    handleRedirectLogin();
  }
  if (currentAccounts.length > 1) {
    // Add your account choosing logic here
    console.warn('Multiple accounts detected.');
  } else if (currentAccounts.length === 1) {
    username = currentAccounts[0].username;
    showWelcomeMessage(currentAccounts[0].username);
  }
}

export const addSignInButtonEventClick = () => {
  $('#sign-in-button').on('click', () => {
    myMSALObj
      .loginRedirect(loginRequest)
      .then(function(loginResponse) {
        accountId = loginResponse.account.homeAccountId;
        console.log(accountId);
        // Display signed-in user content, call API, etc.
      })
      .catch(function(error) {
        // login failure
        console.log(error);
      });
  });
};

/**
 * A promise handler needs to be registered for handling the
 * response returned from redirect flow. For more information, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/acquire-token.md
 */

const handleResponse = response => {
  if (response !== null) {
    username = response.account.username;
    showWelcomeMessage(username);
  } else {
    selectAccount();
  }
};
myMSALObj
  .handleRedirectPromise()
  .then(handleResponse)
  .catch(error => {
    console.error(error);
  });

function signOut() {
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

function getTokenRedirect(request) {
  /**
   * See here for more info on account retrieval:
   * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
   */
  request.account = myMSALObj.getAccountByUsername(username);

  return myMSALObj.acquireTokenSilent(request).catch(error => {
    console.warn('silent token acquisition fails. acquiring token using redirect');
    if (error instanceof msal.InteractionRequiredAuthError) {
      // fallback to interaction when silent call fails
      return myMSALObj.acquireTokenRedirect(request);
    }
    console.warn(error);
  });
}
