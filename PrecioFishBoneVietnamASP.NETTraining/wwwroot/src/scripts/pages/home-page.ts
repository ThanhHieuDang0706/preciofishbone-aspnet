import ready from '../utilities/_helper';
import { renderTable } from '../components/_table';
import renderModalForm from '../components/_modal';
import HomeState from '../types/_homepage';
import { ROOT_FOLDER_ID } from '../utilities/_folder';
import { addSignInButtonEventClick, getTokenRedirect, handleRedirectPromise, selectAccount } from '../auth/_authRedirect';

export const homeState: HomeState = {
  currentFolderId: ROOT_FOLDER_ID,
  setCurrentFolderId: (id: number) => {
    homeState.currentFolderId = id;
  }
};

ready(async () => {
  selectAccount();
  handleRedirectPromise();
  addSignInButtonEventClick();

  // render intial view
  renderModalForm(homeState);
  await renderTable(homeState);

  // $('#back-button').on('click', () => {
  //   state.setCurrentFolderId(Folder.loadSelectedFolder(state.currentFolderId).parentFolder as number);
  //   renderTable(state);
  // });
});
