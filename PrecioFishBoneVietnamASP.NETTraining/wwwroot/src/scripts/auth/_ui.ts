import { AuthenticationResult, AccountInfo } from '@azure/msal-browser';
import $ from 'jquery';

function showWelcomeMessage(account: string) {
  // Reconfiguring DOM elements
}

function updateUI(name: string) {
  $('#account-section').empty();
  $('#account-section').append(`<h5>Welcome ${name}</h5>`);
}

export { updateUI, showWelcomeMessage };
