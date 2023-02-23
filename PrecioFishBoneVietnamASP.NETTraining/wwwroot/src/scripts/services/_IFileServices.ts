import FileForCreation from '../types/_fileForCreation';
import MyFile from '../types/_file';

export default interface IFileServices {
  uploadFile(file: FileForCreation): Promise<MyFile>;
  deleteFile(fileId: number): Promise<void>;
}
