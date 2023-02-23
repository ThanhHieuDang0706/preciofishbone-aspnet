import Folder from '../types/_folder';
import FolderForCreation from '../types/_folderForCreation';

export default interface IFolderServices {
  getFolderInfoById(id: number): Promise<Folder>;
  getFolderWithItemsById(id: number): Promise<Folder>;
  createFolder(folder: FolderForCreation): Promise<Folder>;
  deleteFolder(folderId: number): Promise<void>;
}
