import IFileServices from './_IFileServices';
import FileForCreation from '../types/_fileForCreation';
import axios from '../utilities/_axios';

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
}

export default FileServices;
