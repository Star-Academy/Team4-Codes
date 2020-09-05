function sendSearchQuery() {
    const input = document.getElementById("home-page-search-bar");
    const value = input.value;
    const request = {
        searchQuery: value
    };

    console.log("jgi jigi ")
    const xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            console.log(this.response);
        }
    };
    xhttp.open('POST', 'https://localhost:5000/search');
    xhttp.setRequestHeader('Content-type', 'application/json');
    xhttp.responseType = 'json';
    xhttp.send(JSON.stringify(request));
}
