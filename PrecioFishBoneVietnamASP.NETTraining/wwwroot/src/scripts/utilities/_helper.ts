import $ from 'jquery';
import MyFile from '../types/_file';
import Folder from '../types/_folder';
import Item, { ItemType } from '../types/_item';

const ready = (fn: () => void) => {
  if (document.readyState !== 'loading') {
    fn();
  } else {
    document.addEventListener('DOMContentLoaded', fn);
  }
};

export const clearInput = () => {
  $('#name').val('');
  $('#modified').val('');
  $('#modifiedBy').val('');
  $('#modal-title').removeAttr('data-id');
};

export const mapItems = (items: Array<Item>) => {
  const fileMapper: Record<number, MyFile> = {};
  const folderMapper: Record<number, Folder> = {};
  items.forEach(item => {
    if (item.itemType === ItemType.File) {
      fileMapper[item.id] = item as MyFile;
    } else if (item.itemType === ItemType.Folder) {
      folderMapper[item.id] = item as Folder;
    }
  });
  return { fileMapper, folderMapper };
};

export default ready;
