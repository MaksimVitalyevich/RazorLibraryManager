function ToggleBookInfo(id) {
    const row = document.getElementById(id);
    console.log(id);
    if (row) {
        row.style.display = (row.style.display === 'none' || row.style.display === "") ? 'table-row' : 'none';
    }
}

function gotoEditBook(type, id) {
    window.location.href = `/${type}/Edit?id=${id}`;
}