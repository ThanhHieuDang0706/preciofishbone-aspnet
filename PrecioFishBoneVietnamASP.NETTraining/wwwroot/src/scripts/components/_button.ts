import $ from 'jquery';
import Folder from '../types/_folder';
import { folderHelper } from '../utilities/_folder';
import { homeState } from '../utilities/_state';
import { renderTable } from './_table';

const goBackButton = `
    <button type="button" class="position-absolute btn circle-button" id="back-button">
      <i class="fa fa-arrow-left"></i>
    </button>`;

export const addBackButtonEventClickHandler = () => {
  $('#back-button').on('click', () => {
    folderHelper.getFolderWithItems(homeState.parentFolderId || -1, res => {
      if (res.error) {
      } else {
        const folder = <Folder>res.data;
        homeState.setParentFolderId(folder.parentFolderId);
        homeState.setCurrentFolderId(folder.id);
        renderTable();
      }
    });
  });
};

export const renderBackButton = () => {
  $('body').append(goBackButton);
  addBackButtonEventClickHandler();
};
