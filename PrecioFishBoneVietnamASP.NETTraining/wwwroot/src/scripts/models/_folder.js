import { ItemType } from '../types/_item';
import FolderServices from '../services/_folderServices';
export default class Folder {
    id;
    name;
    parentFolderId;
    files;
    folders;
    items;
    modified;
    modifiedBy;
    itemType = ItemType.Folder;
    createdTime = Date.now().toString();
    constructor(id, name, files, parentFolderId, modified, modifiedBy, folders) {
        this.id = id;
        this.name = name;
        this.files = files;
        this.parentFolderId = parentFolderId;
        this.folders = folders;
        this.modified = modified;
        this.modifiedBy = modifiedBy;
        this.items = [...files, ...folders];
        // sort items ascending date created
        this.items.sort((a, b) => Date.parse(a.createdTime) - Date.parse(b.createdTime));
    }
}
export class FolderHelper {
    folderService = new FolderServices();
    getFolderInfoById = async (folderId, cb) => {
        try {
            const folderData = await this.folderService.getFolderInfoById(folderId);
            cb({ data: folderData });
        }
        catch (error) {
            return cb({ error });
        }
    };
    getFolderWithItems = async (folderId, cb) => {
        try {
            const folderData = await this.folderService.getFolderWithItemsById(folderId);
            const folderToReturn = new Folder(folderData.id, folderData.name, folderData.files, folderData.parentFolderId, folderData.modified, folderData.modifiedBy, folderData.folders);
            cb({ data: folderToReturn });
        }
        catch (error) {
            return cb({ error });
        }
    };
    createFolder = async (name, parentFolderId, modifiedBy, cb) => {
        try {
            const folderData = await this.folderService.createFolder({ name, parentFolderId, modifiedBy });
            cb({ data: folderData });
        }
        catch (error) {
            return cb({ error });
        }
    };
}
