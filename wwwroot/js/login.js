document.getElementById("join").addEventListener("click", function (event) {
    var data = null;
    console.log("join");
    var room = document.getElementById("room").value;
    console.log(document.getElementById("room").value);
    var xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            if (this.status == 400)
                alert(this.responseText);
            if (this.status == 200) {
                console.log("Ok");
                //move to next screen
                var newPage = window.open("/game", "_self");
                newPage.groupID = room;
            }
        }
    });
    xhr.open("GET", "api/room/" + room + "/join");
    xhr.send(data); 
});

document.getElementById("create").addEventListener("click", function (event) {
    // var data = null;
    console.log("create")
    var room = document.getElementById("room").value;
    var xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            if (this.readyState === 4) {
                if (this.status == 400)
                    alert(this.responseText);
                if (this.status == 200) {
                    console.log("Ok");
                    //move to next screen
                    // $(location).attr('href', '/game');
                    var newPage = window.open("/game", "_self");
                    newPage.groupID = room;
                }
            }
        }
    });
    xhr.open("GET", "api/room/" + room + "/create");
    xhr.send();
});