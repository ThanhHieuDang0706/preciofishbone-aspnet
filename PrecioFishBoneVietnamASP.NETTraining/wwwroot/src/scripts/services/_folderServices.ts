import IFolderServices from './_IFolderServices';
import axios from '../utilities/_axios';
import FolderForCreation from '../types/_folderForCreation';

class FolderServices implements IFolderServices {
  getFolderInfoById = async (folderId = -1) => {
    const response = await axios.get(`/api/folders/${folderId}?getWithItems=false`);
    return response.data;
  };

  getFolderWithItemsById = async (folderId: number) => {
    const response = await axios.get(`/api/folders/${folderId}?getWithItems=true`);
    return response.data;
  };

  createFolder = async (folder: FolderForCreation) => {
    const response = await axios.post('/api/folders', folder);
    return response.data;
  };
}

export default FolderServices;
