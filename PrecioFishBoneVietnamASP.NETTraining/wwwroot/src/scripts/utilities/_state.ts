import HomeState from '../types/_homepage';
import { ROOT_FOLDER_ID } from './_folder';

export const homeState: HomeState = {
  currentFolderId: ROOT_FOLDER_ID,
  parentFolderId: null,
  editingFolderId: null,
  setCurrentFolderId: (id: number) => {
    homeState.currentFolderId = id;
  },
  setParentFolderId: (id: number | null) => {
    homeState.parentFolderId = id;
  },
  setEditingFolderId: (id: number | null) => {
    homeState.editingFolderId = id;
  }
};
