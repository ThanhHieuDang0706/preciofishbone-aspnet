import IFolder from '../types/_folder';
import IFile from '../types/_file';
import { ItemType } from '../types/_item';
import FolderServices from '../services/_folderServices';
import IFolderServices from '../services/_IFolderServices';

export default class Folder implements IFolder {
  id: number;

  name: string;

  parentFolderId: number | null;

  files: Array<IFile>;

  folders: Array<IFolder>;

  items: Array<IFolder | IFile>;

  modified: string;

  modifiedBy: string;

  itemType: ItemType = ItemType.Folder;

  createdTime: string = Date.now().toString();

  constructor(
    id: number,
    name: string,
    files: Array<IFile>,
    parentFolderId: number | null,
    modified: string,
    modifiedBy: string,
    folders: Array<IFolder>
  ) {
    this.id = id;
    this.name = name;
    this.files = files;
    this.parentFolderId = parentFolderId;
    this.folders = folders;
    this.modified = modified;
    this.modifiedBy = modifiedBy;
    this.items = [...files, ...folders];

    // sort items ascending date created
    this.items.sort((a, b) => Date.parse(a.createdTime) - Date.parse(b.createdTime));
  }
}

export class FolderHelper {
  folderService: IFolderServices = new FolderServices();

  getFolderInfoById = async (folderId: number, cb: (data: any) => void): Promise<IFolder | void> => {
    try {
      const folderData = await this.folderService.getFolderInfoById(folderId);

      cb({ data: folderData });
    } catch (error) {
      return cb({ error });
    }
  };

  getFolderWithItems = async (folderId: number, cb: (data: Record<string, Folder | any>) => void): Promise<IFolder | void> => {
    try {
      const folderData = await this.folderService.getFolderWithItemsById(folderId);

      const folderToReturn = new Folder(
        folderData.id,
        folderData.name,
        folderData.files,
        folderData.parentFolderId,
        folderData.modified,
        folderData.modifiedBy,
        folderData.folders
      );
      cb({ data: folderToReturn });
    } catch (error) {
      return cb({ error });
    }
  };

  createFolder = async (name: string, parentFolderId: number, modifiedBy: string, cb: (data: any) => void) => {
    try {
      const folderData = await this.folderService.createFolder({ name, parentFolderId, modifiedBy });
      cb({ data: folderData });
    } catch (error) {
      return cb({ error });
    }
  };
}
