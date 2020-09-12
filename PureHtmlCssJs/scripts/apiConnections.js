function sendSearchQuery(val) {
    const request = {
        words: val
    };

    const xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            displayResults(this.response);
        }
    };
    xhttp.open('POST', 'https://localhost:5001/search');
    xhttp.setRequestHeader('Content-type', 'application/json');
    xhttp.responseType = 'json';
    xhttp.send(JSON.stringify(request));
}

function getSearchQuery() {
    let params = new URLSearchParams(window.location.search.substring(1));
    document.getElementById("result-page-search-bar").value = params.get("search");
    sendSearchQuery(params.get("search"));
}

function displayResults(searchResults) {
    let template = `<span id="results-count" class="results-count">${searchResults.length === 0 ? "There is no result" : `There are ${searchResults.length} Results`}</span>
        <ul>`;
    for (const result of searchResults) {
        template += `<li>${result}</li>`;
    }
    template += `</ul>`;
    document.getElementById('search-results').innerHTML = template;
}

function setInputValue(val) {
    let resultInput = document.getElementById("result-page-search-bar");
    resultInput.value = val;
}