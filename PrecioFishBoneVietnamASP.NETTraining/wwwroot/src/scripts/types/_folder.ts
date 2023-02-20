import MyFile from './_file';
import Item from './_item';

export default interface Folder extends Item {
  parentFolderId: number | null;
  files: Array<MyFile>;
  folders: Array<Folder>;
  items: Array<Item>;
}
