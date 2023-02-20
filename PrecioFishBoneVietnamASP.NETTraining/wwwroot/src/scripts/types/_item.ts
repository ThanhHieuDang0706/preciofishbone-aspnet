export enum ItemType {
  File = 0,
  Folder = 1,
}
export default interface Item {
  id: number;
  name: string;
  modified: number;
  modifiedBy: string;
  itemType: ItemType;
  createdTime: number;
}
