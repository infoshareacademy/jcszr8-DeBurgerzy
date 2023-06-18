function search(tabName) {
    var input, filter, ul, li, a, i, txtValue;
    input = document.getElementById("searchInput");
    filter = input.value.toUpperCase();
    table = document.getElementById(tabName);
    rows = table.getElementsByTagName("tr");
    for (i = 0; i < rows.length; i++) {
        shouldDisplay = Object.values(rows[i].cells)
            .map((td) => td.textContent || td.innerText)
            .some(tdText => tdText.toUpperCase().includes(filter))
        //td = rows[i].cells[0];
        //txtValue = td.textContent || td.innerText;
        if (shouldDisplay) {
            rows[i].style.display = "";
        } else {
            rows[i].style.display = "none";
        }
    }
}