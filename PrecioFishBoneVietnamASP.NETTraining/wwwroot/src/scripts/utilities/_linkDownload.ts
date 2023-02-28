import MyFile from '../types/_file';

export function downloadFileWithId(res: Record<string, any>, fileMapper: Record<number, MyFile>, id: number) {
  const blob = new Blob([res.data], { type: res.contentType });
  const link = document.createElement('a');
  link.href = window.URL.createObjectURL(blob);
  link.download = `${fileMapper[id].name}${fileMapper[id].fileExtension}`;
  link.click();
}
