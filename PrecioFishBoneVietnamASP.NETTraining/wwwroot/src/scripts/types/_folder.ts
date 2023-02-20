import MyFile from './_file';
import Item from './_item';

export default interface Folder extends Item {
  parentFolder: number | null;
  files: Array<MyFile>;
  folders: Array<Folder>;
  items: Array<MyFile | Folder>;
}
