import $ from 'jquery';

let timeOutId: NodeJS.Timeout;

export const renderEmptyAlert = () => {
  const toast = `
  <div id="toast" class="toast" style="position: fixed; top: 10; right: 50% ; z-index: 1200;">
        <div class="toast-header">
          <strong class="mr-auto text-danger">Error</strong>
          <button id="close-toast-button" type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="toast-body"></div>
      </div>`;

  $('#app-container').prepend(toast);
  $('#close-toast-button').on('click', () => {
    $('#toast').removeClass('show');
  });
};

export const renderAlert = (message: string) => {
  clearTimeout(timeOutId);
  $('#toast').addClass('show');
  $('.toast-body').text(message);

  timeOutId = setTimeout(() => {
    $('#toast').removeClass('show');
  }, 3000);
};
