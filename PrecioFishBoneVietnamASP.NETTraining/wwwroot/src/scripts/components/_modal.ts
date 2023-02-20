import { HomeState } from '../types/_homepage';
import MyFile from '../types/_file';
import Item, { ItemType } from '../types/_item';
import { clearInput } from '../utilities/_helper';
import { folderHelper, renderTable } from './_table';

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
        <form>
          <div class="form-group">
            <label for="name"></label>
            <input type="text" class="form-control" id="name" placeholder="Enter file name">
          </div>
          <div class="form-group modified">
            <label for="modified">Modified</label>
            <input type="datetime-local" class="form-control" id="modified" placeholder="Modified Date">
          </div>
          <div class="form-group">
            <label for="modifiedBy">Modified By</label>
            <input type="text" class="form-control" id="modifiedBy" placeholder="Who modified this?">
          </div>

        </form>

      </div>
      <div class="modal-footer">
        <button type="button" id="modal-cancel-button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" id="modal-ok-button" class="btn btn-primary"></button>
      </div>
    </div>
  </div>
</div>`;

// create new file button
const addNewFileClickEvent = () => {
  $('#newFileButton').on('click', () => {
    clearInput();
    $('label[for="name"]').text('File name');
    $('#modal-title').text('Create new file');
    const modalOkButton = $('#modal-ok-button');
    modalOkButton.text('Create');
    modalOkButton.attr('data-action', 'create');
  });
};

// clicking new folder button
const addNewFolderClickEvent = () => {
  $('#newFolderButton').on('click', () => {
    clearInput();
    $('label[for="name"]').text('Folder name');
    $('#modal-title').text('Create new folder');
    $('.modified').hide();
    const modalOkButton = $('#modal-ok-button');
    modalOkButton.text('Create');
    modalOkButton.attr('data-action', 'create');
  });
};

const renderModalForm = () => {
  $('#main-content').append(modal);
  addNewFolderClickEvent();
  addNewFileClickEvent();
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

export const onSubmitModalForm = (state: HomeState) => {
  // clicking ok button
  // when clicking ok button in modal form
  $('#modal-ok-button').on('click', () => {
    const action = $('#modal-ok-button').attr('data-action');
    if (action === 'create') {
      // folder or file
      const type = $('#modal-title')
        .text()
        .includes('folder')
        ? 'folder'
        : 'file';
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
            clearInput();
          }
        });
      }
    }
  });
};

export default renderModalForm;
