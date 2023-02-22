import $ from 'jquery';
import { signOut } from './_authRedirect';

function showWelcomeMessage(account: string) {
  // Reconfiguring DOM elements
}

const signOutButton = `<button id="sign-out-button" class="btn btn-danger float-right text-right">Sign Out</button>`;

function updateUI(name: string) {
  $('#account-section').empty();
  $('#account-section').append(`<h5>Welcome ${name}</h5>`);
  $('#account-section').append(`${signOutButton}`);
  $('#sign-out-button').on('click', () => {
    signOut();
  });
}

export { updateUI, showWelcomeMessage };
