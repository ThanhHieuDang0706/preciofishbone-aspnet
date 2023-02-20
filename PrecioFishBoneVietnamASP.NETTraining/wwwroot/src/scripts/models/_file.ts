import IFile from '../types/_file';
import { ItemType } from '../types/_item';

export default class MyFile implements IFile {
  id: number;

  name: string;

  fileExtension: string;

  modified: number;

  modifiedBy: string;

  itemType: ItemType = ItemType.File;

  createdTime: number;

  constructor(id: number, name: string, fileExtension: string, modified: number, modifiedBy: string, createdTime: number = Date.now()) {
    this.id = id;
    this.name = name;
    this.fileExtension = fileExtension;
    this.modified = modified;
    this.modifiedBy = modifiedBy;
    this.createdTime = createdTime;
  }
}
