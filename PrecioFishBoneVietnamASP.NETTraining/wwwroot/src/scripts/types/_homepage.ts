type HomeState = {
  currentFolderId: number;
  parentFolderId: number | null;
  editingFolderId: number | null;
  setCurrentFolderId: (id: number) => void;
  setParentFolderId: (id: number | null) => void;
  setEditingFolderId: (id: number | null) => void;
};

export default HomeState;
