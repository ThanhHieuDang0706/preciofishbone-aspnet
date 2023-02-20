export enum ItemType {
  File = 0,
  Folder = 1,
}
export default interface Item {
  id: number;
  name: string;
  modified: string;
  modifiedBy: string;
  itemType: ItemType;
  createdTime: string;
}
