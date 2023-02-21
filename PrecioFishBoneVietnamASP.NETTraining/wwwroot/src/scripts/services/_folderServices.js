import axios from '../utilities/_axios';
class FolderServices {
    getFolderInfoById = async (folderId = -1) => {
        const response = await axios.get(`/api/folders/${folderId}?getWithItems=false`);
        return response.data;
    };
    getFolderWithItemsById = async (folderId) => {
        const response = await axios.get(`/api/folders/${folderId}?getWithItems=true`);
        return response.data;
    };
    createFolder = async (folder) => {
        const response = await axios.post('/api/folders', folder);
        return response.data;
    };
}
export default FolderServices;
