import axios from '../utilities/_axios';
class FileServices {
    uploadFile = async (fileForCreation) => {
        const formData = new FormData();
        Object.keys(fileForCreation).forEach(key => {
            formData.append(key, fileForCreation[key]);
        });
        const response = await axios.post('/api/files/upload', formData, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
        return response.data;
    };
}
export default FileServices;
