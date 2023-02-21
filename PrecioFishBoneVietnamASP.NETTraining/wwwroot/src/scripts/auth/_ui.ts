import { AuthenticationResult, AccountInfo } from '@azure/msal-browser';

function showWelcomeMessage(account: AccountInfo) {
  // Reconfiguring DOM elements
  console.log(account);
}

function updateUI(data: AuthenticationResult) {}

export { updateUI, showWelcomeMessage };
