import IFile from '../types/_file';
import { ItemType } from '../types/_item';

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
