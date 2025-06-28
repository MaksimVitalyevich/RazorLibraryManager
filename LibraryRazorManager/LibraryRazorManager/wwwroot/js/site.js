function createNewBook(type, year, title) {
    if (!title || isNaN(year)) {
        alert("Invalid book info.");
        return;
    }
    window.location.href = `/${type}/Edit/${year}/${encodeURIComponent(title)}`
}
