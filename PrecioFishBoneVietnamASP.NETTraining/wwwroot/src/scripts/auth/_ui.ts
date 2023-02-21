import { AuthenticationResult, AccountInfo } from '@azure/msal-browser';

function showWelcomeMessage(account: string) {
  // Reconfiguring DOM elements
  console.log(account);
}

function updateUI(data: AuthenticationResult) {
  console.log(data);
}

export { updateUI, showWelcomeMessage };
