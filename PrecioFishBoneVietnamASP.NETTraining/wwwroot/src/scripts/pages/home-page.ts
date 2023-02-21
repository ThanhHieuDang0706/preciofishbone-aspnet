import ready from '../utilities/_helper';
import { renderTable } from '../components/_table';
import renderModalForm from '../components/_modal';
import HomeState from '../types/_homepage';
import { ROOT_FOLDER_ID } from '../utilities/_folder';
import { addSignInButtonEventClick, handleRedirectPromise, selectAccount } from '../auth/_authRedirect';

ready(async () => {
  selectAccount();
  addSignInButtonEventClick();
  handleRedirectPromise();
  // state
  const state: HomeState = {
    currentFolderId: ROOT_FOLDER_ID,
    setCurrentFolderId: (id: number) => {
      state.currentFolderId = id;
    }
  };

  // render intial view
  renderModalForm(state);
  await renderTable(state);

  // $('#back-button').on('click', () => {
  //   state.setCurrentFolderId(Folder.loadSelectedFolder(state.currentFolderId).parentFolder as number);
  //   renderTable(state);
  // });
});
