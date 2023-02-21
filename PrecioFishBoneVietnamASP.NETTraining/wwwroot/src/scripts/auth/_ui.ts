import { AuthenticationResult, AccountInfo } from '@azure/msal-browser';
import $ from 'jquery';

function showWelcomeMessage(account: string) {
  // Reconfiguring DOM elements
}

function updateUI(accountInfo: AccountInfo) {
  $('#account-section').empty();
  $('#account-section').append(`<h5>Welcome ${accountInfo.name}</h5>`);
}

export { updateUI, showWelcomeMessage };
