import FileForCreation from '../types/_fileForCreation';
import MyFile, { FileUpdate } from '../types/_file';

export default interface IFileServices {
  uploadFile(file: FileForCreation): Promise<MyFile>;
  deleteFile(fileId: number): Promise<void>;
  updateFile(fileUpdate: FileUpdate): Promise<void>;
  downloadFile(fileId: number): Promise<any>;
}
