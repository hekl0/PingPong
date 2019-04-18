document.getElementById("join").addEventListener("click", function (event) {
    var data = null;
    console.log("join");
    var room = document.getElementById("room").value;
    console.log(document.getElementById("room").value);
    var xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            console.log(this.responseText);
            data = JSON.parse(this.response);
            if (data.piles.pile == 0) {
                console.log("has not lost");
            }
            else {
                console.log("has lost!!");
            }
        }
    });
    xhr.open("GET", "test/gamer/" + room);
    xhr.send(data);
});

document.getElementById("create").addEventListener("click", function (event) {
    // var data = null;
    console.log("create")
    var xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            console.log(this.responseText);
            data = JSON.parse(this.response);
            if (data.piles.pile == 0) {
                console.log("has not lost");
            }
            else {
                console.log("has lost!!");
            }
        }
    });
    xhr.open("POST", "api/Gamer/" + room);
    xhr.send();
});