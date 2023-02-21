const newFolderForm = `
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
`;
export default newFolderForm;
