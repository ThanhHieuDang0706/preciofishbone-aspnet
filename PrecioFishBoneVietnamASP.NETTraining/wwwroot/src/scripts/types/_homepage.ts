type HomeState = {
  currentFolderId: number;
  parentFolderId: number | null;
  setCurrentFolderId: (id: number) => void;
  setParentFolderId: (id: number | null) => void;
};

export default HomeState;
