import FileUploaderState from '../types/_fileUploaderState';

const fileUploader = `
<div class="file-upload">
  <button class="file-upload-btn" type="button">Add File</button>

  <div class="file-upload-wrap">
    <input class="file-upload-input" type="file" />
  </div>
  <div class="file-upload-content">
    
  </div>
</div>
`;

export const fileUploaderState: FileUploaderState = {
  file: null,
  reader: new FileReader(),
  resetState: () => {
    fileUploaderState.file = null;
    fileUploaderState.reader = new FileReader();
  },
  setFile: (file: any) => {
    fileUploaderState.file = file;
  }
};

const renderFileUploadContent = (fileNameWithExtensions: string, fileReader: FileReader) => {
  return `<a href="${fileReader.result}" download="${fileNameWithExtensions}">${fileNameWithExtensions}</a>;`;
};
// add event listners and logic when rendering
const onUploadFile = () => {
  $('.file-upload-input').on('change', () => {
    const [file] = $('.file-upload-input').prop('files');
    fileUploaderState.setFile(file);
    const { reader } = fileUploaderState;

    reader.onloadend = () => {
      const fileUploadContent = renderFileUploadContent(file.name, reader);
      $('.file-upload-content').append(fileUploadContent);
    };
    reader.readAsDataURL(file);
  });
};

const onClickOkButtonSubmitUploadFile = () => {
  $('#modal-ok-button').attr('data-action', 'upload');
};
const renderFileUploader = () => {
  // show modal
  const modalBody = $('.modal-body');

  modalBody.empty();
  modalBody.append(fileUploader);
  onUploadFile();
  onClickOkButtonSubmitUploadFile();
  $('.file-upload-btn').on('click', () => {
    $('.file-upload-input').trigger('click');
  });
};
export default renderFileUploader;
