type FileUploaderState = {
  file: any;
  reader: FileReader;
  resetState: () => void;
  setFile: (file: any) => void;
};
export default FileUploaderState;
