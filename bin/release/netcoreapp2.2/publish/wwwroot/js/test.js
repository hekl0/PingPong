let theme_choice = 1;

$("#theme-kitchen").click(function() {
    if (theme_choice == 1) return;
    theme_choice = 1;
    $("#censor-kitchen").attr("hidden", true);
    $("#censor-space").removeAttr("hidden");
    $("#theme-kitchen").addClass("choosed");
    $("#theme-space").removeClass("choosed");
});

$("#theme-space").click(function() {
    if (theme_choice == 2) return;
    theme_choice = 2;
    $("#censor-kitchen").removeAttr("hidden");
    $("#censor-space").attr("hidden", true);
    console.log("lol");
    $("#theme-kitchen").removeClass("choosed");
    $("#theme-space").addClass("choosed");
});

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
                window.open("/game?" + room + "&" + (theme_choice == 1 ? "kitchen" : "space"), "_self");
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
            if (this.status == 400)
                alert(this.responseText);
            if (this.status == 200) {
                console.log("Ok");
                //move to next screen
                window.open("/game?" + room + "&" + ((theme_choice == 1) ? "kitchen" : "space"), "_self");
            }
        }
    });
    xhr.open("GET", "api/room/" + room + "/create");
    xhr.send();
});