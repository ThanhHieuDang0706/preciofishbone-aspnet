import { UserAgentApplication } from 'msal';
import { loginRequest, msalConfig } from './_authConfig';
import { showWelcomeMessage } from './_ui';

export const myMSALObj = new UserAgentApplication(msalConfig);

function signIn() {
  myMSALObj
    .loginPopup(loginRequest)
    .then(loginResponse => {
      if (myMSALObj.getAccount()) {
        showWelcomeMessage(myMSALObj.getAccount());
      }
    })
    .catch(error => {
      console.log(error);
    });
}

function getTokenPopup(request) {
  return myMSALObj.acquireTokenSilent(request).catch(error => {
    console.log(error);
    console.log('silent token acquisition fails. acquiring token using popup');

    // fallback to interaction when the silent call fails
    return myMSALObj
      .acquireTokenPopup(request)
      .then(tokenResponse => {
        return tokenResponse;
      })
      .catch(error => {
        console.log(error);
      });
  });
}

function signOut() {
  myMSALObj.logout();
}

function callMSGraph(theUrl, accessToken, callback) {
  const xmlHttp = new XMLHttpRequest();
  xmlHttp.onreadystatechange = function() {
    if (this.readyState === 4 && this.status === 200) {
      callback(JSON.parse(this.responseText));
    }
  };
  xmlHttp.open('GET', theUrl, true); // true for asynchronous
  xmlHttp.setRequestHeader('Authorization', `Bearer ${accessToken}`);
  xmlHttp.send();
}
