window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer], { type: 'text/csv' });
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName;
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
};


window.downloadSelfAdmitCode = async (fileName, base64Data) => {
    const link = document.createElement('a');
    link.download = fileName;
    link.href = "data:image/png;base64," + base64Data;
    console.log(base64Data);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};