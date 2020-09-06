function sendSearchQuery(val) {
    const request = {
        words: val
    };

    console.log("jgi jigi ");
    
    const xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            console.log(this.response);
        }
    };
    xhttp.open('POST', 'https://localhost:5001/search');
    xhttp.setRequestHeader('Content-type', 'application/json');
    xhttp.responseType = 'json';
    xhttp.send(JSON.stringify(request));
}

function getSearchQuery() {
    document.getElementById("result-page-search-bar").value = window.location.search.substring(8);
    sendSearchQuery(window.location.search.substring(8));
}

function displayResults(searchResults) {
    let template = `<span id="results-count" class="results-count">There are ${searchResults.length} Results</span>
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