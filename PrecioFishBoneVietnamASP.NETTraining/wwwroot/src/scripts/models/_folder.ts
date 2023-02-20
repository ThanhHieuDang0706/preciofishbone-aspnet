import IFolder from '../types/_folder';
import IFile from '../types/_file';
import { ItemType } from '../types/_item';
import FolderServices from '../services/_folderServices';
import IFolderServices from '../services/_IFolderServices';

export default class Folder implements IFolder {
  id: number;

  name: string;

  parentFolder: number | null;

  files: Array<IFile>;

  folders: Array<IFolder>;

  items: Array<IFile | IFolder>;

  modified: number;

  modifiedBy: string;

  itemType: ItemType = ItemType.Folder;

  createdTime: number = Date.now();

  constructor(
    id: number,
    name: string,
    files: Array<IFile>,
    parentFolder: number | null,
    modified: number,
    modifiedBy: string,
    folders: Array<IFolder> = [],
  ) {
    this.id = id;
    this.name = name;
    this.files = files;
    this.parentFolder = parentFolder;
    this.folders = folders;
    this.modified = modified;
    this.modifiedBy = modifiedBy;
    this.items = [...this.files, ...this.folders];
    this.items.sort((a, b) => b.createdTime - a.createdTime);
  }
}

export class FolderHelper {
  folderService: IFolderServices = new FolderServices();

  getFolderInfoById = async (folderId: number, cb: (data: Record<string, unknown>) => void): Promise<IFolder | void> => {
    try {
      const folderData = await this.folderService.getFolderInfoById(folderId);
      cb({ data: folderData });
    } catch (error) {
      return cb({ error });
    }
  };

  getFolderWithItems = async (folderId: number, cb: (data: Record<string, unknown>) => void): Promise<IFolder | void> => {
    try {
      const folderData = await this.folderService.getFolderWithItemsById(folderId);
      cb({ data: folderData });
    } catch (error) {
      return cb({ error });
    }
  };

  createFolder = async (name: string, parentFolderId: number, modifiedBy: string, cb: (data: Record<string, unknown>) => void) => {
    try {
      const folderData = await this.folderService.createFolder({ name, parentFolderId, modifiedBy });
      cb({ data: folderData });
    } catch (error) {
      return cb({ error });
    }
  };
}
