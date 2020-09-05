var modal = document.getElementById("help-modal");
var link = document.getElementById("help-popup");
var span = document.getElementsByClassName("close")[0];

link.onclick = function () {
    modal.style.display = "block";
}

span.onclick = function () {
    modal.style.display = "none";
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}