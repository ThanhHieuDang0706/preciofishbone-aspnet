import IFile, { FileUpdate } from '../types/_file';
import { ItemType } from '../types/_item';
import FileForCreation from '../types/_fileForCreation';
import IFileServices from '../services/_IFileServices';
import FileServices from '../services/_fileServices';

export default class MyFile implements IFile {
  id: number;

  name: string;

  fileExtension: string;

  modified: string;

  modifiedBy: string = Date.now().toString();

  itemType: ItemType = ItemType.File;

  createdTime: string = Date.now().toString();

  constructor(id: number, name: string, fileExtension: string, modified: string, modifiedBy: string, createdTime: string = Date.now().toString()) {
    this.id = id;
    this.name = name;
    this.fileExtension = fileExtension;
    this.modified = modified;
    this.modifiedBy = modifiedBy;
    this.createdTime = createdTime;
  }
}

export class FileHelper {
  fileService: IFileServices = new FileServices();

  // upload file
  uploadFile = async (fileForCreation: FileForCreation, cb: (data: Record<string, IFile | any>) => void): Promise<IFile | void> => {
    try {
      const fileData = await this.fileService.uploadFile(fileForCreation);
      cb({ data: fileData });
    } catch (error) {
      return cb({ error });
    }
  };

  deleteFile = async (fileId: number, cb: (data: Record<string, any>) => void) => {
    try {
      await this.fileService.deleteFile(fileId);
      cb({ data: fileId });
    } catch (error) {
      return cb({ error });
    }
  };

  updateFile = async (fileUpdate: FileUpdate, cb: (data: Record<string, IFile | any>) => void) => {
    try {
      const fileData = await this.fileService.updateFile(fileUpdate);
      cb({ data: fileData });
    } catch (error) {
      return cb({ error });
    }
  };
}
