import { ItemType } from '../types/_item';
import FileServices from '../services/_fileServices';
export default class MyFile {
    id;
    name;
    fileExtension;
    modified;
    modifiedBy = Date.now().toString();
    itemType = ItemType.File;
    createdTime = Date.now().toString();
    constructor(id, name, fileExtension, modified, modifiedBy, createdTime = Date.now().toString()) {
        this.id = id;
        this.name = name;
        this.fileExtension = fileExtension;
        this.modified = modified;
        this.modifiedBy = modifiedBy;
        this.createdTime = createdTime;
    }
}
export class FileHelper {
    fileService = new FileServices();
    // upload file
    uploadFile = async (fileForCreation, cb) => {
        try {
            const fileData = await this.fileService.uploadFile(fileForCreation);
            cb({ data: fileData });
        }
        catch (error) {
            return cb({ error });
        }
    };
}
