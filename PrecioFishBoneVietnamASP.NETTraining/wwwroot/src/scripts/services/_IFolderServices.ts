import Folder from '../types/_folder';
import FolderForCreation from '../types/_folderForCreation';
import Item from '../types/_item';

export default interface IFolderServices {
  getFolderInfoById(id: number): Promise<Folder>;
  getFolderWithItemsById(id: number): Promise<Array<Item>>;
  createFolder(folder: FolderForCreation): Promise<Folder>;
}
