import ready from '../utilities/_helper';
import { renderTable } from '../components/_table';
import renderModalForm from '../components/_modal';
import { addSignInButtonEventClick, handleRedirectPromise, selectAccount } from '../auth/_authRedirect';
import { renderEmptyAlert } from '../components/_alert';
import { homeState } from '../utilities/_state';
import { renderBackButton } from '../components/_button';

ready(async () => {
  selectAccount();
  handleRedirectPromise();
  addSignInButtonEventClick();

  // render intial view
  renderModalForm(homeState);
  renderEmptyAlert();
  renderBackButton();
  await renderTable(homeState);
});
