import IFileServices from './_IFileServices';
import FileForCreation from '../types/_fileForCreation';
import axios from '../utilities/_axios';
import { FileUpdate } from '../types/_file';

class FileServices implements IFileServices {
  uploadFile = async (fileForCreation: FileForCreation) => {
    const formData = new FormData();
    Object.keys(fileForCreation).forEach(key => {
      formData.append(key, fileForCreation[key as keyof FileForCreation] as string);
    });

    const response = await axios.post('/api/files/upload', formData, {
      headers: {
        'Content-Type': 'multipart/form-data'
      }
    });
    return response.data;
  };

  deleteFile = async (fileId: number) => {
    const response = await axios.delete(`/api/files/${fileId}`);
    return response.data;
  };

  updateFile = async (fileUpdate: FileUpdate) => {
    const response = await axios.put(`/api/files`, fileUpdate);
    return response.data;
  };

  downloadFile = async (fileId: number) => {
    const response = await axios.get(`/api/files/${fileId}/download`, {
      responseType: 'arraybuffer'
    });
    return response;
  };
}

export default FileServices;
