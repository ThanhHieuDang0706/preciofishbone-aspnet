// eslint-disable-next-line import/named
import HomeState from '../types/_homepage';
import MyFile from '../types/_file';
import Item, { ItemType } from '../types/_item';
import { clearInput } from '../utilities/_helper';
import { folderHelper, renderTable } from './_table';
import newFolderForm from './_form';
import renderFileUploader, { fileUploaderState } from './_fileUpload';
import FileForCreation from '../types/_fileForCreation';
import { FileHelper } from '../models/_file';
import renderSpinner, { removeSpinner } from './_loading';

const fileHelper = new FileHelper();
const modal = () => `<!-- New File Modal -->
<div 
  data-keyboard="false" data-backdrop="static"
  class="modal fade"
  id="modal-form"
  tabindex="-1"
  role="dialog"
  aria-labelledby="modal-formLabel"
  aria-hidden="true"
>
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="modal-title"></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">

      </div>
      <div class="modal-footer">
        <button type="button" id="modal-cancel-button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" id="modal-ok-button" class="btn btn-primary"></button>
      </div>
    </div>
  </div>
</div>`;

// clicking new folder button
const addNewFolderClickEvent = () => {
  $('#newFolderButton').on('click', () => {
    const modalBody = $('.modal-body');
    modalBody.empty();
    modalBody.append(newFolderForm);
    clearInput();
    $('label[for="name"]').text('Folder name');
    $('#modal-title').text('Create new folder');
    $('.modified').hide();
    const modalOkButton = $('#modal-ok-button');
    modalOkButton.text('Create');
    modalOkButton.attr('data-action', 'create');
  });
};

const uploadFileUploadClickEvent = () => {
  $('#toolbar-upload-btn').on('click', () => {
    $('#modal-form').modal('show');
    renderFileUploader();
    $('#modal-title').text('Upload new file');
    const modalOkButton = $('#modal-ok-button');
    modalOkButton.text('Upload');
    modalOkButton.attr('data-action', 'upload');
  });
};

const addSubmitFormEvent = (state: HomeState) => {
  $('#modal-ok-button').on('click', () => {
    const action = $('#modal-ok-button').attr('data-action');
    const type = $('#modal-title')
      .text()
      .includes('folder')
      ? 'folder'
      : 'file';

    if (action === 'create') {
      if (type === 'folder') {
        const name = $('#name').val() as string;
        const parentFolderId = state.currentFolderId;

        // TODO: Change here later => get sub(id) from cookie or somewhere
        const modifiedBy = $('#modifiedBy').val() as string;

        folderHelper.createFolder(name, parentFolderId, modifiedBy, data => {
          if (data.error) {
            // process error when creating
          } else {
            renderTable(state);
            $('#modal-form').modal('hide');
            clearInput();
          }
        });
      }
    }
    if (action === 'upload') {
      if (type === 'file') {
        const { file } = fileUploaderState;
        if (file) {
          const fileForCreation: FileForCreation = {
            createdTime: new Date().toISOString(),
            modified: new Date().toISOString(),
            // FIXME: get from cookie
            modifiedBy: 'Hieu Dang Thanh',
            folderId: state.currentFolderId,
            file: file as File
          };

          renderSpinner();
          fileHelper.uploadFile(fileForCreation, data => {
            removeSpinner();
            if (data.error) {
              // process error when uploading
            } else {
              renderTable(state);
              fileUploaderState.resetState();
              $('#modal-form').modal('hide');
            }
          });
        }
      }
    }
  });
};

const renderModalForm = (state: HomeState) => {
  $('#main-content').append(modal);
  uploadFileUploadClickEvent();
  addNewFolderClickEvent();
  addSubmitFormEvent(state);
};

export const fillInput = (item: Item, id: number) => {
  // set id in the input so editor can find it
  $('#modal-title').attr('data-id', id);
  $('#name').val(item.itemType === ItemType.File ? `${item.name}.${(<MyFile>item).fileExtension}` : item.name);
  $('#modified').val(new Date(item.modified).toISOString().slice(0, 16));
  $('#modifiedBy').val(item.modifiedBy);
};

export const clearModal = () => {
  $('#modal-form').remove();
};

export default renderModalForm;
