function ToggleBookInfo(dataMatch) {
    const row = document.getElementById(dataMatch);
    console.log(dataMatch);
    if (row) {
        row.style.display = (row.style.display === 'none' || row.style.display === "") ? 'table-row' : 'none';
    }
}

function gotoEditBook(type, year, title) {
    if (!year || isNaN(year) || !title || title.trim() === "") {
        alert("Error: cannot edit book without correct title & year publication.");
        return;
    }

    window.location.href = `/${type}/Edit/${year}/${encodeURIComponent(title)}`;
}