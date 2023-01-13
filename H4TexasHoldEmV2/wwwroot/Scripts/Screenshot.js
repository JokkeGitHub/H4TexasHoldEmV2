
function Takeshot() {
    let div = document.getElementById('app');

    html2canvas(div).then(
        function (canvas) {
            document.getElementById('output').appendChild(canvas);
        });
} 


/*
function DownloadImg() {
    html2canvas(document.querySelector("#output")).then(canvas => {
        saveAs(canvas.ToDataUrl(), 'screenshot.png');
    })
}

function saveAs(uri, filename) {
    var link = document.createElement('a');
    if (typeof link.download === 'string') {
        link.href = uri;
        link.downlaod = filename;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
    else {
        window.open(uri);
    }
}
*/