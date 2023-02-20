import $ from 'jquery';
import { parseFileExtension } from '../utilities/_file';
import ready, { clearInput } from '../utilities/_helper';
import renderTable from '../components/_table';
import Folder from '../models/_folder';
import MyFile from '../models/_file';
import renderModalForm from '../components/_modal';
import { FileUpdate } from '../types/_file';
import { HomeState } from '../types/_homepage';
import { ROOT_FOLDER_ID } from '../utilities/_folder';

ready(async () => {
  // state
  const state: HomeState = {
    currentFolderId: ROOT_FOLDER_ID,
    setCurrentFolderId: (id: number) => {
      state.currentFolderId = id;
    },
  };

  // render intial view
  renderModalForm();
  renderTable(state);

  // $('#back-button').on('click', () => {
  //   state.setCurrentFolderId(Folder.loadSelectedFolder(state.currentFolderId).parentFolder as number);
  //   renderTable(state);
  // });
});
