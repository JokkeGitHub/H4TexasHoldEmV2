function Takeshot() {
    let div = document.getElementById('cardGameContainer');

    html2canvas(div).then(
        function (canvas) {
            document.getElementById('output').appendChild(canvas);
        });
}